using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float distance = 100f;
    [SerializeField] int damage = 50;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.timeScale != 0)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, distance))
            {
                BaseStats hitObject = hit.collider.gameObject.GetComponent<BaseStats>();

                if (hitObject != null)
                {
                    Instantiate(hitObject.DecalOnHit, hit.point, Quaternion.identity);
                    hitObject.TakeDamage(new Damage(damage, gameObject));
                }
            }
        }
    }
}

