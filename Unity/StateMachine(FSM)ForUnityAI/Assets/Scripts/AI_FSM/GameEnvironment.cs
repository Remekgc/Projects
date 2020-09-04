using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace AI_Examples.FSM
{
    public sealed class GameEnvironment
    {
        private static GameEnvironment instance;

        public List<GameObject> CheckPoints { get; private set; } = new List<GameObject>();
        public GameObject SafeZone { get; private set; }

        public static GameEnvironment Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameEnvironment();
                    instance.CheckPoints.AddRange(GameObject.FindGameObjectsWithTag("Checkpoint"));
                    instance.SafeZone = GameObject.FindGameObjectWithTag("SafeZone");
                    instance.CheckPoints = instance.CheckPoints.OrderBy(waypoint => waypoint.name).ToList();
                    instance.print("Instance created");
                }
                return instance;
            }
        }

        public void print(params object[] args)
        {
            string text = string.Empty;

            foreach (var item in args)
            {
                text += item.ToString();
            }

            Debug.Log(text);
        }

        public static dynamic ConvertTo(object value, System.Type type)
        {
            value = System.Convert.ChangeType(value, type);
            return value;
        }

    }
}

