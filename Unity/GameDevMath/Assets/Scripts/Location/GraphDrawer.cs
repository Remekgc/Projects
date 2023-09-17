using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Location
{
    public class GraphDrawer : MonoBehaviour
    {
        [SerializeField] int size = 20;
        [SerializeField] Vector3 screenSize = Vector3.one;

        private void Start()
        {
            DrawGraph();
        }

        void DrawGraph()
        {
            int xOffset = (int)(screenSize.x / size);
            int yOffset = (int)(screenSize.y / size);

            for (float x = -xOffset * size; x <= xOffset * size; x += size)
            {
                Coordinates.DrawLine(new Coordinates(x, -screenSize.y, screenSize.z), new Coordinates(x, screenSize.y, screenSize.z), 0.5f, Color.white);
            }

            for (float y = -yOffset * size; y <= yOffset * size; y += size)
            {
                Coordinates.DrawLine(new Coordinates(-screenSize.x, y, screenSize.z), new Coordinates(screenSize.x, y, screenSize.z), 0.5f, Color.white);
            }
        }
    }
}
