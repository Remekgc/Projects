using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PcControls : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    public float Speed = 500;
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            playerRigidbody.AddForce(Vector3.forward  * Time.deltaTime * Speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            playerRigidbody.AddForce(Vector3.back * Time.deltaTime * Speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            playerRigidbody.AddForce(Vector3.left * Time.deltaTime * Speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerRigidbody.AddForce(Vector3.right * Time.deltaTime * Speed);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            playerRigidbody.AddForce(Vector3.up * 500 * Time.deltaTime);
        }
    }
}
