using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]

public class CubeEditor : MonoBehaviour
{
    Waypoint waypoint;

    void Awake()
    {
        waypoint = gameObject.GetComponent<Waypoint>();
        //GameObject.Find("Enemy").GetComponent<EnemyMovement>().path.Add(GetComponent<Waypoint>());
    }

    void Update()
    {
        SnapToGrid();
        UpdateLabel();
    }

    private void SnapToGrid()
    {
        int gridSize = waypoint.GetGridSize();
        transform.position = new Vector3(
            waypoint.GetGridPos().x * gridSize,
            waypoint.GetGridPos().y * gridSize,
            waypoint.GetGridPos().z * gridSize
            );
    }

    private void UpdateLabel()
    {
        float x = transform.position.x / 10;
        float y = transform.position.y / 10;
        float z = transform.position.z / 10;
        GetComponentInChildren<TextMesh>().text = x + "," + z;
        gameObject.name = "(" + x + "," + y + "," + z + ")";
    }
}
