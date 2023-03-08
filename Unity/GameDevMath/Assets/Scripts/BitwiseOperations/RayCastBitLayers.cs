using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BitwiseOperations
{
    public class RayCastBitLayers : MonoBehaviour
    {
        private void Update()
        {
            int layerMask = (1 << 11) | (1 << 12);
            //layerMask = ~layerMask; // uncomment if you want to ignore these layers

            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 100f, layerMask))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);
                Debug.Log("Hit");
            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 100f, Color.red);
                Debug.Log("Miss");
            }
        }
    }
}
