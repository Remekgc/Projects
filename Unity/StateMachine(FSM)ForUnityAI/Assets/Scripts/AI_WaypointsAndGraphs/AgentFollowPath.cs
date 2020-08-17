using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


namespace AI_WaypointsAndGraphs
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class AgentFollowPath : MonoBehaviour
    {
        public AI_Astar.WaypointManager wpManager;
        GameObject[] waypoints;
        [SerializeField] NavMeshAgent agent;

        void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
        }

        void Start()
        {
            waypoints = wpManager.waypoints;
        }

        public void GoToHeli()
        {
            agent.SetDestination(waypoints[10].transform.position);
        }

        public void GoToRuin()
        {
            agent.SetDestination(waypoints[3].transform.position);
        }

        public void GoToFactory()
        {
            agent.SetDestination(waypoints[5].transform.position);
        }


        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;

                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
                {
                    agent.SetDestination(hit.point);
                }
            }
        }
    }

}
