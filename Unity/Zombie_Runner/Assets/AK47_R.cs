using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK47_R : RaycastWeapon
{
    void Start()
    {
        ammo.AddAmmo(20);
        damage = 30;
    }

    void OnEnable()
    {
        Invoke("UpdateWeaponName", 0.1f);
    }

    void UpdateWeaponName()
    {
        GameManager.Instance.UI_controller.UpdateGun(this);
    }
}
