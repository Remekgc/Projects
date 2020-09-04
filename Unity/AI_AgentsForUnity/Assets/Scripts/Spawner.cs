using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UIElements;

[System.Serializable]
public struct SpawnObject
{
    public string name;
    public GameObject objectToSpawn;
    public float interval;
    public int amount;
}

public class Spawner : MonoBehaviour
{
    [SerializeField] List<SpawnObject> objectsToSpawn = new List<SpawnObject>();
    [SerializeField] bool spawnEnabled = false;
    [Range(0f, 100f)] [SerializeField] float spawnRange = 5f;

    void Start()
    {
        Spawn();
    }

    void Spawn()
    {
        foreach (SpawnObject spawnObject in objectsToSpawn)
        {
            StartCoroutine(ISpawn(spawnObject));
        }
    }

    IEnumerator ISpawn(SpawnObject spawnMe)
    {
        while (spawnMe.amount > 0)
        {
            if (spawnEnabled)
            {
                Vector3 spawnPoint =
                    new Vector3 
                    (
                        Random.Range(transform.position.x - spawnRange, transform.position.x + spawnRange),
                        0,
                        Random.Range(transform.position.z - spawnRange, transform.position.z + spawnRange)
                    );

                Instantiate(spawnMe.objectToSpawn, spawnPoint, Quaternion.identity);
                spawnMe.amount--;
            }
            yield return new WaitForSeconds(spawnMe.interval);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, spawnRange);
    }

}
