using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    // Start is called before the first frame update

    public List<GameObject> tilePrefabs = new List<GameObject>();

    private List<GameObject> activeTiles = new List<GameObject>();
    private Transform playerTransform;
    private float spawnZ = -66f, safeZone = 150f;
    private float tileLength = 111f;
    private int amountOfTiles = 6;

    void Start()
    {
        playerTransform = Player.Instance.gameObject.transform;
        for (int i = 0; i < amountOfTiles; i++)
        {
            SpawnTile();
        }
    }

    void Update()
    {
        if (playerTransform.position.z - safeZone > (spawnZ - amountOfTiles * tileLength))
        {
            SpawnTile();
            DeleteTile();
        }
    }

    void SpawnTile()
    {
        activeTiles.Add(Instantiate(tilePrefabs[0], Vector3.forward * spawnZ, Quaternion.identity , transform));
        spawnZ += tileLength;
    }

    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.Remove(activeTiles[0]);
    }

}
    