using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTrigger : MonoBehaviour {
    // This script is used to make ball respawn when it falls of the platform

    public bool enter = true;
    private void OnTriggerEnter(Collider other)
    {
        if (enter)
        {
            print("Player lifes left" + Player.Instance.Lifes);
            other.transform.position = new Vector3(0, 1, 0);
        }
    }
}
