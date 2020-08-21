using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI_Examples.FSM
{
    public sealed class World
    {
        private static World instance;
        public GameObject[] HidingSpots { get; private set; }

        public static World Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new World();
                    instance.HidingSpots = GameObject.FindGameObjectsWithTag("hide");
                    Debug.Log("hiding spots: " + instance.HidingSpots.Length);
                }
                return instance;
            }
        }

    }
}

