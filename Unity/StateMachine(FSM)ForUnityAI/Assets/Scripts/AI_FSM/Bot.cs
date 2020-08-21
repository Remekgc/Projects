using AI_Examples.FSM;
using UnityEngine;
using UnityEngine.AI;

namespace AI_Examples.FSM
{

}

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
        HIDE
    }

    [SerializeField] BotState state = BotState.NONE;

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

        for (int i = 0; i < World.Instance.HidingSpots.Length; i++)
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

    void Update()
    {
        ManageInput();
        ManageStates();
    }

    private void ManageStates()
    {
        if (state == BotState.WANDER) Wander();
        else if (state == BotState.EVADE) Evade();
        else if (state == BotState.PURSUE) Pursue();
        else if (state == BotState.HIDE) Hide();
    }

    private void ManageInput()
    {
        if (Input.GetKeyDown(KeyCode.P)) state = BotState.PURSUE;
        if (Input.GetKeyDown(KeyCode.O)) state = BotState.EVADE;
        if (Input.GetKeyDown(KeyCode.I)) state = BotState.WANDER;
        if (Input.GetKeyDown(KeyCode.U)) state = BotState.HIDE;
    }
}
