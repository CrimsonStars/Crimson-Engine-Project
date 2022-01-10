using CrimsonEngine;
using CrimsonEngine.Graphics;
using CrimsonEngine.Simple_math;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrimsonEngine.Graphics.GUI
{
    public enum LabelAligment
    {
        VERTICAL_LEFT = 1,
        VERTICAL_CENTER = 2,
        VERTICAL_RIGHT = 4,
        HORIZOTAL_BOTTOM = 8,
        HORIZONTAL_CENTER = 16,
        HORIZONTAL_UP = 32
    }

    public class Button2D : Basic2D, IClickable
    {
        public string Label { get; set; }
        public LabelAligment TextAlignment { get; set; }
        public List<Polygon> ActiveRegions;
        public bool DrawActiveRegions { get; set; }
        public Action ClickAction;

        public Button2D(string LABEL, string TEXTURE, Vector2 POSITION, Vector2 DIMS, LabelAligment TEXT_ALIGNMENT = LabelAligment.VERTICAL_CENTER | LabelAligment.HORIZONTAL_CENTER)
            : base(TEXTURE, POSITION, DIMS)
        {
            Label = LABEL;
            ActiveRegions = new List<Polygon>();
            TextAlignment = TEXT_ALIGNMENT;
        }

        public Button2D() : base("", Vector2.Zero, Vector2.One)
        {
            TextAlignment = LabelAligment.VERTICAL_CENTER | LabelAligment.HORIZONTAL_CENTER;
            Label = "Lorem ipsum";
            
            ActiveRegions = new List<Polygon>();
            ActiveRegions.Add(new Polygon());
            ActiveRegions.Last().AddPoint(0.0f, 0.0f);
            ActiveRegions.Last().AddPoint(1.0f, 0.0f);
            ActiveRegions.Last().AddPoint(0.0f, 1.0f);
            ActiveRegions.Last().AddPoint(1.0f, 1.0f);

            ClickAction = new Action(() =>
            {
                Console.WriteLine("Button with label {0} was clicked.", Label);
            });
        }

        public void Click()
        {
            ClickAction.Invoke();
        }

        public void SetButtonAction(Action ACTION_TO_PERFORM)
        {
            ClickAction = ACTION_TO_PERFORM;
        }

        public bool Hovered(Vector2 MOUSE_POSITION)
        {
            bool result = ActiveRegions.Any((p) =>
            {
                return p.IsInsidePolygon(new Point2D(MOUSE_POSITION.X, MOUSE_POSITION.Y));
            });

            return result;
        }

        public void Clicked(Vector2 MOUSE_POSITION)
        {
            throw new NotImplementedException();
        }
    }
}
