using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    // ok to be public as is data class
    public bool isExplored = false;
    public bool isPleaceble = true;
    public Waypoint exploredFrom;

    [SerializeField] private protected TowerFactory towerFactory;

    [Tooltip("Size of the grid that the object will snap into")] [SerializeField] [Range(1, 20)] int gridSize = 10;

    void Awake()
    {
        towerFactory = FindObjectOfType<TowerFactory>();
    }

    void OnMouseOver()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (isPleaceble)
            {
                towerFactory.SpawnTower(this);
            }
        }
    }

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
