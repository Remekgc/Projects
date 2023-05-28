using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vectors;

namespace Location
{
    public class DriveV2 : MonoBehaviour
    {
        [SerializeField] float speed = 10f;
        [SerializeField] float rotationSpeed = 100f;
        [SerializeField] bool useUnityMath = false;

        private void Update()
        {
            if (useUnityMath)
            {
                MoveWithUnityMath();
            }
            else
            {
                MoveWithCustomMath();
            }
        }

        void MoveWithUnityMath()
        {
            float translation = Input.GetAxis("Vertical") * speed;
            float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

            translation *= Time.deltaTime;
            rotation *= Time.deltaTime;

            transform.Translate(0, translation, 0);
            transform.Rotate(0, 0, -rotation);
        }

        void MoveWithCustomMath()
        {
            float translation = Input.GetAxis("Vertical") * speed;
            float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

            translation *= Time.deltaTime;
            rotation *= Time.deltaTime;
            float radianRotation = rotation * Mathf.Deg2Rad;

            //transform.Translate(0, translation, 0);
            //transform.Rotate(0, 0, -rotation);

            transform.position = VectorMath.Translate(
                new Coordinates(transform.position),
                new Coordinates(transform.up),
                new Coordinates(0f, translation, 0f)).Position;

            transform.up = VectorMath.Rotate(new Coordinates(transform.up), radianRotation, true).Position;
        }
    }
}

