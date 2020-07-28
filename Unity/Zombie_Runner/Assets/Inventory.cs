using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] RaycastWeapon activeWeapon;

    [SerializeField] List<RaycastWeapon> weapons = new List<RaycastWeapon>();

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (weapons[0])
            {
                SwapWeapon(weapons[0]);
            }
            else
            {
                activeWeapon.gameObject.SetActive(false);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (weapons[1])
            {
                SwapWeapon(weapons[1]);
            }
            else
            {
                activeWeapon.gameObject.SetActive(false);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (weapons[2])
            {
                SwapWeapon(weapons[2]);
            }
            else
            {
                activeWeapon.gameObject.SetActive(false);
            }
        }
    }

    private void SwapWeapon(RaycastWeapon weapon)
    {
        foreach (var raycastWeapon in weapons)
        {
            if (raycastWeapon)
            {
                raycastWeapon.gameObject.SetActive(false);
            }   
        }
        activeWeapon = weapon;
        weapon.gameObject.SetActive(true);
    }
}
