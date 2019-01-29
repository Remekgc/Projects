using UnityEngine;

public class MotorSpin : MonoBehaviour
{
    [SerializeField] float spinx = 0f;
    [SerializeField] float spiny = 0f;
    [SerializeField] float spinz = 0f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(spinx,spiny,spinz);
    }
}
