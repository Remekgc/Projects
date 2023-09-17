using Location;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Intersections
{
    [System.Serializable]
    public class Plane
    {
        [field: SerializeField] public Coordinates A { get; set; }
        [field: SerializeField] public Coordinates B { get; set; }
        [field: SerializeField] public Coordinates C { get; set; }
        [field: SerializeField] public Coordinates V { get; set; }
        [field: SerializeField] public Coordinates U { get; set; }

        public Plane (Coordinates a, Coordinates b, Coordinates c)
        {
            this.A = a;
            this.B = b;
            this.C = c;
            this.V = b - a;
            this.U = c - a;
        }

        public Plane (Vector3 a, Vector3 b, Vector3 c)
        {
            this.A = new Coordinates(a.x, a.y, a.z);
            this.B = new Coordinates(b.x, b.y, b.z);
            this.C = new Coordinates(c.x, c.y, c.z);

            this.V = this.B - this.A;
            this.U = this.C - this.A;
        }

        public Coordinates Lerp(float s, float t)
        {
            float xst = this.A.x + this.V.x * s + this.U.x * t;
            float yst = this.A.y + this.V.y * s + this.U.y * t;
            float zst = this.A.z + this.V.z * s + this.U.z * t;

            return new Coordinates(xst, yst, zst);
        }
    }
}