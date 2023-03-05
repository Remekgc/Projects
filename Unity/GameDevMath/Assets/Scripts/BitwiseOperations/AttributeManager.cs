using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BitwiseOperations 
{
    public class AttributeManager : MonoBehaviour
    {
        public readonly static int MAGIC = 16;
        public readonly static int INTELLIGENCE = 8;
        public readonly static int CHARISMA = 4;
        public readonly static int FLY = 2;
        public readonly static int INVISIBLE = 1;

        [SerializeField] Text attributeDisplay;
        [field: SerializeField] public int Attributes { get; protected set; } = 0;

        void Update()
        {
            Vector3 screenPoint = Camera.main.WorldToScreenPoint(this.transform.position);

            attributeDisplay.transform.position = screenPoint + new Vector3(0, -55, 0);
            attributeDisplay.text = Convert.ToString(Attributes, 2).PadLeft(8, '0');
        }

        protected virtual void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(GameTag.MAGIC))
            {
                Attributes |= MAGIC;
            }
            else if (other.gameObject.CompareTag(GameTag.INTELLIGENCE))
            {
                Attributes |= INTELLIGENCE;
            }
            else if (other.gameObject.CompareTag(GameTag.CHARISMA))
            {
                Attributes |= CHARISMA;
            }
            else if (other.gameObject.CompareTag(GameTag.FLY))
            {
                Attributes |= FLY;
            }
            else if (other.gameObject.CompareTag(GameTag.INVISIBLE))
            {
                Attributes |= INVISIBLE;
            }
            else if (other.gameObject.CompareTag(GameTag.ANTIMAGIC))
            {
                Attributes &= ~(MAGIC | FLY);
            }
            else if (other.gameObject.CompareTag(GameTag.GODMODE))
            {
                Attributes |= (MAGIC | INTELLIGENCE | FLY | INVISIBLE);
            }
            else if (other.gameObject.CompareTag(GameTag.RESET))
            {
                Attributes = 0;
            }
        }
    }
}