using CrimsonEngine.Simple_math;
using MonoGame.Extended;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CrimsonEngine.Graphics.GUI
{
    public enum LabelAligment
    {
        NONE = 0,
        VERTICAL_LEFT = 1,
        VERTICAL_CENTER = 2,
        VERTICAL_RIGHT = 4,
        HORIZOTAL_BOTTOM = 8,
        HORIZONTAL_CENTER = 16,
        HORIZONTAL_UP = 32
    }

    public class Button2D : IClickable, IBasicDraw, IBasicUpdate
    {
        public Label2D Label { get; set; }
        public LabelAligment TextAlignment { get; set; }
        public List<Polygon> ActiveRegions;
        public bool DrawActiveRegions { get; set; }
        public Action ClickAction;


        public readonly Color TEMP_DEFAULT_COLOR = Color.White;
        public Basic2D ButtonSpriteOn { get; set; }
        public Basic2D ButtonSpriteOff { get; set; }
        
        public float MarginValue { get; set; } = 10.0f;
        public Vector2 Position;
        public Vector2 Dimensions;
        public bool IsSolidColorButton;
        public string TextureNotClicked;
        public Basic2D ButtonTexture;
        
        
        public Button2D(string LABEL, float POSITION_X, float POSITION_Y, string BUTTON_TEXTURE_ON, string BUTTON_TEXTURE_OFF, float DIMENSIONS_X = 0.0f, float DIMENSIONS_Y = 0.0f)
        {
            Position = new Vector2(POSITION_X, POSITION_Y);
            Label = new Label2D(LABEL, Position, null);
            IsSolidColorButton = false;

            if (DIMENSIONS_Y == 0.0f || DIMENSIONS_X == 0.0f)
            {
                Dimensions = Label.MeasureLabelSize();
                ButtonSpriteOn = new Basic2D(BUTTON_TEXTURE_ON, Position, Dimensions);
                ButtonSpriteOff = new Basic2D(BUTTON_TEXTURE_OFF, Position, Dimensions);
            }
            else
            {
                Dimensions = new Vector2(DIMENSIONS_X, DIMENSIONS_Y);
                ButtonSpriteOn = new Basic2D(BUTTON_TEXTURE_ON, Position, Dimensions);
                ButtonSpriteOff = new Basic2D(BUTTON_TEXTURE_OFF, Position, Dimensions);
            }
        }
        
        public Button2D(string LABEL, string TEXTURE,
            Vector2 POSITION, Vector2 DIMS,
            LabelAligment TEXT_ALIGNMENT = LabelAligment.VERTICAL_CENTER | LabelAligment.HORIZONTAL_CENTER
            )
        {
            Label = new Label2D(LABEL, POSITION, Color.Black);
            ActiveRegions = new List<Polygon>();
            TextAlignment = TEXT_ALIGNMENT;
            ButtonTexture = new Basic2D(TEXTURE, POSITION, DIMS);
            IsSolidColorButton = false;
        }

        public Button2D(string LABEL, string TEXTURE,
            Vector2 POSITION, Vector2 DIMS
            )
        {
            IsSolidColorButton = true;
            Label = new Label2D(LABEL, POSITION, Color.Black);
            ActiveRegions = new List<Polygon>();
            ButtonTexture = new Basic2D(TEXTURE, POSITION, DIMS);
        }
        
        /// <summary>
        /// Create simple button with solid color background. The dimensions
        /// are calculated by the constructor. Good for testing purposes.
        /// </summary>
        /// <param name="LABEL"></param>
        /// <param name="POSITION"></param>
        public Button2D(string LABEL, Vector2 POSITION, Color ? BACKGROUND_COLOR)
        {
            IsSolidColorButton = true;
            Label = new Label2D(LABEL, POSITION, Color.Black);
            ButtonTexture = null;
            Position = POSITION;

            ActiveRegions = new List<Polygon>();
            var tempPolygon = new Polygon();
            Dimensions = Label.MeasureLabelSize();
            var lw = Dimensions.X;
            var lh = Dimensions.Y;
            tempPolygon.AddPoint(Position.X-lw, Position.Y-lh);
            tempPolygon.AddPoint(Position.X+lw, Position.Y-lh);
            tempPolygon.AddPoint(Position.X+lw, Position.Y+lh);
            tempPolygon.AddPoint(Position.X-lw, Position.Y+lh);
            ActiveRegions.Add(tempPolygon);

            IsSolidColorButton = true;
            
            if(BACKGROUND_COLOR==null)
            {
                TEMP_DEFAULT_COLOR = Color.White;
            }
        }

        public Button2D()
        {
            TextAlignment = LabelAligment.VERTICAL_CENTER | LabelAligment.HORIZONTAL_CENTER;
            Label = new Label2D("Lorem ipsum", Vector2.Multiply(Vector2.One, 40.0f), Color.White);
            
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

            //IsSolidColorButton = true;
        }

        public void Click()
        {
            ClickAction.Invoke();
        }

        public void SetButtonAction(Action ACTION_TO_PERFORM)
        {
            ClickAction = ACTION_TO_PERFORM;
        }

        public bool Hovered()
        {
            bool result = 
                ActiveRegions.Any((p) =>
            {
                return p.IsInsidePolygon(new Point2D(LibGlobals.MousePosition.X, LibGlobals.MousePosition.Y));
            });

            return result;
        }

        public bool IsClicked()
        {
            foreach (var item in ActiveRegions)
            {
                if(item.IsInsidePolygon(new Point2D(LibGlobals.MousePosition.X, LibGlobals.MousePosition.Y)))
                {
                    return true;
                }
            }

            return false;
        }

        public void Draw()
        {
            Draw(Vector2.Zero);
        }

        public void Draw(Vector2 OFFSET)
        {
            if (IsSolidColorButton)
            {
                var tempMarginVector = Vector2.One * MarginValue;
                var tempp = Position - tempMarginVector;
                var tempd = Dimensions + tempMarginVector * 2.0f;
                RectangleF rectangle = new RectangleF(Position, Dimensions);
                RectangleF rectangle2 = new RectangleF(tempp, tempd);

                LibGlobals.LibSpriteBatch.Draw(
                    LibGlobals.LibContentManager.Load<Microsoft.Xna.Framework.Graphics.Texture2D>("pixel"),
                    ((Rectangle)rectangle2), Color.Gray);

                LibGlobals.LibSpriteBatch.Draw(
                    LibGlobals.LibContentManager.Load<Microsoft.Xna.Framework.Graphics.Texture2D>("pixel"),
                    ((Rectangle)rectangle), Color.LightGray);

                LibGlobals.LibSpriteBatch.DrawRectangle(rectangle2, Color.Red, thickness: 2);
            }
            else
            {
                if (ButtonSpriteOff != null)
                {
                    ButtonSpriteOff.Draw(OFFSET);
                }
            }

            Label.Draw(OFFSET);
        }

        public void Update()
        {
            if (!IsSolidColorButton)
            {
                ButtonSpriteOff.Update();
            }
            else
            {
                Label.Update();
            }
        }
    }
}
