using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI_WaypointsAndGraphs 
{
    public class FollowWaypoints : MonoBehaviour
    {
        public GameObject[] waypoints;
        int currentWP = 0;

        public float speed = 10f;
        public float rotationSpeed = 10f;
        public float lookAhead = 10f;

        GameObject tracker;

        void Start()
        {
            tracker = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            tracker.name = "Tracker for: " + gameObject.name;
            DestroyImmediate(tracker.GetComponent<Collider>());
            tracker.GetComponent<MeshRenderer>().enabled = false;
            tracker.transform.position = transform.position;
            transform.rotation = transform.rotation;
        }

        void ProgressTracker()
        {
            if (Vector3.Distance(tracker.transform.position, transform.position) > lookAhead) return;

            if (Vector3.Distance(tracker.transform.position, waypoints[currentWP].transform.position) < 3f)
            {
                currentWP++;
                if (currentWP >= waypoints.Length) currentWP = 0;
            }

            tracker.transform.LookAt(waypoints[currentWP].transform);
            tracker.transform.Translate(0, 0, (speed + 5) * Time.deltaTime);
        }

        void Update()
        {
            ProgressTracker();

            Quaternion lookAtWaypoint = Quaternion.LookRotation(tracker.transform.position - transform.position);

            transform.rotation = Quaternion.Slerp(transform.rotation, lookAtWaypoint, rotationSpeed * Time.deltaTime);
            transform.Translate(0, 0, speed * Time.deltaTime);
        }
    }
}

