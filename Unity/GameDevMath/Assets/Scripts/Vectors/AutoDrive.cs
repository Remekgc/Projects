using Location;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Vectors
{
    public class AutoDrive : MonoBehaviour
    {
        [SerializeField] float speed = 1.0f;
        [SerializeField] float stoppingDistance = 1.0f;
        [SerializeField] Transform target;
        [SerializeField] bool useCustomMath = true;

        Vector3 direction;

        Coordinates coordinates;

        private void Start()
        {
            direction = VectorMath.GetNormal(new Coordinates(target.position - transform.position)).Position;

            Vector3 rotation = VectorMath.LookAt2D(
                new Coordinates(transform.up),
                new Coordinates(transform.position),
                new Coordinates(target.position)).Position;

            transform.up = rotation;
        }

        private void Update()
        {
            if (useCustomMath)
            {
                CustomMath();
            }
            else
            {
                UnityMath();
            }
        }

        void CustomMath()
        {
            if (VectorMath.Distance(new Coordinates(transform.position), new Coordinates(target.transform.position)) > stoppingDistance)
            {
                transform.position += (direction * speed) * Time.deltaTime;
            }
        }

        void UnityMath()
        {
            if (Vector3.Distance(transform.position, target.transform.position) > stoppingDistance)
            {
                transform.position += (direction * speed);
            }
        }
    }
}
