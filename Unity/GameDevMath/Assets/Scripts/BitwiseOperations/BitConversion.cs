using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BitwiseOperations
{
    public class BitConversion : MonoBehaviour
    {
        [SerializeField] int bitSequence = 0;

        private void Start()
        {
            Debug.Log($"{DebugTag.BitwiseOperation}{Convert.ToString(bitSequence, 2)}");
        }
    }
}
