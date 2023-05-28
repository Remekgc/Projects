using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Location
{
    [System.Serializable]
    public class Coordinates
    {
        [SerializeField] Vector3 position = Vector3.zero;
        [SerializeField] Color color = Color.green;

        public Vector3 Position { get { return position; } set { position = value; } }
        public Color Color { get => color; }

        #region Constructors
        public Coordinates(float x, float y) : this(new Vector3(x, y, -1), Color.green) {   }

        public Coordinates(float x, float y, float z) : this(new Vector3(x, y, z), Color.green) { }

        public Coordinates(Vector3 position, Color color)
        {
            this.position = position;
            this.color = color;
        }
        public Coordinates() : this(new Vector3(0, 0, -1), Color.green) { }
        public Coordinates(Vector3 position) : this(position, Color.green) { }
        #endregion

        public float x { get => position.x; set => position.x = value; }

        public float y { get => position.y; set => position.y = value; }
        public float z { get => position.z; set => position.z = value; }

        public override string ToString()
        {
            return $"({position.x}, {position.y}, {position.z})";
        }

        public void DrawPoint(float width)
        {
            DrawPoint(width, color);
        }

        public void DrawPoint(float width, Color color)
        {
            GameObject line = new GameObject($"Point: {position}");
            LineRenderer lineRenderer = line.AddComponent<LineRenderer>();

            lineRenderer.material = new Material(Shader.Find("Unlit/Color"));
            lineRenderer.material.color = color;
            lineRenderer.positionCount = 2;

            lineRenderer.SetPosition(0, new Vector3(position.x - width / 3f, position.y - width / 3f, position.z));
            lineRenderer.SetPosition(1, new Vector3(position.x + width / 3f, position.y + width / 3f, position.z));

            lineRenderer.startWidth = width;
            lineRenderer.endWidth = width;
        }

        public static void DrawPoint(Coordinates coordinates, float width, Color color)
        {
            coordinates.DrawPoint(width, color);
        }

        public static void DrawLine(Coordinates a, Coordinates b, float width, Color color)
        {
            GameObject line = new GameObject($"Line from {a} to {b}");
            LineRenderer lineRenderer = line.AddComponent<LineRenderer>();

            lineRenderer.material = new Material(Shader.Find("Unlit/Color"));
            lineRenderer.material.color = color;
            lineRenderer.positionCount = 2;

            lineRenderer.SetPosition(0, new Vector3(a.position.x, a.position.y, a.position.z + 0.01f));
            lineRenderer.SetPosition(1, new Vector3(b.position.x, b.position.y, b.position.z + 0.01f));

            lineRenderer.startWidth = width;
            lineRenderer.endWidth = width;
        }
    }
}
