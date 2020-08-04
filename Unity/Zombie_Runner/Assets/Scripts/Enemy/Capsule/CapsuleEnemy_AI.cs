using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CapsuleEnemy_AI : MonoBehaviour
{
    [Header("Main Components")]
    public GameObject target;
    [SerializeField] float chaseRange = 5f;

    NavMeshAgent agent;
    Animator animator;
    float distanceToTarget = Mathf.Infinity;

    public string playerObjectName = "Player";

    [Header("States")]
    public bool autoFindPlayer = true;
    public bool isProvoked = false;
    public bool isLookingAtTarget = true;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }
    
    void Start()
    {
        if (autoFindPlayer)
        {
            target = GameObject.Find(playerObjectName);
        }
    }

    void FixedUpdate()
    {
        distanceToTarget = Vector3.Distance(target.transform.position, transform.position);

        if (distanceToTarget <= chaseRange || isProvoked)
        {
            isProvoked = true;
            EngageTarget();
            FaceTarget();
        }
        else
        {
            agent.SetDestination(transform.position);
        }
    }

    void FaceTarget()
    {
        if (isLookingAtTarget && target != gameObject)
        {
            Vector3 direction = (target.transform.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
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
            StartCoroutine(AttackTarget());
        }
    }

    private void ChaseTarget()
    {
        animator.SetBool("atack", false);
        animator.SetTrigger("move");
        agent.SetDestination(target.transform.position);
    }

    IEnumerator AttackTarget()
    {
        animator.SetBool("atack", true);
        isLookingAtTarget = false;
        yield return new WaitForSeconds(1f);
        isLookingAtTarget = true;
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
