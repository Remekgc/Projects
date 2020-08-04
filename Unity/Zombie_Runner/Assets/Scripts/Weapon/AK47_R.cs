using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK47_R : RaycastWeapon
{
    new void Start()
    {
        base.Start();
        ammo.AddAmmo(20, ammoType);
        damageAmount = 40;
    }
}
