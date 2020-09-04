using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace AI_Examples.FSM
{
    public class CrowdControl_AI_NPC : MonoBehaviour
    {
        [SerializeField] List<GameObject> goalLocations = new List<GameObject>();
        [SerializeField] NavMeshAgent agent;
        [SerializeField] Animator animator;
        [SerializeField] float walkingSpeedMultiplier = 0f;
        [SerializeField] float detectionRadius = 10f;
        [SerializeField] float fleeRadius = 20f;

        [SerializeField] bool panic = false;

        void Awake()
        {
            if (!agent) agent = GetComponent<NavMeshAgent>();
            if (!animator) animator = GetComponent<Animator>();
        }

        void Start()
        {
            goalLocations.AddRange(GameObject.FindGameObjectsWithTag("goal"));
            animator.SetFloat("walkingOffset", Random.Range(0f, 1f));

            ResetAgent();
            SetRandomLocation();
        }

        void ResetAgent()
        {
            animator.ResetTrigger("isWalking");
            animator.ResetTrigger("isRunning");

            walkingSpeedMultiplier = Random.Range(0.5f, 1f);
            agent.speed = 2 * walkingSpeedMultiplier;
            agent.angularSpeed = 120;
            animator.SetFloat("speedMultiplier", walkingSpeedMultiplier);
            agent.ResetPath();
        }

        void SetRandomLocation()
        {
            animator.SetTrigger("isWalking");
            agent.SetDestination(goalLocations[Random.Range(0, goalLocations.Count)].transform.position);
        }

        void LateUpdate() 
        {
            if (agent.hasPath)
            {
                if (agent.remainingDistance <= agent.stoppingDistance && panic == false)
                {
                    SetRandomLocation();
                }
            }

        }

        public void DetectNewObstacle(Vector3 obstaclePosition)
        {
            panic = true;

            if (Vector3.Distance(obstaclePosition, transform.position) < detectionRadius)
            {
                Vector3 fleeDirection = (transform.position - obstaclePosition).normalized;
                Vector3 newGoal = transform.position + (fleeDirection * fleeRadius); // Make sure this works properly

                NavMeshPath path = new NavMeshPath();
                agent.CalculatePath(newGoal, path);

                if(path.status != NavMeshPathStatus.PathInvalid)
                {
                    agent.SetDestination(path.corners[path.corners.Length - 1]); // end of the calculated path (last point)
                    animator.speed = 3;
                    animator.SetTrigger("isRunning");
                    agent.angularSpeed = 500;
                }

            }
        }

    }

}

