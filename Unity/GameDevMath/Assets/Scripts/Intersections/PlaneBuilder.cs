using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Location;

namespace Intersections 
{
    public class PlaneBuilder : MonoBehaviour
    {
        [SerializeField] Transform a;
        [SerializeField] Transform b;
        [SerializeField] Transform c;
        [SerializeField] Transform points;
        [SerializeField] Plane plane;
        [SerializeField] float pointSize = 0.1f;
        [SerializeField] Vector2 size = new Vector2(0, 1);

        void Start()
        {
            plane = new Plane(new Coordinates(a.position), new Coordinates(b.position), new Coordinates(c.position));

            for (float s = size.x; s < size.y; s += 0.1f)
            {
                for (float t = size.x; t < size.y; t += 0.1f)
                {
                    GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    sphere.transform.parent = points;
                    sphere.transform.position = plane.Lerp(s, t).ToVector();
                    sphere.transform.localScale = new Vector3(pointSize, pointSize, pointSize);
                }
            }
        }
    }
}
