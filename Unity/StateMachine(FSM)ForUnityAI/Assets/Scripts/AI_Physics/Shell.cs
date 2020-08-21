using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI_Examples.AI_Physics
{
    public class Shell : MonoBehaviour
    {
        public GameObject explosion;
        Rigidbody rb;
        //public float speed = 1f;
        //float mass = 10f;
        //float force = 500f;
        //float acceleration;
        //float speedZ;
        //float speedY;
        //float gravity = -9.8f;
        //float gAccel;

        void Awake()
        {
            if (!rb) rb = GetComponent<Rigidbody>();
        }

        void OnCollisionEnter(Collision col)
        {
            if (col.gameObject.tag == "tank")
            {
                GameObject exp = Instantiate(explosion, this.transform.position, Quaternion.identity);
                Destroy(exp, 0.5f);
                Destroy(this.gameObject);
            }
        } 

        void LateUpdate()
        {
            //acceleration = force / mass;
            //speedZ += acceleration * Time.deltaTime;

            //gAccel = gravity / mass;
            //speedY += gAccel * Time.deltaTime;

            //transform.Translate(0, speedY, speedZ);
            //force = 0;
            transform.forward = rb.velocity;
        }
    }
}

