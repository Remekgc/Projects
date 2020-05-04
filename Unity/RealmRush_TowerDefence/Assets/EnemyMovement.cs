using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public List<Waypoint> path = new List<Waypoint>();
    void Start()
    {
        StartCoroutine(PrintAllWaypoints());
    }

    IEnumerator PrintAllWaypoints()
    {
        foreach (var waypoint in path)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(1f);
        }
        
    }
}
