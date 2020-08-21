using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

// A very simplistic car driving on the x-z plane.
namespace AI_Examples.AI_Math
{
    public class Drive : MonoBehaviour
    {
        public float speed = 10.0f;
        public float rotationSpeed = 100.0f;
        public bool autoPilot = false;
        public float stoppingDistance = 3f;

        public GameObject target;
        public float distance = Mathf.Infinity;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.T)) autoPilot = !autoPilot;

            if (!autoPilot) HandleControlInput();
            else if (autoPilot && distance > stoppingDistance) autoNavigateToTheTarget();
        }

        private void autoNavigateToTheTarget()
        {
            CalculateAngle();
            CalculateDistance();

            transform.Translate(transform.up * Time.deltaTime * speed, Space.World);
        }

        private void HandleControlInput()
        {
            // Get the horizontal and vertical axis.
            // By default they are mapped to the arrow keys.
            // The value is in the range -1 to 1
            float translation = Input.GetAxis("Vertical") * speed;
            float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

            // Make it move 10 meters per second instead of 10 meters per frame...
            translation *= Time.deltaTime;
            rotation *= Time.deltaTime;

            // Move translation along the object's z-axis
            transform.Translate(0, translation, 0);

            // Rotate around our y-axis
            transform.Rotate(0, 0, -rotation);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                CalculateDistance();
                CalculateAngle();
            }
        }

        void CalculateDistance()
        {
            Vector3 myPos = transform.position;
            Vector3 targetPos = target.transform.position;

            distance =
                Mathf.Sqrt(
                    Mathf.Pow(myPos.x - targetPos.x, 2) +
                    Mathf.Pow(myPos.y - targetPos.y, 2) +
                    Mathf.Pow(myPos.z - targetPos.z, 2));

            Debug.Log("Distance: " + distance);
            //Debug.Log(Vector3.Distance(myPos, targetPos)); // Check if the calculation is right
        }

        void CalculateAngle()
        {
            // d = dot product
            // d = V * W
            // V(2, 4) * W(3, 1) = 2 * 3 + 4 * 1 = 10

            // V(0, 4) * W(3, 0) = 0 * 3 + 4 * 0 = 0
            // V(-1, 5) * W(2, -1) = = -1 * 2 + 5 * -1 = -7

            /* Note:
             * less than 90 deg if V * W > 0
             * exactly 90 deg if V * W = 0
             * greater than 90 deg if V * W < 0
             */

            Vector3 myLookDir = transform.up; // this look direction vector
            Vector3 meToTargetDir = target.transform.position - transform.position; // vector from this to target

            Debug.DrawRay(transform.position, myLookDir * 10, Color.green, 2f);
            Debug.DrawRay(transform.position, meToTargetDir, Color.red, 2f);

            float dot = myLookDir.x * meToTargetDir.x + myLookDir.y * meToTargetDir.y;
            float angle = Mathf.Acos(dot / (myLookDir.magnitude * meToTargetDir.magnitude)); // 0 = cos^-1((V * W) / (||V||*||W||))
            angle *= Mathf.Rad2Deg; // Convert from radians to degrees

            Debug.Log("Angle: " + angle);
            //Debug.Log("Unity Angle: " + Vector3.Angle(myLookDir, meToTargetDir));

            int clockwise = 1;
            if (CrossProduct(myLookDir, meToTargetDir).z < 0) clockwise = -1;

            float unityAngle = Vector3.SignedAngle(myLookDir, meToTargetDir, transform.forward);

            float apRotationSpeed = (0.005f * rotationSpeed);

            if (autoPilot) transform.Rotate(0, 0, ((angle * clockwise) / apRotationSpeed) * Time.deltaTime);
            else transform.Rotate(0, 0, angle * clockwise);
            //transform.Rotate(0, 0, unityAngle);
        }

        Vector3 CrossProduct(Vector3 v, Vector3 w)
        {
            // Vector cross product = negative clockwise and positive anticlockwise
            /*When to use this ?
             * if you want to know on which side(left and right) the target is based on look direction
             */
            // Note: pattern xMult does not include x from the given vectors...
            float xMult = (v.y * w.z) - (v.z * w.y);
            float yMult = (v.z * w.x) - (v.x * w.z);
            float zMult = (v.x * w.y) - (v.y * w.x);

            return new Vector3(xMult, yMult, zMult);
        }

    }
}
