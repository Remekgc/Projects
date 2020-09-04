using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI_Examples.FSM
{
    public sealed class World
    {
        private static World instance;
        public List<HideSpot> HidingSpots { get; private set; } = new List<HideSpot>();

        public static World Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new World();
                    List<GameObject> spots = new List<GameObject>();
                    spots.AddRange(GameObject.FindGameObjectsWithTag("hide"));

                    for (int i = 0; i < spots.Count; i++)
                    {
                        Collider spot = spots[i].GetComponent<Collider>();
                        instance.HidingSpots.Add(new HideSpot(spot.gameObject, spot.transform, spot));
                    }
                }
                return instance;
            }
        }
    }

    public struct HideSpot
    {
        public GameObject gameObject { get; }
        public Transform transform { get; }
        public Collider collider { get; }

        public HideSpot(GameObject gameObject, Transform transform, Collider collider)
        {
            this.gameObject = gameObject;
            this.transform = transform;
            this.collider = collider;
        }
    }
}

