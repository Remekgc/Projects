using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Location;

namespace Intersections
{
    public class CreatePlaneHit : MonoBehaviour
    {
        [SerializeField] Transform planePointA;
        [SerializeField] Transform planePointB;
        [SerializeField] Transform planePointC;
        [SerializeField] Transform linePointA;
        [SerializeField] Transform linePointB;

        [SerializeField] Plane plane;
        [SerializeField] Line line;

        private void Start()
        {
            plane = new Plane(planePointA.position, planePointB.position, planePointC.position);
            line = new Line(linePointB.position, linePointA.position, LineType.Ray);

            line.Draw(1f, Color.green);

            for (float s = 0; s <= 1; s += 0.1f)
            {
                for (float t = 0; t <= 1; t += 0.1f)
                {
                    GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    sphere.transform.position = plane.Lerp(s, t).ToVector();
                }
            }

            float interceptT = line.IntersectsAt(plane);

            if (float.IsNaN(interceptT) == false)
            {
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.position = line.Lerp(interceptT).ToVector();
            }
        }

        private void Update()
        {
            
        }
    }
}
