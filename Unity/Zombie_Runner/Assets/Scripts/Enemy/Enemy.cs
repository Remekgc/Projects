using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Enemy_AI))]
public abstract class Enemy : BaseStats
{
    [SerializeField] protected Animator animator;

    [Header("Stats")]
    [SerializeField] protected int damage = 20;
    [SerializeField] protected float atackSpeed = 2f;
    [Tooltip("Keep this a bit larger than the stopping distance of the Nav Mesh Agent")]
    [SerializeField] protected float atackRange = 1.6f;
    [SerializeField] protected float chaseRange = 5f;

    [Header("States")]
    public bool autoFindPlayer = true;
    public bool isProvoked = false;

    Enemy_AI enemy_AI;

    bool inAttackAnimation = false;

    protected virtual void Awake()
    {
        if (!animator) { animator = GetComponent<Animator>(); }
        if (!enemy_AI) { enemy_AI = GetComponent<Enemy_AI>(); }
    }

    protected virtual void Start()
    {
        if (autoFindPlayer)
        {
            enemy_AI.target = GameManager.Instance.player.gameObject;
        }
    }

    protected virtual void Update()
    {
        if (hitPoints > 0)
        {
            if (enemy_AI.GetDistanceToTarget() <= chaseRange || isProvoked)
            {
                isProvoked = true;
                EngageTarget();
            }
            else
            {
                enemy_AI.isLookingAtTarget = false;
                enemy_AI.agent.isStopped = true;
            }
        }
    }

    protected virtual void EngageTarget()
    {
        if (enemy_AI.GetDistanceToTarget() > atackRange && !enemy_AI.agent.isStopped)
        {
            ChaseTarget();
        }
        else if (enemy_AI.GetDistanceToTarget() <= atackRange)
        {
            StartCoroutine(AttackTarget());
        }
    }

    protected virtual void ChaseTarget()
    {
        animator.SetBool("attack", false);
        animator.SetTrigger("move");
    }

    protected virtual IEnumerator AttackTarget()
    {
        if (!inAttackAnimation)
        {
            enemy_AI.agent.isStopped = true;
            animator.SetBool("attack", true);
            enemy_AI.isLookingAtTarget = false;
            inAttackAnimation = true;

            yield return new WaitForSeconds(atackSpeed);

            if (enemy_AI.GetDistanceToTarget() <= atackRange) 
            { 
                enemy_AI.target.GetComponent<BaseStats>().TakeDamage(new Damage(damage, gameObject));
            }

            enemy_AI.isLookingAtTarget = true;
            inAttackAnimation = false;
            enemy_AI.agent.isStopped = false;
        }
    }

    public override void TakeDamage(Damage damage)
    {
        base.TakeDamage(damage);
        enemy_AI.target = damage.damageDealer;
        isProvoked = true;
    }

    public override void Die()
    {
        enemy_AI.agent.isStopped = true;
        animator.SetTrigger("die");
        Destroy(gameObject, 3f);
    }

    void OnDrawGizmosSelected()
    {
        DrawChaseRangeSphere();
    }

    void DrawChaseRangeSphere()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

}
