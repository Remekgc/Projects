using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Enemy_AI))]
public abstract class Enemy : BaseStats
{
    [SerializeField] protected Animator animator;

    [Header("Stats")]
    [SerializeField] protected int damage = 20;
    [SerializeField] protected float attackSpeed = 2f;
    [Tooltip("Keep this a bit larger than the stopping distance of the Nav Mesh Agent")]
    [SerializeField] protected float atackRange = 1.6f;
    [SerializeField] protected float chaseRange = 5f;
    [SerializeField] protected List<Pickable> dropItems = new List<Pickable>();

    [Header("States")]
    public bool autoEngagePlayer = true;
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
        enemy_AI.target = GameManager.Instance.player.gameObject;
        if (autoEngagePlayer) isProvoked = true;
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
                animator.SetTrigger("idle");
                enemy_AI.isLookingAtTarget = false;
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
            StartCoroutine(IAttackTarget());
        }
    }

    protected virtual void ChaseTarget()
    {
        animator.SetBool("attack", false);
        animator.SetTrigger("move");
        enemy_AI.SetDestination(enemy_AI.target.transform);
    }

    protected virtual IEnumerator IAttackTarget()
    {
        if (!inAttackAnimation)
        {
            enemy_AI.agent.isStopped = true;
            animator.SetBool("attack", true);
            enemy_AI.isLookingAtTarget = false;
            inAttackAnimation = true;

            yield return new WaitForSeconds(attackSpeed);

            enemy_AI.isLookingAtTarget = true;
            inAttackAnimation = false;
            enemy_AI.agent.isStopped = false;
        }
    }

    void DealDamage()
    {
        if (enemy_AI.GetDistanceToTarget() <= atackRange)
        {
            BaseStats targetStas = enemy_AI.target.GetComponent<BaseStats>();
            if (targetStas) targetStas.TakeDamage(new Damage(damage, gameObject));
        }
    }

    public override void TakeDamage(Damage damage)
    {
        base.TakeDamage(damage);
        enemy_AI.target = damage.damageDealer;
        isProvoked = true;
        //print(gameObject.name + "Took damage from: " + damage.damageDealer.name);
    }

    public override void Die()
    {
        isAlive = false;
        StopAllCoroutines();
        DropItems();
        enemy_AI.agent.isStopped = true;
        enemy_AI.isLookingAtTarget = false;
        animator.SetTrigger("die");

        Destroy(gameObject, 3f);
    }

    private void DropItems()
    {
        int dropOrNot = Random.Range(0, 101);
        int itemAmount = dropItems.Count;
        Vector3 dropPos = transform.position + new Vector3(0, 1, 0);

        if (dropOrNot < 50 && itemAmount > 0) Instantiate(dropItems[Random.Range(0, itemAmount)], dropPos, Quaternion.identity);
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
