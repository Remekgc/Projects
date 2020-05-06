using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    // ok to be public as is data class
    public bool isExplored = false;
    public bool isExludedFromPathfinding = false;
    public Waypoint exploredFrom;

    [Tooltip("Size of the grid that the object will snap into")] [SerializeField] [Range(1, 20)] int gridSize = 10;

    public int GetGridSize()
    {
        return gridSize;
    }

    public Vector3Int GetGridPos()
    {
        return new Vector3Int(
            Mathf.RoundToInt(transform.position.x / gridSize),
            Mathf.RoundToInt(transform.position.y / gridSize),
            Mathf.RoundToInt(transform.position.z / gridSize) 
            );
    }

    public void SetTopColor(Color color)
    {
        MeshRenderer topMeshRenderer = transform.Find("Label").GetComponent<MeshRenderer>();
        topMeshRenderer.material.color = color;
    }
}
