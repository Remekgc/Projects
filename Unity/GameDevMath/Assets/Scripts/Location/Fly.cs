using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vectors;

namespace Location
{
    public class Fly : MonoBehaviour
    {
        public enum ControlType
        {
            Rotation,
            Movement,
            Both
        }

        [SerializeField] ControlType controlType;
        [SerializeField] float rotationSpeed = 1f;
        [SerializeField] float speed = 1f;

        float x = 0f;
        float y = 0f;
        float z = 0f;
        float rotationZ = 0f;

        //[SerializeField] Vector3 a;
        //[SerializeField] Vector3 b;

        private void Update()
        {
            if (controlType == ControlType.Movement)
            {
                x = Input.GetAxis("Horizontal") * speed;
                y = Input.GetAxis("VerticalY") * speed;
                z = Input.GetAxis("Vertical") * speed;

                transform.position =
                    new Vector3(
                        transform.position.x + x,
                        transform.position.y + y,
                        transform.position.z + z);
            }
            else if (controlType == ControlType.Rotation)
            {
                x = Input.GetAxis("Vertical") * rotationSpeed;
                y = Input.GetAxis("Horizontal") * rotationSpeed;
                z = Input.GetAxis("HorizontalZ") * rotationSpeed;

                transform.Rotate(x, y, z);
            }
            else
            {
                x = Input.GetAxis("Vertical") * rotationSpeed;
                y = Input.GetAxis("Horizontal") * rotationSpeed;
                z = Input.GetAxis("HorizontalZ") * rotationSpeed;
                rotationZ = Input.GetAxis("VerticalY") * speed;

                transform.Translate(0f, 0f, rotationZ);
                transform.Rotate(x, y, z);
            }

            //if (Input.GetKeyDown(KeyCode.Return))
            //{
            //    Debug.Log($"Distance from a to b: {Vector3.Distance(a, b)}");
            //    Debug.Log($"Dot product of a and b: {VectorMath.Dot(new Coordinates(a), new Coordinates(b))}");
            //    Debug.Log($"Cross product of a and b: {VectorMath.CrossProduct(new Coordinates(a), new Coordinates(b)).Position}");
            //    Debug.Log($"Normalized a: {VectorMath.GetNormal(new Coordinates(a)).Position}");
            //    Debug.Log($"Normalized b: {VectorMath.GetNormal(new Coordinates(b)).Position}");
            //}
        }
    }
}

