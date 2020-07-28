using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperRifle_R : RaycastWeapon
{
    void OnEnable()
    {
        Invoke("UpdateWeaponName", 0.1f);
    }

    void UpdateWeaponName()
    {
        GameManager.Instance.UI_controller.UpdateGun(this);
    }
}
