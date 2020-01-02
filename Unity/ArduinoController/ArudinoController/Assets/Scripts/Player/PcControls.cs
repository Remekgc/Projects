using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PcControls : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    private bool canJump;
    public float speed = 1000;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        ManageInput();
    }

    private void ManageInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            playerRigidbody.AddForce(Vector3.forward * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            playerRigidbody.AddForce(Vector3.back * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            playerRigidbody.AddForce(Vector3.left * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerRigidbody.AddForce(Vector3.right * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.Space) && canJump == true)
        {
            playerRigidbody.AddForce(Vector3.up * 50000 * Time.deltaTime);
            canJump = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Enemy":
                Player.Instance.RemoveLife();
                break;
            case "Ground":
                canJump = true;
                break;
            default:
                //do nothing.
                break;
        }
    }

    private void OnTriggerEnter(Collider trigger)
    {
        switch (trigger.gameObject.tag)
        {
            case "ForbiddenArea":
                transform.position = new Vector3(0, 1, transform.position.z);
                break;
            default:
                //do nothing.
                break;
        }
    }

}

