using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] GameObject bulletExplosion;

    private void Start()
    {
        Destroy(gameObject, 2f);
    }

    private void OnDestroy()
    {
       Destroy(Instantiate(bulletExplosion, transform.position, transform.rotation), 3f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
