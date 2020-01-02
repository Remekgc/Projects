using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerObstacles : MonoBehaviour
{
    public List<GameObject> obstaclePrefabs = new List<GameObject>();
    public float spawnZ = 20f;
    public int numberOfObstacles = 15;

    private List<GameObject> activeObstacles = new List<GameObject>();
    private Transform playerTransform;

    void Start()
    {
        playerTransform = Player.Instance.transform;
        for (int i = 0; i < numberOfObstacles; i++)
        {
            activeObstacles.Add(Instantiate(obstaclePrefabs[0], new Vector3(Random.Range(-3.5f, 3.5f),Random.Range(1f, 2f), spawnZ), Quaternion.identity, transform));
            activeObstacles[i].transform.localScale += new Vector3(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            spawnZ += Random.Range(10f,20f);
        }

    }

    void Update()
    {
        if (playerTransform.position.z - 50 > (spawnZ - numberOfObstacles * 10))
        {
            SpawnObstacle();
            DeleteObstacle();
        }
    }

    private void SpawnObstacle()
    {
        GameObject obstacle = Instantiate(obstaclePrefabs[0], new Vector3(Random.Range(-3.5f, 3.5f), Random.Range(1f, 2f), spawnZ), Quaternion.identity, transform);
        activeObstacles.Add(obstacle);
        obstacle.transform.localScale += new Vector3(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        spawnZ += Random.Range(10f, 20f);
    }

    private void DeleteObstacle()
    {
        Destroy(activeObstacles[0]);
        activeObstacles.Remove(activeObstacles[0]);
    }
}
