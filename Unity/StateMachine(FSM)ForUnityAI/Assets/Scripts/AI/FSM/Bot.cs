using AI_Examples.FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace AI_Examples.FSM
{
    [RequireComponent(typeof(NavMeshAgent), typeof(CapsuleCollider), typeof(Rigidbody))]
    [System.Serializable]
    public class Bot : MonoBehaviour
    {
        #region Main components
        [SerializeField] NavMeshAgent agent;
        [SerializeField] new CapsuleCollider collider;
        [SerializeField] new Rigidbody rigidbody;
        public GameObject Target;
        #endregion

        #region Target values
        Drive targetController;
        Vector3 wanderTarget = Vector3.zero;
        Vector3 targetLocal = Vector3.zero;
        Vector3 targetWorld = Vector3.zero;
        public bool VisualizeWanderValues = false;
        #endregion

        enum BotState
        {
            NONE,
            PURSUE,
            EVADE,
            WANDER,
            HIDE,
            AUTO
        }

        [SerializeField] BotState state = BotState.NONE;
        [SerializeField] bool autoState = false;

        void Awake()
        {
            if (!agent) agent = GetComponent<NavMeshAgent>();
            if (!collider) collider = GetComponent<CapsuleCollider>();
            if (!rigidbody) rigidbody = GetComponent<Rigidbody>();
            if (Target) targetController = GetComponent<Drive>();
        }

        void Seek(Vector3 location)
        {
            agent.SetDestination(location);
        }

        void Flee(Vector3 location)
        {
            Vector3 fleeVector = location - transform.position;
            agent.SetDestination(transform.position - fleeVector);
        }

        void Pursue()
        {
            if (!targetController) targetController = Target.GetComponent<Drive>();

            Vector3 targetDirection = Target.transform.position - transform.position;

            float relativeHeading = Vector3.Angle(transform.forward, transform.TransformVector(Target.transform.forward));
            float toTarget = Vector3.Angle(transform.forward, transform.TransformVector(targetDirection));

            if ((toTarget > 90 && relativeHeading < 20) || targetController.speed < 0.01f)
            {
                Seek(transform.position);
                return;
            }

            float lookAhead = targetDirection.magnitude / (agent.speed + targetController.currentSpeed);
            Seek(Target.transform.position + (Target.transform.forward * lookAhead));
        }

        void Evade()
        {
            if (!targetController) targetController = Target.GetComponent<Drive>();

            Vector3 targetDirection = Target.transform.position - transform.position;
            float lookAhead = targetDirection.magnitude / (agent.speed + targetController.currentSpeed);

            Flee(Target.transform.position + Target.transform.forward * lookAhead);
        }

        void Wander()
        {
            float wanderRadius = 10f;
            float wanderDistrance = 10f;
            float wanderJitter = 10f;

            wanderTarget += new Vector3(Random.Range(-1f, 1f) * wanderJitter, 0, Random.Range(-1f, 1f) * wanderJitter);

            wanderTarget.Normalize();
            wanderTarget *= wanderRadius;

            targetLocal = wanderTarget + new Vector3(0, 0, wanderDistrance);
            targetWorld = transform.InverseTransformVector(targetLocal);

            Seek(targetWorld);
        }

        void OnDrawGizmosSelected()
        {
            if (state == BotState.WANDER && VisualizeWanderValues)
            {
                // Line from us to the wander center
                Gizmos.color = Color.green;
                Gizmos.DrawLine(transform.position, targetLocal);

                // Line from center to the wander external target on the radius end
                Gizmos.color = Color.red;
                Gizmos.DrawLine(targetLocal, targetWorld);

                // Size of the ring
                Gizmos.color = Color.yellow;
                Gizmos.DrawWireSphere(targetLocal, Vector3.Distance(targetLocal, targetWorld));
            }
        }

        void Hide()
        {
            float distance = Mathf.Infinity;
            Vector3 chosenSpot = Vector3.zero;

            for (int i = 0; i < World.Instance.HidingSpots.Count; i++)
            {
                Vector3 hideDirection = World.Instance.HidingSpots[i].transform.position - Target.transform.position;
                Vector3 hidePossition = World.Instance.HidingSpots[i].transform.position + hideDirection.normalized * 10;

                if (Vector3.Distance(transform.position, hidePossition) < distance)
                {
                    chosenSpot = hidePossition;
                    distance = Vector3.Distance(transform.position, hidePossition);
                }
            }

            Seek(chosenSpot);
        }

        void CleverHide()
        {
            float distance = Mathf.Infinity;
            Vector3 chosenSpot = Vector3.zero;
            Vector3 chosenDirection = Vector3.zero;
            HideSpot chosenGO = World.Instance.HidingSpots[0];

            for (int i = 0; i < World.Instance.HidingSpots.Count; i++)
            {
                Vector3 hideDirection = World.Instance.HidingSpots[i].transform.position - Target.transform.position;
                Vector3 hidePossition = World.Instance.HidingSpots[i].transform.position + hideDirection.normalized * 10;

                if (Vector3.Distance(transform.position, hidePossition) < distance)
                {
                    chosenSpot = hidePossition;
                    chosenDirection = hideDirection;
                    chosenGO = World.Instance.HidingSpots[i];
                    distance = Vector3.Distance(transform.position, hidePossition);
                }
            }

            Collider hideCollider = chosenGO.collider;
            Ray backRay = new Ray(chosenSpot, -chosenDirection.normalized);
            float rayDistance = 100.0f;
            hideCollider.Raycast(backRay, out RaycastHit hit, rayDistance);

            Seek(hit.point + chosenDirection.normalized * 2);
        }

        bool CanSeeTarget()
        {
            Vector3 direction = Target.transform.position - transform.position;
            Physics.Raycast(transform.position, direction, out RaycastHit hit);

            if (hit.transform.gameObject == Target)
            {
                return true;
            }
            return false;
        }

        bool TargetCanSeeMe()
        {
            Vector3 diractionToAgent = transform.position - Target.transform.position;
            float lookingAngle = Vector3.Angle(Target.transform.forward, diractionToAgent);

            if (lookingAngle < 60) return true;
            return false;
        }

        bool TargetInRange(float range)
        {
            if (Vector3.Distance(transform.position, Target.transform.position) < range)
            {
                return true;
            }
            return false;
        }

        void Update()
        {
            ManageInput();
            ManageStates();
        }

        IEnumerator IautoBehave()
        {
            autoState = true;

            if (CanSeeTarget() && TargetCanSeeMe())
            {
                CleverHide();
                yield return new WaitForSeconds(5f);
            }
            else if (TargetInRange(10f))
            {
                Pursue();
            }
            else
            {
                Wander();
            }

            autoState = false;
        }

        private void ManageStates()
        {
            if (state == BotState.WANDER) Wander();
            else if (state == BotState.AUTO && autoState == false)
            {
                StartCoroutine(IautoBehave());
            }
            else if (CanSeeTarget())
            {
                if (state == BotState.EVADE) Evade();
                else if (state == BotState.PURSUE) Pursue();
                else if (state == BotState.HIDE) CleverHide();
            }
        }

        private void ManageInput()
        {
            if (Input.GetKeyDown(KeyCode.P)) state = BotState.PURSUE;
            if (Input.GetKeyDown(KeyCode.O)) state = BotState.EVADE;
            if (Input.GetKeyDown(KeyCode.I)) state = BotState.WANDER;
            if (Input.GetKeyDown(KeyCode.U)) state = BotState.HIDE;
            if (Input.GetKeyDown(KeyCode.Y)) state = BotState.AUTO;
        }
    }
}