using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI_Examples.AI_Physics
{
    public class DestroyShell : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            Destroy(this.gameObject, 3);
        }

    }
}
