using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public List<GameObject> enemiesToSpawn = new List<GameObject>();

    public float spawnInterval = 2f;

    public bool autoStart = true;
    public bool spawnEnabled = true;

    void Start()
    {
        if (autoStart) StartCoroutine(ISpawnEnemies());
    }

    IEnumerator ISpawnEnemies()
    {
        while (true)
        {
            if (spawnEnabled)
            {
                foreach (GameObject enemy in enemiesToSpawn)
                {
                    Instantiate(enemy, transform.position, Quaternion.identity, transform.parent);
                    yield return new WaitForSeconds(spawnInterval);
                }
            }
            yield return new WaitForSeconds(1f);
        }
    }

}
