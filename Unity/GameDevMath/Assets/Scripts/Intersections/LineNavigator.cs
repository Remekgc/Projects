using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Location;

namespace Intersections
{
    public class LineNavigator : MonoBehaviour
    {
        [SerializeField] Transform start;
        [SerializeField] Transform end;
        [SerializeField] float t = 0.5f;
        [Header("Runtime")]
        [SerializeField] Line line;

        private void Start()
        {
            line = new Line(new Coordinates(start.position), new Coordinates(end.position), LineType.Segment);
        }

        private void Update()
        {
            //this.transform.position = line.GetPointAt(t).Position;
            //this.transform.position = line.GetPointAt(Time.time * 0.1f).Position;
            //transform.position = line.Lerp(Time.time * 0.1f).Position;

            transform.position = 
                Coordinates.Lerp(
                    new Coordinates(start.position), 
                    new Coordinates(end.position), 
                    Time.time * 0.01f).Position;
        }
    }
}
