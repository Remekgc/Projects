using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<EnemyMovement> enemy = new List<EnemyMovement>();
    [SerializeField] private protected Vector3 spawnPossition;
    [Header("Spawn rate of the enemies with random number from spawnRateFrom to spwanRateTo")]
    [SerializeField] float spawnRateFrom = 1f;
    [SerializeField] float spwanRateTo = 5f;

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
            yield return new WaitForSeconds(Random.Range(spawnRateFrom, spwanRateTo));
        }

    }
}
