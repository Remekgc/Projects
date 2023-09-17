using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Location 
{
    public class CoordinateDrawer : MonoBehaviour
    {
        [SerializeField] List<Coordinates> coordinates = new List<Coordinates>();
        [SerializeField] bool drawLines = false;
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

            Coordinates.DrawLine(xStart, xEnd, 0.6f, Color.red);
            Coordinates.DrawLine(yStart, yEnd, 0.6f, Color.blue);
            Coordinates.DrawPoint(xStart, 1f, Color.red);
            Coordinates.DrawPoint(xEnd, 1f, Color.red);
            Coordinates.DrawPoint(yStart, 1f, Color.blue);
            Coordinates.DrawPoint(yEnd, 1f, Color.blue);

            if (drawLines)
            {
                DrawLines();
            }
        }

        void DrawLines()
        {
            for (int i = 0; i < coordinates.Count - 1; i++)
            {
                Coordinates.DrawLine(coordinates[i], coordinates[i + 1], 0.4f, Color.white);
            }
        }
    }
}
