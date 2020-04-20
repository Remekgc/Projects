using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [Tooltip("Praticle gameobject on Player")][SerializeField] GameObject explosion;

    [Tooltip("Level load delay in seconds")][SerializeField] float levelLoadDelay = 1f;
    float DeathTime;

    void Start()
    {
        DeathTime = Time.time + 10f;
        print(DeathTime);
        print(Time.time);
    }

    void OnCollisionEnter(Collision collision)
    {
        print("Bam!");
        StartDeathSequence();
    }

    void OnTriggerEnter(Collider other)
    {
        print("Triggered!!!");
        if (DeathTime < Time.time)
        {
            print(DeathTime + ">" + Time.time);
            StartDeathSequence();
        }
    }

    void StartDeathSequence()
    {
        SendMessage("OnPlayerDeath");
        explosion.SetActive(true);
        Invoke("ReloadScene", levelLoadDelay);
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(1);
    }
}
