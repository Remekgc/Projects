using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery_Pickable : Pickable
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            FlashLight flashLight = other.gameObject.GetComponent<FlashLight>();
            if (flashLight) flashLight.IncreseBattery(amount);

            Destroy(gameObject);
        }
    }

}
