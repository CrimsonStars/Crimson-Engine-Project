using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrimsonEngine.Simple_math
{
    public class Point2D
    {
        public float X { get; set; }
        public float Y { get; set; }

        public Point2D()
        {
            X = 0.0f;
            Y = 0.0f;
        }

        public Point2D(float InX = 0.0f, float InY = 0.0f)
        {
            X = InX;
            Y = InY;
        }

        public static explicit operator Vector2(Point2D p)
        {
            return new Vector2(p.X, p.Y);
        }
    }
}
