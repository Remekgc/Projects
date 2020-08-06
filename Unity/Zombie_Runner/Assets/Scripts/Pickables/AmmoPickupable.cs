using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class AmmoPickupable : Pickable
{
    public AmmoType ammoType;

    void Awake()
    {
        GetComponent<BoxCollider>().isTrigger = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Inventory inventory = other.gameObject.GetComponent<Inventory>();

            if (inventory)
            {
                inventory.ammo.AddAmmo(amount, ammoType);
            }
            Destroy(gameObject);
        }
    }
}
