using Location;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Intersections
{
    public class LineBuilder : MonoBehaviour
    {
        [SerializeField] Line a;
        [SerializeField] Line b;

        public Line A { get => a; }
        public Line B {  get => b; }

        private void Start()
        {
            //A = new Line(new Coordinates(-100, 0, 0), new Coordinates(200, 150, 0));
            a = new Line(new Coordinates(-100, 0, 0), new Coordinates(200, 150, 0));
            a.Draw(1, Color.green);
            //B = new Line(new Coordinates(0, -100, 0), new Coordinates(0, 200, 0));
            b = new Line(new Coordinates(-100, 10, 0), new Coordinates(200, 150, 0));
            b.Draw(1, Color.red);

            float intersectT = a.IntersectsAt(b);
            float intersectS = b.IntersectsAt(a);

            if (float.IsNaN(intersectT) && float.IsNaN(intersectS))
            {
                Debug.Log("Lines do not intersect");
                return;
            }

            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.transform.position = a.Lerp(intersectT).ToVector();
        }
    }
}
