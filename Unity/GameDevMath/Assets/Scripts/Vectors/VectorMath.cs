using Location;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Vectors 
{
    public class VectorMath : MonoBehaviour
    {
        static public Coordinates GetNormal(Coordinates vector)
        {
            Coordinates normal = new Coordinates(vector);

            float length = Distance(new Coordinates(0, 0, 0), vector);

            normal.x /= length;
            normal.y /= length;
            normal.z /= length;

            return normal;
        }

        static public float Distance(Coordinates point1, Coordinates point2)
        {
            float diffSquared = Square(point1.x - point2.x) +
                                Square(point1.y - point2.y) +
                                Square(point1.z - point2.z);
            float squareRoot = Mathf.Sqrt(diffSquared);

            return squareRoot;

        }

        static public float Square(float value)
        {
            return value * value;
        }

        static public float Dot(Coordinates vector1, Coordinates vector2)
        {
            return (vector1.x * vector2.x + vector1.y * vector2.y + vector1.z * vector2.z);
        }

        static public float Angle(Coordinates vector1, Coordinates vector2)
        {
            float dotDivide = Dot(vector1, vector2) /
                        (Distance(new Coordinates(0, 0, 0), vector1) * Distance(new Coordinates(0, 0, 0), vector2));

            return Mathf.Acos(dotDivide); //radians.  For degrees * 180/Mathf.PI;
        }

        static public Coordinates LookAt2D(Coordinates forwardVector, Coordinates position, Coordinates focusPoint)
        {
            Coordinates direction = new Coordinates(focusPoint.x - position.x, focusPoint.y - position.y, position.z);
            float angle = Angle(forwardVector, direction);
            bool clockwise = false;

            if (CrossProduct(forwardVector, direction).z < 0)
            {
                clockwise = true;
            }

            Coordinates newDir = Rotate(forwardVector, angle, clockwise);

            return newDir;
        }

        static public Coordinates Rotate(Coordinates vector, float angle, bool clockwise) //in radians
        {
            if (clockwise)
            {
                angle = 2 * Mathf.PI - angle;
            }

            float xVal = vector.x * Mathf.Cos(angle) - vector.y * Mathf.Sin(angle);
            float yVal = vector.x * Mathf.Sin(angle) + vector.y * Mathf.Cos(angle);

            return new Coordinates(xVal, yVal, 0);
        }

        static public Coordinates Translate(Coordinates position, Coordinates facing, Coordinates vector)
        {
            if (Distance(new Coordinates(0, 0, 0), vector) <= 0)
            {
                return position;
            }


            float angle = Angle(vector, facing);
            float worldAngle = Angle(vector, new Coordinates(0, 1, 0));

            vector = Rotate(vector, angle + worldAngle, CrossProduct(vector, facing).z < 0);

            float xVal = position.x + vector.x;
            float yVal = position.y + vector.y;
            float zVal = position.z + vector.z;

            return new Coordinates(xVal, yVal, zVal);
        }

        static public Coordinates CrossProduct(Coordinates vector1, Coordinates vector2)
        {
            float xMult = vector1.y * vector2.z - vector1.z * vector2.y;
            float yMult = vector1.z * vector2.x - vector1.x * vector2.z;
            float zMult = vector1.x * vector2.y - vector1.y * vector2.x;

            Coordinates crossProd = new Coordinates(xMult, yMult, zMult);

            return crossProd;
        }
    }
}
