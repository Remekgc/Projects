using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PcControls : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            playerRigidbody.AddForce(Vector3.forward * 10);
        }
        if (Input.GetKey(KeyCode.S))
        {
            playerRigidbody.AddForce(Vector3.back * 10);
        }
        if (Input.GetKey(KeyCode.A))
        {
            playerRigidbody.AddForce(Vector3.left * 10);
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerRigidbody.AddForce(Vector3.right * 10);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            playerRigidbody.AddForce(Vector3.up * 50);
        }
    }
}
