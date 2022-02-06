using Microsoft.Xna.Framework;
using MonoGame.Extended;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;

namespace CrimsonEngine.Simple_math
{
    [XmlRoot("poly")]
    public class Polygon : IBasicDraw
    {
        [XmlIgnore] public List<Point2D> _vertices;
        [XmlIgnore] public List<Polygon> _holes;
        [XmlIgnore] public float MaxX { get; set; } = -1000;
        [XmlIgnore] public float MaxY { get; set; } = -1000;
        [XmlIgnore] public float MinX { get; set; } = 1000;
        [XmlIgnore] public float MinY { get; set; } = 1000;

        [XmlElement("ACTIVE_AREA_POLYGON")]
        public string TextValue { get { return this.ToString(); } set { } }

        #region Constructors
        public Polygon()
        {
            _vertices = new List<Point2D>();
            _holes = null;
        }
        #endregion

        #region Public methods
        public void AddPoint(float x, float y)
        {
            _vertices.Add(new Point2D(x, y));

            if (x > MaxX) MaxX = x;
            if (y > MaxY) MaxY = y;
            if (x < MinX) MinX = x;
            if (y < MinY) MinY = y;
        }

        public bool IsInsidePolygon(Point2D POINT)
        {
            bool result = false;
            Vector2 vec = new Vector2(POINT.X - MinX, POINT.Y - MinY);

            for (int i = 0; i < _vertices.Count; i++)
            {
                int index = i + 1;

                // // Leftover from previous development
                //Vector2 temp = new Vector2(
                //    _vertices[index % _vertices.Count].X - _vertices[i].X,
                //    _vertices[index % _vertices.Count].Y - _vertices[i].Y
                //    );

                BasicOperations.AreVectorsCrossing(
                    _vertices[index % _vertices.Count].X - _vertices[i].X, 
                    _vertices[index % _vertices.Count].Y - _vertices[i].Y, 
                    vec.X, 
                    vec.Y
                    );
            }

            return result;
        }

        /// <summary>
        /// Don't know why I need this, but it might come
        /// in handy later. I guess...
        /// </summary>
        /// <returns>-1.0 value... for now :)</returns>
        public double GetSurfaceArea()
        {
            double result = 0.0f;

            for (int i = 0; i < _vertices.Count; i++)
            {
                double height = BasicOperations.Length(_vertices[i], _vertices[(i + 1) % _vertices.Count]);
                double a = _vertices[i].Y;
                double b = _vertices[(i + 1) % _vertices.Count].Y;

                result +=
                    Math.Sign(_vertices[(i + 1) % _vertices.Count].Y - _vertices[i].X)
                    * BasicOperations.TrapezoidumArea(height, a, b);
            }

            return result;
        }

        public double GetParmiter()
        {
            double result = 0.0;

            for (int i = 0; i < _vertices.Count; i++)
            {
                result += BasicOperations.Length(
                    _vertices[i], 
                    _vertices[(i + 1) % _vertices.Count]
                    );
            }

            return result;
        }

        public override string ToString()
        {
            string result = "";

            foreach (var i in _vertices)
            {
                result += String.Format("{0},{1}; ", i.X, i.Y);
            }

            // just to see it better in XML file
            return result.Remove(result.Length - 1);
        }

        public IEnumerable<Polygon> Triangulation()
        {
            var ListOfTriangles = new List<Polygon>();

            return ListOfTriangles;
        }

        public void Draw()
        {
            Draw(Vector2.Zero);
        }

        public void Draw(Vector2 OFFSET)
        {
            for (int i = 0; i < _vertices.Count; i++)
            {
                LibGlobals.LibSpriteBatch.DrawLine(
                    (Vector2) _vertices[i],
                    (Vector2) _vertices[(i + 1) % _vertices.Count],
                    Color.Red, 2
                    );
            }
        }
        #endregion
    }
}
