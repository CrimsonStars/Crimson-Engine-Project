using CrimsonEngine;
using CrimsonEngine.Graphics;
using CrimsonEngine.Simple_math;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrimsonEngine.Graphics.GUI
{
    public class Label2D :  IBasicUpdate, IBasicDraw
    {
        public string LabelText;
        public Vector2 Position;
        public SpriteFont Font;
        public Color FontColor = Color.White;
        private bool DrawBorders = true;
        private Polygon BorderPolygon;

        public Label2D(string LABEL, Vector2 POSITION, Color ? FONT_COLOR)
        {
            Font = LibGlobals.LibContentManager.Load<SpriteFont>("Gamepixies");
            LabelText = LABEL;
            Position = POSITION;
            FontColor = ((Color)(FONT_COLOR == null ? Color.White : FONT_COLOR));

            if (DrawBorders)
            {
                BorderPolygon = GetBoundingPolygon();
            }
        }

        private Polygon GetBoundingPolygon()
        {
            Polygon res = new Polygon();
            var tempCoordinates = MeasureLabelSize();

            res.AddPoint(Position.X+0.0f, Position.Y+0.0f);
            res.AddPoint(Position.X+0.0f, Position.Y+tempCoordinates.Y);
            res.AddPoint(Position.X+tempCoordinates.X, Position.Y+tempCoordinates.Y);
            res.AddPoint(Position.X+tempCoordinates.X, Position.Y+0.0f);

            return res;
        }

        public Vector2 MeasureLabelSize()
        {
            return Font.MeasureString(LabelText);
        }

        public void Draw()
        {
            Draw(Vector2.Zero);
        }

        public void Draw(Vector2 OFFSET)
        {
            LibGlobals.LibSpriteBatch.DrawString(Font, LabelText, Position, FontColor);

            if (DrawBorders)
            {
                BorderPolygon.Draw();
            }
        }

        public void Update()
        {

        }
    }
}
