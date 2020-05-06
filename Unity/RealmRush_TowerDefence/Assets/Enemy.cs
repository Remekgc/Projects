using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected internal GameObject parentObject;
    [SerializeField] protected internal GameObject explosion;

    [Range(0, 100)] public int hp = 100;

    void Update()
    {
        if(hp <= 0)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(parentObject);
        }
    }

    void OnParticleCollision(GameObject other)
    {
        hp--;
    }

}
