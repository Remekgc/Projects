using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace AI_Examples.WaypointsAndGraphs
{
    public class AgentFollowPlayer : MonoBehaviour
    {
        [SerializeField] GameObject player;
        [SerializeField] NavMeshAgent agent;

        void Awake()
        {
            if (!agent) agent = GetComponent<NavMeshAgent>();
        }

        void Start()
        {
            if (!player) player = GameObject.FindWithTag("Player");
        }

        void Update()
        {
            agent.SetDestination(player.transform.position);
        }

    }

}

