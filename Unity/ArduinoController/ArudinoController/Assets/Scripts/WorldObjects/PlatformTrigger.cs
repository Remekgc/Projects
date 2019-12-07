using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTrigger : MonoBehaviour {
    // This script is used to make ball respawn when it falls of the platform

    public bool enter = true;
	void Start () {
		
	}
	
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (enter)
        {
            print("Fail!");
            other.transform.position = new Vector3(0, 1, 0);
        }
    }
}
