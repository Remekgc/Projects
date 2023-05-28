using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Location.Tank
{
    public class TankCamera : MonoBehaviour
    {
        [SerializeField] Transform tank;
        [SerializeField] Vector3 offset;

        private void Update()
        {
            transform.position = tank.position + offset;
        }
    }
}
