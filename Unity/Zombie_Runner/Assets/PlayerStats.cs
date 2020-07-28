using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerStats : BaseStats
{
    public override void Die()
    {
        print("Oooops I'm dead");
        //GameManager.Instance.gameObject.BroadcastMessage("EndGame", false);
        GameManager.Instance.UI_controller.EndGame(false);
        //base.Die();
    }

}
