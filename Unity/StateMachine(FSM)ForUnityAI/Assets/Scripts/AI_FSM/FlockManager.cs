using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FlockManager : MonoBehaviour
{
    [SerializeField] private GameObject fishPrefab;
    public int FishNumber = 20;
    public List<Flock> allFish = new List<Flock>();
    public Vector3 swimLimits = new Vector3(5, 5, 5);
    public Vector3 goalPos = new Vector3(5, 5, 5);

    [Header("Fish Settings")]
    [Range(0.0f, 10.0f)]
    public float minSpeed = 2f;
    [Range(0.0f, 10.0f)]
    public float maxSpeed = 3f;
    [Range(0.0f, 20.0f)]
    public float neighbourDistance = 0f; // agent will calculate it's path based on other agents in this range.
    [Range(0.0f, 10.0f)]
    public float rotationSpeed = 2f;

    void Start()
    {
        for(int i = 0; i < FishNumber; i++)
        {
            Vector3 pos = transform.position + new Vector3(Random.Range(-swimLimits.x, swimLimits.x),
                                                           Random.Range(-swimLimits.y, swimLimits.y),
                                                           Random.Range(-swimLimits.z, swimLimits.z));
            
            allFish.Add(Instantiate(fishPrefab, pos, Quaternion.identity).GetComponent<Flock>());
            allFish[i].myManager = this;
        }
    }

    void Update()
    {
        if (Random.Range(0, 100) < 10)
        {
            goalPos = transform.position + new Vector3(Random.Range(-swimLimits.x, swimLimits.x),
                                           Random.Range(-swimLimits.y, swimLimits.y),
                                           Random.Range(-swimLimits.z, swimLimits.z));
        }
    }


}
