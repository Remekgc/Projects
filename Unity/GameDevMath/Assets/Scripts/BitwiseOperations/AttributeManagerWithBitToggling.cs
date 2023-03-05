using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BitwiseOperations 
{
    public class AttributeManagerWithBitToggling : AttributeManager
    {
        protected override void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(GameTag.MAGIC))
            {
                Attributes ^= MAGIC;
            }
            else if (other.gameObject.CompareTag(GameTag.INTELLIGENCE))
            {
                Attributes ^= INTELLIGENCE;
            }
            else if (other.gameObject.CompareTag(GameTag.CHARISMA))
            {
                Attributes ^= CHARISMA;
            }
            else if (other.gameObject.CompareTag(GameTag.FLY))
            {
                Attributes ^= FLY;
            }
            else if (other.gameObject.CompareTag(GameTag.INVISIBLE))
            {
                Attributes ^= INVISIBLE;
            }
            else if (other.gameObject.CompareTag(GameTag.ANTIMAGIC))
            {
                Attributes &= ~(MAGIC | FLY);
            }
            else if (other.gameObject.CompareTag(GameTag.GODMODE))
            {
                Attributes ^= (MAGIC | INTELLIGENCE | FLY | INVISIBLE);
            }
            else if (other.gameObject.CompareTag(GameTag.RESET))
            {
                Attributes = 0;
            }
        }
    }
}