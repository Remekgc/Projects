using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CapsuleEnemy_AI : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] float chaseRange = 5f;

    NavMeshAgent agent;
    float distanceToTarget = Mathf.Infinity;

    public string playerObjectName = "Player";
    [Header("States")]
    public bool autoFindPlayer = true;
    public bool isProvoked = false;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        if (autoFindPlayer)
        {
            target = GameObject.Find(playerObjectName);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        distanceToTarget = Vector3.Distance(target.transform.position, transform.position);

        if (distanceToTarget <= chaseRange || isProvoked)
        {
            isProvoked = true;
            EngageTarget();
        }
        else
        {
            agent.SetDestination(transform.position);
        }
    }

    private void EngageTarget()
    {
        if (distanceToTarget > agent.stoppingDistance)
        {
            ChaseTarget();
        }
        else if (distanceToTarget <= agent.stoppingDistance)
        {
            AtackTarget();
        }
    }

    private void ChaseTarget()
    {
        agent.SetDestination(target.transform.position);
    }

    private void AtackTarget()
    {
        Debug.Log(name + " - Die " + target.name);
    }

    void OnDrawGizmosSelected()
    {
        DrawChaseRangeSphere();
    }

    private void DrawChaseRangeSphere()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
