using UnityEngine;
using UnityEngine.AI;

namespace AI_Examples.FSM
{
    [System.Serializable]
    public class State
    {
        public enum STATE
        {
            IDLE,
            PATROL,
            PURSUE,
            ATTACK,
            SLEEP,
            RUNAWAY
        };

        public enum EVENT
        {
            ENTER, UPDATE, EXIT
        }

        public STATE Name;
        public GameObject CurrentTarget;

        protected EVENT stage;
        protected GameObject npc;
        protected NavMeshAgent agent;
        protected Animator animator;
        protected Transform player;
        protected State nextState; //Add prevoiusState if needed

        [SerializeField] float visionDistance = 10.0f;
        [SerializeField] float scareDistance = 2f;
        [SerializeField] float visionAngle = 40.0f;
        [SerializeField] float atackRange = 7.0f;

        public State(GameObject npc, NavMeshAgent agent, Animator animator, Transform player)
        {
            this.npc = npc;
            this.agent = agent;
            this.animator = animator;
            stage = EVENT.ENTER;
            this.player = player;
        }

        protected virtual void Enter()
        {
            stage = EVENT.UPDATE;
        }

        protected virtual void Update()
        {
            stage = EVENT.UPDATE;
        }

        protected virtual void Exit()
        {
            stage = EVENT.EXIT;
        }

        public State Process()
        {
            if (stage == EVENT.ENTER) Enter();
            else if (stage == EVENT.UPDATE) Update();
            else if (stage == EVENT.EXIT)
            {
                Exit();
                return nextState;
            }
            return this;
        }

        public bool CanSeePlayer()
        {
            Vector3 direction = player.position - npc.transform.position;
            float angle = Vector3.Angle(direction, npc.transform.forward);
            Debug.DrawRay(npc.transform.position, direction);

            if (direction.magnitude < visionDistance && angle < visionAngle)
            {
                return true;
            }
            return false;
        }

        public bool CanAttackPlayer()
        {
            Vector3 direction = player.position - npc.transform.position;
            if (direction.magnitude < atackRange)
            {
                return true;
            }
            return false;
        }

        public bool IsPlayerBehind()
        {
            Vector3 direction = player.position - npc.transform.position;
            float angle = Vector3.Angle(direction, npc.transform.forward);
            Debug.DrawRay(npc.transform.position, direction);

            if (direction.magnitude < scareDistance && angle > visionAngle)
            {
                return true;
            }
            return false;
        }
    }

    public class Idle : State
    {
        public Idle(GameObject npc, NavMeshAgent agent, Animator animator, Transform player)
            : base(npc, agent, animator, player)
        {
            Name = STATE.IDLE;
        }

        protected override void Enter()
        {
            agent.isStopped = true;
            agent.speed = 0f;
            animator.SetTrigger("isIdle");
            CurrentTarget = null;

            PanicEvent.OnPanic += Panic;

            base.Enter();
        }

        protected override void Update()
        {
            if (CanSeePlayer())
            {
                nextState = new Pursue(npc, agent, animator, player);
                stage = EVENT.EXIT;
            }
            else if (Input.GetKey(KeyCode.P))
            {
                nextState = new Patrol(npc, agent, animator, player);
                stage = EVENT.EXIT;
            }
            else if (IsPlayerBehind())
            {
                Panic();
            }
        }

        private void Panic()
        {
            nextState = new RunAway(npc, agent, animator, player);
            stage = EVENT.EXIT;
        }

        protected override void Exit()
        {
            PanicEvent.OnPanic -= Panic;
            animator.ResetTrigger("isIdle");
            base.Exit();
        }
    }

    public class Patrol : State
    {
        int currentIndex;

        public Patrol(GameObject npc, NavMeshAgent agent, Animator animator, Transform player)
            : base(npc, agent, animator, player)
        {
            Name = STATE.PATROL;
        }

        protected override void Enter()
        {
            FindClosestWaypoint();
            agent.stoppingDistance = 1;
            agent.speed = 2f;
            agent.isStopped = false;
            animator.SetTrigger("isWalking");

            PanicEvent.OnPanic += Panic;

            base.Enter();
        }

        private void FindClosestWaypoint()
        {
            float lastDistance = Mathf.Infinity;

            for (int i = 0; i < GameEnvironment.Instance.CheckPoints.Count; i++)
            {
                GameObject waypoint = GameEnvironment.Instance.CheckPoints[i];
                float distance = Vector3.Distance(npc.transform.position, waypoint.transform.position);

                if (distance < lastDistance)
                {
                    currentIndex = i - 1; // -1 becaouse the update increses the currentIndex by 1 automatically.
                    lastDistance = distance;
                }
            }
        }

