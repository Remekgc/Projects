using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public static CameraFollow Instance { get; private set; }
    public Transform target;
    public float smoothSpeed = 10f;
    public Vector3 offset;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

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
