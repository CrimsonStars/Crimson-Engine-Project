using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrimsonEngine.Simple_math
{
    static class BasicOperations
    {

        public static double Length(Point2D A, Point2D B)
        {
            return Math.Sqrt(Math.Pow(A.X - B.X, 2.0) + Math.Pow(A.Y - B.Y, 2.0));
        }

        public static double TrapezoidumArea(double HEIGHT, double A, double B)
        {
            return 0.5 * HEIGHT * (A + B);
        }

        public static double TriangleArea(double HEIGHT, double A)
        {
            return 0.5 * HEIGHT * A;
        }

        public static double CircleArea(double R)
        {
            return Math.PI * Math.Pow(R, 2.0);
        }

        public static bool AreVectorsCrossing(double Ux, double Uy, double Vx, double Vy)
        {
            return (Ux * Vy - Uy * Vy) > 0;
        }
    }
}
