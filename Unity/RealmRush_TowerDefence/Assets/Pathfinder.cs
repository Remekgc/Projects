using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    Dictionary<Vector3Int, Waypoint> grid = new Dictionary<Vector3Int, Waypoint>();
    [Tooltip("Start and End Points for the player on the grid")] public Waypoint startPoint, endPoint;
    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    void Start()
    {
        LoadBlocks();
        ColorStartAndEnd();
        ExploreNeighbours();
    }

    void ColorStartAndEnd()
    {
        startPoint.SetTopColor(Color.yellow);
        endPoint.SetTopColor(Color.red);
    }

    private void LoadBlocks()
    {
        Waypoint[] waypoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint waypoint in waypoints)
        {
            // overlaping blocks?
            bool isOverlaping = grid.ContainsKey(waypoint.GetGridPos());
            // add to dictionary
            if (isOverlaping)
            {
                print("Object Overlaping" + waypoint);
            }
            else
            {
                grid.Add(waypoint.GetGridPos(), waypoint);
                //waypoint.SetTopColor(Color.gray);
            }            
        }
        print(grid.Count);
    }

    void ExploreNeighbours()
    {
        foreach (Vector2Int direction in directions)
        {
            print(direction);
        }
    }
}
