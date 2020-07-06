using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] private protected int towerLimit = 5;
    [SerializeField] private protected Tower towerPrefab;
    Queue<Tower> towers = new Queue<Tower>();

    public void SpawnTower(Waypoint box)
    {
        if (towers.Count < towerLimit)
        {
            Tower tower = Instantiate(towerPrefab, box.transform.position + new Vector3(0, 5, 0), Quaternion.identity, transform);
            towers.Enqueue(tower);
            tower.box = box;
            box.isPleaceble = false;
        }
        else
        {
            MoveTower(box);
        }
    }

    private void MoveTower(Waypoint box)
    {
        box.isPleaceble = false;

        Tower tower = towers.Dequeue();
        tower.transform.position = box.transform.position + new Vector3(0, 5, 0);
        tower.box.isPleaceble = true;
        tower.box = box;

        towers.Enqueue(tower);
    }
}
