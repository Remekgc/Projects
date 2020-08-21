using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI_Examples.AI_Physics 
{
    public class Shoot : MonoBehaviour
    {
        public GameObject shellPrefab;
        public GameObject shellSpawnPos;
        public GameObject target;
        public GameObject parent;
        public float speed = 15;
        public float turnSpeed = 2f;
        bool canShoot = true;


        float mass = 10;
        float force = 1000;

        void Start()
        {

        }

        void Update()
        {
            Vector3 direction = (target.transform.position - parent.transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            parent.transform.rotation = Quaternion.Slerp(parent.transform.rotation, lookRotation, Time.deltaTime * turnSpeed);

            float? angle = RotateTurret();

            if (angle != null && Vector3.Angle(direction, parent.transform.forward) < 10)
                StartCoroutine(Fire());
        }

        IEnumerator Fire()
        {
            if (canShoot)
            {
                GameObject shell = Instantiate(shellPrefab, shellSpawnPos.transform.position, shellSpawnPos.transform.rotation);
                shell.GetComponent<Rigidbody>().velocity = speed * transform.forward;
                canShoot = false;
                yield return new WaitForSeconds(1f);
                canShoot = true;
            }
        }

        float? RotateTurret()
        {
            float? angle = CalculateAngle(true);

            if (angle != null) 
                transform.localEulerAngles = new Vector3(360f - (float)angle, 0f, 0f);

            return angle;
        }

        float? CalculateAngle(bool low)
        {
            Vector3 targetDir = target.transform.position - transform.position;
            float y = targetDir.y;
            targetDir.y = 0f;
            float x = targetDir.magnitude;
            float gravity = 9.81f;
            float sSqrt = speed * speed;
            float underTheSqrRoot = (sSqrt * sSqrt) - gravity * (gravity * x * x + 2 * y * sSqrt);

            if (underTheSqrRoot >= 0f)
            {
                float root = Mathf.Sqrt(underTheSqrRoot);
                float highAngle = sSqrt + root;
                float lowAngle = sSqrt - root;

                float angle;

                if (low) 
                    angle = Mathf.Atan2(lowAngle, gravity * x) * Mathf.Rad2Deg;
                else 
                    angle = Mathf.Atan2(highAngle, gravity * x) * Mathf.Rad2Deg;

                //print(angle);
                return angle;
            }
            else
            {
                print("angle is null");
                return null;
            }
        }

    }
}
