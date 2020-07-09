using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<EnemyMovement> enemy = new List<EnemyMovement>();
    [SerializeField] private protected Vector3 spawnPossition;
    [Header("Spawn components")]
    [SerializeField] float spawnRateFrom = 1f;
    [SerializeField] float spwanRateTo = 5f;
    [SerializeField] private protected AudioClip spawnEnemySFX;
    [SerializeField] private protected AudioSource audioSource;

    void Start()
    {
        StartCoroutine(ISpawnEnemy());
    }

    private void SpawnEnemy(EnemyMovement enemy)
    {
        Instantiate(enemy, spawnPossition, Quaternion.identity, transform);
    }

    IEnumerator ISpawnEnemy()
    {
        while (true)
        {
            SpawnEnemy(enemy[0]);
            audioSource.PlayOneShot(spawnEnemySFX);
            yield return new WaitForSeconds(Random.Range(spawnRateFrom, spwanRateTo));
        }

    }
}
