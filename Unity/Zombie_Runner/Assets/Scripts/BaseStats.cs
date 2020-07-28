using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseStats : MonoBehaviour
{
    public int hitPoints = 100;

    public virtual void TakeDamage(int amount)
    {
        hitPoints -= amount;
        if (hitPoints <= 0)
        {
            hitPoints = 0;
            Die();
        }
    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }
}
