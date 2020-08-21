using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI_Examples.AI_Math
{
    public class MoveToGoal : MonoBehaviour
    {
        public float speed = 2.0f;
        public float stoppingDistance = 2f;
        public Transform goal;

        void Start()
        {
            //transform.LookAt(goal.transform);
        }

        void LateUpdate()
        {
            transform.LookAt(goal.transform);

            Vector3 direction = goal.position - transform.position;
            Debug.DrawRay(transform.position, direction, Color.red);
            if (direction.magnitude > stoppingDistance) transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
            //print("Direction: " + direction + ", magnitude: " + direction.magnitude);
        }
    }
}
