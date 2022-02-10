using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;

namespace CrimsonEngine.Graphics.GUI
{
    public class GuiContainer2D : IBasicUpdate, IBasicDraw
    {
        /* TO DO - render text to Texture2D object once
         * and not every update/draw. 
         */
        private Texture2D GuiRender;

        /* Change to enum class. Why?
         * More modern approach.
         */
        #region Custom enums
        public enum Layer
        {
            ZERO = 1,
            FIRST = 2,
            SECOND = 4 // very optional, might not be used at all
        }
        #endregion

        #region Fields
        private List<(Layer LayerName, Button2D Element)> Buttons;
        private List<(Layer LayerName, Label2D Element)> Labels;
        private List<(Layer LayerName, Basic2D Element)> Sprites;
        #endregion

        #region Constructors
        public GuiContainer2D()
        {
            Buttons = new List<(Layer LayerName, Button2D Element)>();
            Labels = new List<(Layer LayerName, Label2D Element)>();
            Sprites = new List<(Layer LayerName, Basic2D Element)>();

            // For now we don't want to generate default GUI for debugging
            if (false)
            {
                CreateDefaultGui();
            }
        }
        #endregion

        #region Private methods
        private void CreateDefaultGui()
        {
            AddLabel(Vector2.Zero, "Nope");
            AddLabel(new Vector2(10, 80), "Siemka, co tam?\nlol xD", Color.White, GuiContainer2D.Layer.SECOND);
            AddSprite(new Vector2(50, 200), new Vector2(100, 100), @"sprites\amiga_mouse_cursor");
            AddButton(new Vector2(300, 50), "      Nie\n    ma\n  mnie\ntutaj!!!");
            AddButton(new Vector2(75, 400), "Button with\nsprites... Yeah?", @"sprites\amiga_mouse_cursor", @"pixel");
            //AddButton(new Vector2(75, 300), "Button with\nsprites... Yeah?");
        }
        #endregion

        #region Public methods
        public void AddButton(
            Vector2 POSITION, Vector2 DIMS,
            string TEXTUREPATH, string LABEL,
            Action CLICK_ACTIOM, Layer LAYER = Layer.FIRST
            )
        {
            Button2D element = new Button2D();
            element.ClickAction = CLICK_ACTIOM;
            element.ButtonTexture = new Basic2D(TEXTUREPATH, POSITION, DIMS);
            element.Label = new Label2D(LABEL, POSITION, Color.Blue);
            element.Position = POSITION;
            element.Dimensions = DIMS;
            AddButton(element, LAYER);
        }

        private void AddButton(Button2D BUTTON, Layer LAYER_NAME = Layer.FIRST)
        {
            Buttons.Add((LAYER_NAME,BUTTON));
        }

        public void AddButton(Vector2 POSITION, string Label)
        {
            Button2D element = new Button2D(Label, POSITION, null);
            
            element.ClickAction = new Action(() =>
            {
                Console.WriteLine("I was clicked.");
            });

            AddButton(element);
        }

        public void AddButton(Vector2 POSITION, string BUTTON_LABEL, 
            string BUTTON_TEXTURE, string BUTTON_CLICKED_TEXTURE,
            Layer LAYER = Layer.FIRST
            )
        {
            Button2D element = new Button2D(BUTTON_LABEL, POSITION, null);

            element.IsSolidColorButton = false;
            element.ButtonSpriteOff = new Basic2D(BUTTON_TEXTURE, POSITION, Vector2.Zero);
            element.ButtonSpriteOn = new Basic2D(BUTTON_CLICKED_TEXTURE, POSITION, Vector2.Zero);

            AddButton(element);
        }

        public void AddSprite(Vector2 POSITION, Vector2 ? DIMENSIONS, string TEXTURE_PATH, Layer LAYER = Layer.FIRST)
        {
            Basic2D element = new Basic2D(TEXTURE_PATH, POSITION, new Vector2(100,150));

            // Automatic dimensions value (if texture availiable)
            if (DIMENSIONS == null && element.Texture != null)
            {
                element.Dimensions = new Vector2(element.Texture.Width, element.Texture.Height);
            }

            Sprites.Add((LAYER, element));
        }

        public void AddLabel(Vector2 POSITION, string LABEL, Color? FONT_COLOR = null, Layer LAYER = Layer.FIRST)
        {
            Label2D element = new Label2D(LABEL, POSITION, FONT_COLOR);
            Labels.Add((LAYER, element));
        }

        private void SortElements()
        {
            // TO DO

        }

        public void Update()
        {
            foreach (var e in Labels) { e.Element.Update(); }
            foreach (var e in Sprites) { e.Element.Update(); }
            foreach (var e in Buttons) { e.Element.Update(); }
        }

        public bool AnyButtonWasClicked(Vector2 MOUSE_POSITION)
        {
            foreach(var b in Buttons)
            {
                // to do . . .
                if(b.Element.IsClicked())
                {
                    Console.WriteLine("Button '{0}' was clicked.", b.Element.Label);
                    return true;
                }
            }

            return false;
        }

        public void Draw()
        {
            Layer[] temp = {
                Layer.ZERO,
                Layer.FIRST,
                Layer.SECOND
            };

            var b = Buttons.OrderBy(o => o.LayerName);
            var c = Labels.OrderBy(o => o.LayerName);
            var a = Sprites.OrderBy(o => o.LayerName);

            foreach (var layerName in temp)
            {
                foreach (var i in a)
                {
                    if (i.LayerName == layerName)
                    {
                        i.Element.Draw();
                    }
                }

                foreach (var i in b)
                {
                    if (i.LayerName == layerName)
                    {
                        i.Element.Draw();
                    }
                }

                foreach (var i in c)
                {
                    if (i.LayerName == layerName)
                    {
                        i.Element.Draw();
                    }
                }
            }
        }

        public void Draw(Vector2 OFFSET)
        {
            // TO DO
        }
        #endregion
    }
}
