using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleEnemy : BaseStats
{
    [SerializeField] int atackDamage = 40;

    CapsuleEnemy_AI enemy_AI;
    
    void Awake()
    {
        enemy_AI = GetComponent<CapsuleEnemy_AI>();
    }

    public override void TakeDamage(Damage damage)
    {
        hitPoints -= damage.amount;
        enemy_AI.isProvoked = true;

        if (hitPoints <= 0)
        {
            Die();
        }
    }
    public override void Die()
    {
        Destroy(gameObject);
    }

    public void AttackHitEvent()
    {
        BaseStats targetStats = enemy_AI.target.GetComponent<BaseStats>();
        if (targetStats)
        {
            targetStats.TakeDamage(new Damage(atackDamage, gameObject));
        }
        else
        {
            print("Atacking with no damage :D");
        }
    }
}
