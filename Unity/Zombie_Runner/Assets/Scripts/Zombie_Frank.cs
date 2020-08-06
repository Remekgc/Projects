using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Zombie_Frank_AI))]
public class Zombie_Frank : Enemy
{
    public override void Die()
    {
        base.Die();
        GetComponent<CapsuleCollider>().enabled = false;
        GameManager.Instance.UI_controller.UpdateKills();
    }
}