        protected override void Update()
        {
            // TODO: improve the logic later on
            CheckPatrolDestination();

            if (Input.GetKey(KeyCode.I))
            {
                nextState = new Idle(npc, agent, animator, player);
                stage = EVENT.EXIT;
            }
            else if (CanSeePlayer())
            {
                nextState = new Pursue(npc, agent, animator, player);
                stage = EVENT.EXIT;
            }
            else if (IsPlayerBehind())
            {
                Panic();
            }
        }

        private void Panic()
        {
            nextState = new RunAway(npc, agent, animator, player);
            stage = EVENT.EXIT;
        }

        private void CheckPatrolDestination()
        {
            if (agent.remainingDistance < agent.stoppingDistance)
            {
                if (currentIndex >= GameEnvironment.Instance.CheckPoints.Count - 1)
                {
                    currentIndex = 0;
                }
                else
                {
                    currentIndex++;
                }

                CurrentTarget = GameEnvironment.Instance.CheckPoints[currentIndex];
                agent.SetDestination(CurrentTarget.transform.position);
            }
        }

        protected override void Exit()
        {
            PanicEvent.OnPanic -= Panic;
            animator.ResetTrigger("isWalking");
            base.Exit();
        }
    }

    public class Pursue : State
    {
        public Pursue(GameObject npc, NavMeshAgent agent, Animator animator, Transform player)
            : base(npc, agent, animator, player)
        {
            Name = STATE.PURSUE;
        }

        protected override void Enter()
        {
            agent.isStopped = false;
            agent.speed = 5f;
            animator.SetTrigger("isRunning");
            CurrentTarget = player.gameObject;
            base.Enter();
        }

        protected override void Update()
        {
            agent.SetDestination(player.position);

            if (agent.hasPath)
            {
                if (CanAttackPlayer())
                {
                    nextState = new Attack(npc, agent, animator, player);
                    stage = EVENT.EXIT;
                }
                else if (!CanSeePlayer())
                {
                    nextState = new Patrol(npc, agent, animator, player);
                    stage = EVENT.EXIT;
                }
            }
        }

        protected override void Exit()
        {
            animator.ResetTrigger("isRunning");
            base.Exit();
        }

    }

    public class Attack : State
    {
        public float rotationSpeed = 2.0f;
        readonly AudioSource shoot;

        public Attack(GameObject npc, NavMeshAgent agent, Animator animator, Transform player)
            : base(npc, agent, animator, player)
        {
            Name = STATE.ATTACK;
            shoot = npc.GetComponent<AudioSource>();
        }

        protected override void Enter()
        {
            agent.isStopped = true;
            animator.SetTrigger("isShooting");
            shoot.Play();
            base.Enter();
        }

        protected override void Update()
        {
            RotateTowardsTarget();

            if (!CanAttackPlayer())
            {
                nextState = new Patrol(npc, agent, animator, player);
                stage = EVENT.EXIT;
            }
        }

        private void RotateTowardsTarget()
        {
            Vector3 direction = player.position - npc.transform.position;
            float angle = Vector3.Angle(direction, npc.transform.forward);
            direction.y = 0;

            npc.transform.rotation = Quaternion.Slerp(npc.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotationSpeed);
        }

        protected override void Exit()
        {
            animator.ResetTrigger("isShooting");
            shoot.Stop();
            base.Exit();
        }
    }

    public class RunAway : State
    {
        public RunAway(GameObject npc, NavMeshAgent agent, Animator animator, Transform player)
            : base(npc, agent, animator, player)
        {
            Name = STATE.RUNAWAY;
        }

        protected override void Enter()
        {
            agent.isStopped = false;
            agent.speed = 6f;
            animator.SetTrigger("isRunning");
            agent.stoppingDistance = 2;
            CurrentTarget = GameEnvironment.Instance.SafeZone;
            base.Enter();
        }

        protected override void Update()
        {
            agent.SetDestination(CurrentTarget.transform.position);

            if (agent.hasPath && agent.remainingDistance < agent.stoppingDistance)
            {
                nextState = new Patrol(npc, agent, animator, player);
                stage = EVENT.EXIT;
            }
        }

        protected override void Exit()
        {
            animator.ResetTrigger("isRunning");
            base.Exit();
        }
    }

}

