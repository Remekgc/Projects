using UnityEngine;

public class WingMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Rotate(3f, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Rotate(-3f, 0f, 0f);
        }

    }
}
