using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [Tooltip("Start and End Points for the player on the grid")] public Waypoint startPoint, endPoint;
    [SerializeField] bool isRunning = true; // todo make private
     
    Dictionary<Vector3Int, Waypoint> grid = new Dictionary<Vector3Int, Waypoint>();
    Queue<Waypoint> waypointQueue = new Queue<Waypoint>();
    Waypoint searchCenter;
    public List<Waypoint> path = new List<Waypoint>(); // todo make private

    Vector3Int[] directions =
    {
        new Vector3Int(0, 0, 1),
        Vector3Int.right,
        new Vector3Int(0, 0, -1),
        Vector3Int.left
    };

    public List<Waypoint> GetPath()
    {
        if (path.Count == 0)
        {
            CalculatePath();
        }
        return path;
    }

    private void CalculatePath()
    {
        //ColorStartAndEnd();
        LoadBlocks();
        BreadthFirstSearch();
        CreatePath();
    }

    private void BreadthFirstSearch()
    {
        waypointQueue.Enqueue(startPoint);

        while (waypointQueue.Count > 0 && isRunning)
        {
            searchCenter = waypointQueue.Dequeue();
            //print("Searching from " + searchCenter); // todo Remove log
            StopIfEndFound();
            ExploreNeighbours();
            searchCenter.isExplored = true;
        }
    }

    private void StopIfEndFound()
    {
        if (searchCenter == endPoint)
        {
            isRunning = false;
            //print("End point found");
        }
    }

    void ExploreNeighbours()
    {
        if (!isRunning)
        {
            return;
        }
        foreach (Vector3Int direction in directions)
        {
            Vector3Int neighbourCoordinates = searchCenter.GetGridPos() + direction;
            if (grid.ContainsKey(neighbourCoordinates))
            {
                QueueNewNeighbours(neighbourCoordinates);
            }
            //try
            //{
            //    QueueNewNeighbours(neighbourCoordinates);
            //}
            //catch
            //{
            //    // check if function works properly
            //    //print("Error, block at " + explorationCoordinates + " not found.");
            //}
        }
    }

    private void QueueNewNeighbours(Vector3Int neighbourCoordinates)
    {
        Waypoint neighbour = grid[neighbourCoordinates];
        if (!neighbour.isExplored && !waypointQueue.Contains(neighbour))
        {
            waypointQueue.Enqueue(neighbour);
            neighbour.exploredFrom = searchCenter;
            //print("Queueing" + neighbour);
        }
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
            if (isOverlaping || waypoint.isExludedFromPathfinding)
            {
                //print("Object not indluded in the navigation grid" + waypoint);
            }
            else
            {
                grid.Add(waypoint.GetGridPos(), waypoint);
                //waypoint.SetTopColor(Color.gray);
            }
        }
    }

    void CreatePath()
    {
        path.Add(endPoint);

        Waypoint previous = endPoint.exploredFrom;
        while (previous != startPoint)
        {
            path.Add(previous);
            previous = previous.exploredFrom;
        }

        path.Add(startPoint);
        path.Reverse();
    }
}
