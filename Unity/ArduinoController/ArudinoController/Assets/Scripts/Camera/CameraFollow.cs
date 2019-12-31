using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target;
    public float smoothSpeed = 10f;
    public Vector3 offset;

	void Start () {
        target = GameObject.Find("Player").transform;
	}
	
    // If LateUpdate won't be smooth use Fixed or Normal Update insted.
    void FixedUpdate()
    {
        Vector3 desierdPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desierdPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}
