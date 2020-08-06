using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseStats : MonoBehaviour
{
    public int hitPoints = 100;
    public bool isAlive = true;

    public virtual void TakeDamage(Damage damage)
    {
        if (isAlive)
        {
            hitPoints -= damage.amount;
            if (hitPoints <= 0)
            {
                hitPoints = 0;
                Die();
            }
        }

    }

    public virtual void Die()
    {
        isAlive = false;
        Destroy(gameObject);
    }
}

public struct Damage
{
    public int amount;
    public GameObject damageDealer;

    public Damage(int amount, GameObject damageDealer)
    {
        this.amount = amount;
        this.damageDealer = damageDealer;
    }
}
