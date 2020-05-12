using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private protected Pathfinder pathfinder;
    [SerializeField] private protected Enemy enemy;
    [SerializeField] float movementPeriod = 0.5f;

    void Awake()
    {
        pathfinder = FindObjectOfType<Pathfinder>();
    }

    void Start()
    {
        var path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
    }

    IEnumerator FollowPath(List<Waypoint> path)
    {
        foreach (var waypoint in path)
        {
            yield return new WaitForSeconds(movementPeriod);
            transform.position = waypoint.transform.position + new Vector3(0, 1.5f, 0);
        }
    }
}
