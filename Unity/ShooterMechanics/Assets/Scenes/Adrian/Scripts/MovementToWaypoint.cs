using UnityEngine;

public class MovementToWaypoint : MonoBehaviour
{
    [SerializeField]
    private GameObject[] waypoints;
    [SerializeField]
    private Transform playerCamera;

    private float timeToMoveToAnotherWaypoint;
    private int currentWaypoint;
    private bool makeAllWaypointTimersZero;

    [SerializeField]
    private float rotationSpeed = 1f;
    [SerializeField]
    private float movementSpeed = 1f;

    void Start()
    {
        Time.timeScale = 0;
        currentWaypoint = 0;
        playerCamera = GetComponent<Camera>().transform;
        timeToMoveToAnotherWaypoint = waypoints[currentWaypoint].GetComponent<Waypoint>().TimeToWait;
    }

    void Update()
    {
        MoveToAnotherWaypoint();
    }

    void MoveToAnotherWaypoint()
    {
        if(Vector3.Distance(playerCamera.position, waypoints[currentWaypoint].transform.position) > 0.3f)
        {
            if(waypoints[currentWaypoint].GetComponent<Waypoint>().ShouldRotateTowards)
            {
                Vector3 direction = waypoints[currentWaypoint].transform.position - playerCamera.position;
                Quaternion toRotation = Quaternion.LookRotation(direction);
                playerCamera.transform.rotation = Quaternion.Lerp(playerCamera.rotation, toRotation, rotationSpeed * Time.deltaTime);
            }
            playerCamera.position = Vector3.MoveTowards(playerCamera.position, waypoints[currentWaypoint].transform.position, Time.deltaTime * movementSpeed);
            if (!makeAllWaypointTimersZero)
            {
                timeToMoveToAnotherWaypoint = waypoints[currentWaypoint].GetComponent<Waypoint>().TimeToWait;
            }else
            {
                timeToMoveToAnotherWaypoint = 0f;
            }
        }else
        {
            timeToMoveToAnotherWaypoint -= Time.deltaTime;
        }
        if (timeToMoveToAnotherWaypoint < 0f)
        {
            currentWaypoint++;
            if(currentWaypoint == waypoints.Length)
            {
                currentWaypoint = 0;
            }
        }
    }

    public void SetWaitTimeOnWaypointToZero()
    {
        makeAllWaypointTimersZero = true;
        Time.timeScale = 1;
    }

    public void SetWaitTimeOnWaypointToNormal()
    {
        makeAllWaypointTimersZero = false;
        Time.timeScale = 1;
    }
}
