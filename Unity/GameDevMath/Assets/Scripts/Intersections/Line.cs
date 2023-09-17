using Location;
using UnityEngine;
using Vectors;

namespace Intersections
{
    [System.Serializable]
    public class Line
    {
        [SerializeField] Coordinates a;
        [SerializeField] Coordinates b;
        [SerializeField] Coordinates vector;
        [SerializeField] LineType type;

        #region Properties
        public Coordinates A
        {
            get { return a; }
            set { a = value; }
        }   
        public Coordinates B
        {
            get { return b; }
            set { b = value; }
        }
        public Coordinates Vector
        {
            get { return vector; }
            set { vector = value; }
        }
        #endregion

        public LineType Type
        {
            get { return type; }
            set { type = value; }
        }

        public Line(Coordinates a, Coordinates b, LineType type = LineType.Line)
        {
            this.a = a;
            this.b = b;
            this.type = type;
            this.vector = new Coordinates(b.x - a.x, b.y - a.y, b.z - a.z);
        }

        public Line(Vector3 a, Vector3 b, LineType lineType = LineType.Line)
        {
            this.a = new Coordinates(a.x, a.y, a.z);
            this.b = new Coordinates(b.x, b.y, b.z);
            this.type = lineType;
            this.vector = new Coordinates(b.x - a.x, b.y - a.y, b.z - a.z);
        }

        public Line(Coordinates a, Coordinates vector)
        {
            this.a = a;
            this.b = a + vector;
            this.vector = vector;
        }

        public Coordinates Lerp(float t)
        {
            if (type == LineType.Segment)
            {
                t = Mathf.Clamp(t, 0, 1);
            }
            else if (type == LineType.Ray && t < 0)
            {
                t = 0;
            }

            float xt = a.x + vector.x * t;
            float yt = a.y + vector.y * t;
            float zt = a.z + vector.z * t;

            return new Coordinates(xt, yt, zt);
        }

        public float IntersectsAt(Line other)
        {
            if (VectorMath.Dot(Coordinates.Perp(other.vector), vector) == 0)
            {
                return float.NaN;
            }

            Coordinates c = other.a - this.a;
            float t = VectorMath.Dot(Coordinates.Perp(other.vector), c) / VectorMath.Dot(Coordinates.Perp(other.vector), this.vector);

            return t;
        }

        public float IntersectsAt(Plane plane)
        {
            Coordinates normal = VectorMath.CrossProduct(plane.V, plane.U);

            if (VectorMath.Dot(normal, this.vector) == 0)
            {
                return float.NaN;
            }

            float t = VectorMath.Dot(normal, plane.A - this.a) / VectorMath.Dot(normal, this.vector);

            return t;
        }

        public Coordinates Reflect(Coordinates vector)
        {
            Coordinates normal = VectorMath.GetNormal(vector);
            Coordinates lineVectorNormal = VectorMath.GetNormal(this.vector);

            float dot2 = VectorMath.Dot(normal, lineVectorNormal) * 2;

            Coordinates r = lineVectorNormal - (normal * dot2);

            return r;
        }

        public void Draw(float width, Color color)
        {
            Coordinates.DrawLine(a, b, width, color);
        }
    }
}
