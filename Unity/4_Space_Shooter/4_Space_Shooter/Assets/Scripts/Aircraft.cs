using UnityEngine;
using UnityEngine.SceneManagement;

public class Aircraft : MonoBehaviour
{

    [SerializeField] float speed = 100f;

    Rigidbody aircraft;
    // Start is called before the first frame update
    void Start()
    {
        aircraft = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        SpeedOptions();
        Rotation();
    }

    private void SpeedOptions()
    {
        aircraft.AddRelativeForce(Vector3.forward * speed);
        if (Input.GetKey(KeyCode.Space))
        {
            speed = 150;
        }
        else
        {
            speed = 50;
        }
    }

    private void Rotation()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Rotate(1f, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Rotate(-1f, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0f, 0f, -1f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0f, 0f, 1f);
        }
    }
}
