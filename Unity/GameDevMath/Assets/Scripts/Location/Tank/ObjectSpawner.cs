using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Location.Tank
{
    public class ObjectSpawner : MonoBehaviour
    {
        [field: SerializeField] public GameObject SpawnedObject { get; protected set; }
        [field: SerializeField] public GameObject Clone { get; protected set; }

        private void Start()
        {
            Vector3 fuelSpawnPosition = new Vector3(Random.Range(-100, 100), Random.Range(-100, 100), SpawnedObject.transform.position.z);
            Clone = Instantiate(SpawnedObject, fuelSpawnPosition, Quaternion.identity);

            Debug.Log($"{SpawnedObject.gameObject.name} location: {fuelSpawnPosition}");
        }
    }
}
