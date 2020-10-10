using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootRangeTarget : BaseStats
{
    [SerializeField] int scoreForHit = 100;
    
    public override void TakeDamage(Damage damage)
    {
        GameManager.Instance.GameScore.AddScore(scoreForHit);
        base.TakeDamage(damage);
    }
}
