using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseStats : MonoBehaviour
{
    public float hitPoints = 100f;

    public virtual void TakeDamage(float amount)
    {
        hitPoints -= amount;
        if (hitPoints <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }
}
