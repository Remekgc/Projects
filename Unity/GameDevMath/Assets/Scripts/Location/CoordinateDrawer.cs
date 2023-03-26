using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Location 
{
    public class CoordinateDrawer : MonoBehaviour
    {
        [SerializeField] List<Coordinates> coordinates = new List<Coordinates>();
        [Header("Screen lines")]
        [SerializeField] Coordinates xStart = new Coordinates();
        [SerializeField] Coordinates xEnd = new Coordinates();
        [SerializeField] Coordinates yStart = new Coordinates();
        [SerializeField] Coordinates yEnd = new Coordinates();

        private void Start()
        {
            Debug.Log(coordinates.ToString());

            foreach (Coordinates coordinates in coordinates)
            {
                coordinates.DrawPoint(2f);
            }

            //if (coordinates.Count > 1) 
            //{
            //    Coordinates.DrawLine(coordinates[0], coordinates[1], 2f, Color.red);
            //}

            Coordinates.DrawLine(xStart, xEnd, 0.5f, Color.red);
            Coordinates.DrawLine(yStart, yEnd, 0.5f, Color.blue);
            Coordinates.DrawPoint(xStart, 1f, Color.red);
            Coordinates.DrawPoint(xEnd, 1f, Color.red);
            Coordinates.DrawPoint(yStart, 1f, Color.blue);
            Coordinates.DrawPoint(yEnd, 1f, Color.blue);
        }
    }
}
