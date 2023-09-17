using Location;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Intersections
{
    public class CreateWall : MonoBehaviour
    {
        [SerializeField] GameObject ball;

        Line wall;
        Line ballPath;
        Line trajectory;

        void Start()
        {
            wall = new Line(new Coordinates(5, -2, 0), new Coordinates(0, 5, 0));
            wall.Draw(1, Color.blue);

            ballPath = new Line(new Coordinates(-6, 0, 0), new Coordinates(100, 0, 0));
            ballPath.Draw(0.1f, Color.yellow);

            ball.transform.position = ballPath.A.ToVector();

            float t = ballPath.IntersectsAt(wall);
            float s = wall.IntersectsAt(ballPath);

            if (float.IsNaN(t) == false && float.IsNaN(s) == false)
            {
                trajectory = new Line(ballPath.A, ballPath.Lerp(t), LineType.Segment);
            }
        }

        private void Update()
        {
            ball.transform.position = trajectory.Lerp(Time.time).Position;
        }
    }
}
