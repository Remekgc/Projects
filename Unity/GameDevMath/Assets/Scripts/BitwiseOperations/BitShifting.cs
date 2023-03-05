using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BitwiseOperations
{
    public class BitShifting : MonoBehaviour
    {
        private void Start()
        {
            // bit packing

            string A = "110111";
            string B = "10001";
            string C = "1101";

            int aBits = Convert.ToInt32(A, 2);
            int bBits = Convert.ToInt32(B, 2);
            int cBits = Convert.ToInt32(C, 2);

            int packed = 0;

            packed |= (aBits << 26);
            packed |= (bBits << 21);
            packed |= (cBits << 17);

            Debug.Log(Convert.ToString(packed, 2).PadLeft(32, '0'));

            A = "1111";
            B = "101";
            C = "11011";

            aBits = Convert.ToInt32(A, 2);
            bBits = Convert.ToInt32(B, 2);
            cBits = Convert.ToInt32(C, 2);

            packed = 0;

            packed |= (aBits << 28);
            packed |= (bBits << 25);
            packed |= (cBits << 20);

            Debug.Log(Convert.ToString(packed, 2).PadLeft(32, '0'));
        }
    }
}
