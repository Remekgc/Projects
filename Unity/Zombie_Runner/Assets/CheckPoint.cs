using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public bool finalCheckPoint = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.name == GameManager.Instance.playerObjectName && finalCheckPoint)
        {
            GameManager.Instance.LevelComplete();
        }
    }
}
