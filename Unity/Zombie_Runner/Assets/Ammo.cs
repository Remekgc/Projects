using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] int ammoAmmount = 10;

    public int GetCurrentAmmo()
    {
        return ammoAmmount;
    }
    
    public void ReduceCurrentAmmo()
    {
        ammoAmmount--;
    }

    public void AddAmmo(int amount)
    {
        ammoAmmount += amount;
    }
}
