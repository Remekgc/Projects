using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Player components")]
    [SerializeField] private protected PlayerBase playerBase;
    [Header("Main Parts")]
    [SerializeField] private protected GameObject parentObject;
    [Range(0, 100)] public int hp = 100;
    [Header("Particles")]
    [SerializeField] private protected ParticleSystem deathEffect;
    [SerializeField] private protected ParticleSystem hitEffect;
    [SerializeField] private protected ParticleSystem goalEffect;

    void Awake()
    {
        playerBase = FindObjectOfType<PlayerBase>();
        parentObject = transform.parent.gameObject;
    }

    void Start()
    {
        HealthBasedOnScore();
    }

    private void HealthBasedOnScore()
    {
        if (playerBase.score > 0)
        {
            hp += Mathf.RoundToInt(playerBase.score / 10);
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

        if (hp <= 0)
        {
            playerBase.AddScore(10);
            DeathSequence();
        }

        hitEffect.Play();
    }

}
