using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerStats : BaseStats
{
    public Inventory inventory;
    public int kills;

    void Awake()
    {
        if (!inventory) inventory = GetComponent<Inventory>();
    }

    void Start()
    {
        if (!GameManager.Instance.player) GameManager.Instance.player = gameObject;
    }

    public override void TakeDamage(Damage damage)
    {
        base.TakeDamage(damage);
        GameManager.Instance.UI_controller.PlayDamagedAnimation();
    }

    public override void Die()
    {
        //GameManager.Instance.gameObject.BroadcastMessage("EndGame", false);
        GameManager.Instance.UI_controller.EndGame(false);
        //base.Die();
    }

}
