using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSlot[] ammoSlots;

    [System.Serializable]
    private class AmmoSlot
    {
        public AmmoType ammoType;
        public int ammoAmount;
    }

    public int GetCurrentAmmo(AmmoType ammoType)
    {
        return GetAmmoSlot(ammoType).ammoAmount;
    }
    
    public void ReduceCurrentAmmo(AmmoType ammoType)
    {
        GetAmmoSlot(ammoType).ammoAmount--;
    }

    public void AddAmmo(int amount, AmmoType ammoType)
    {
        GetAmmoSlot(ammoType).ammoAmount += amount;
    }

    private AmmoSlot GetAmmoSlot(AmmoType ammoType)
    {
        foreach (AmmoSlot slot in ammoSlots)
        {
            if (ammoType == slot.ammoType)
            {
                return slot;
            }
        }
        return null;
    }
}
