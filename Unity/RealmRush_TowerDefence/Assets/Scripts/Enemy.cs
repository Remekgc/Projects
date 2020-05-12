using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Main Parts")]
    [SerializeField] private protected GameObject parentObject;
    [Range(0, 100)] public int hp = 100;
    [Header("Particles")]
    [SerializeField] private protected ParticleSystem deathEffect;
    [SerializeField] private protected ParticleSystem hitEffect;
    [SerializeField] private protected ParticleSystem goalEffect;

    void Awake()
    {
        parentObject = transform.parent.gameObject;
    }

    void Update()
    {
        if(hp <= 0)
        {
            DeathSequence();
        }
    }

    private void DeathSequence()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(parentObject);
    }

    public void GoalSequence()
    {
        Instantiate(goalEffect, transform.position, Quaternion.identity);
        Destroy(parentObject);
    }

    void OnParticleCollision(GameObject other)
    {
        hp--;
        hitEffect.Play();
    }

}
