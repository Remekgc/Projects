using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Tooltip("Explosion effect")] [SerializeField] GameObject explosion;
    [Tooltip("Transform of a gameobject that is supposed to be a parent of explosion when it spawns")] [SerializeField] Transform explosionParent;
    [SerializeField] int scorePerHit = 12;
    [SerializeField] int hp = 5;

    ScoreBoard scoreBoard;

    void Awake()
    {
        scoreBoard = GameObject.Find("Canvas/Score/ScoreAmount").GetComponent<ScoreBoard>();
        print(scoreBoard.name);
    }

    void Start()
    {
        AddNonTriggerBoxCollider();
    }

    private void AddNonTriggerBoxCollider()
    {
        BoxCollider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
        boxCollider.size = new Vector3(20, 5, 17);
    }

    void OnParticleCollision(GameObject other)
    {
        print("particles collided with enemy" + gameObject.name);

        hp--;
        scoreBoard.ScoreHit(scorePerHit);

        if (hp <= 0)
        {
            DeathEffects();
            Destroy(gameObject);
        }
    }

    private void DeathEffects()
    {
        explosion = Instantiate(explosion, transform.position, Quaternion.identity, explosionParent);
        explosion.SetActive(true);
        Destroy(explosion, 5f);
    }
}
