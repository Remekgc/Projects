using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


namespace AI_Examples.FSM
{
    public class DropBeaconOnClick : MonoBehaviour
    {
        public GameObject obstacle;
        public List<GameObject> agents;

        void Start()
        {
            agents.AddRange(GameObject.FindGameObjectsWithTag("agent"));
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray.origin, ray.direction, out RaycastHit hit))
                {
                    Instantiate(obstacle, hit.point, obstacle.transform.rotation);

                    foreach (GameObject agent in agents)
                    {
                        agent.GetComponent<CrowdControl_AI_NPC>().DetectNewObstacle(hit.point);
                    }
                }
            }
        }
    }
}

