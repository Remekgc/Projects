using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BitwiseOperations 
{
    public class BitMaskDoor : MonoBehaviour
    {
        [SerializeField] int doorType = 0;

        private void OnCollisionEnter(Collision collision)
        {
            if (CanEnter(collision))
            {
                this.GetComponent<Collider>().isTrigger = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            this.GetComponent<Collider>().isTrigger = false;
        }

        private bool CanEnter(Collision collision)
        {
            return (collision.gameObject.GetComponent<AttributeManager>().Attributes & doorType) != 0;
        }
    }
}
