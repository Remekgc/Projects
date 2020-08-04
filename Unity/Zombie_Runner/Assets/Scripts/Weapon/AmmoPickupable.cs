using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class AmmoPickupable : MonoBehaviour
{
    public AmmoType ammoType;
    public int ammoAmount = 15;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Inventory inventory = other.gameObject.GetComponent<Inventory>();

            if (inventory)
            {
                inventory.ammo.AddAmmo(ammoAmount, ammoType);
            }
            Destroy(gameObject);
        }
    }
}
