using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public abstract class Enemy_AI : MonoBehaviour
{
    [Header("Main Components")]
    public GameObject target;
    public NavMeshAgent agent;

    [Header("AI")]
    [SerializeField] float distanceToTarget = Mathf.Infinity;
    public bool isLookingAtTarget = false;

    void Awake()
    {
        if (!agent) { agent = GetComponent<NavMeshAgent>(); }
    }

    protected virtual void OnEnable()
    {
        StartCoroutine(CalculateDistanceToTheTarget());
    }

    void Update()
    {
        FaceTarget();
        if (!agent.isStopped){ agent.SetDestination(target.transform.position); }
    }

    IEnumerator CalculateDistanceToTheTarget()
    {
        while (true)
        {
            if (target) { distanceToTarget = Vector3.Distance(target.transform.position, transform.position); }
            else { distanceToTarget = Mathf.Infinity; }
        
            yield return new WaitForSeconds(0.1f);
        }
    }

    public float GetDistanceToTarget()
    {
        return distanceToTarget;
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

    public void SetTarget(GameObject target)
    {
        this.target = target;
        agent.isStopped = false;
        agent.SetDestination(target.transform.position);
    }

    protected virtual void OnDisable()
    {
        StopAllCoroutines();
    }

}
