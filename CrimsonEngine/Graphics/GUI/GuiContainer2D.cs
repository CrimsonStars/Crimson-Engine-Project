using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;

namespace CrimsonEngine.Graphics.GUI
{
    public class GuiContainer2D:IBasicUpdate,IBasicDraw
    {
        private Texture2D GuiRender;

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
        private List<(Layer LayerName, Label2D Element)> Texts;
        private List<(Layer LayerName, Basic2D Element)> Sprites;
        #endregion

        #region Constructors
        public GuiContainer2D()
        {
            Buttons = new List<(Layer LayerName, Button2D Element)>();
            Texts = new List<(Layer LayerName, Label2D Element)>();
            Sprites = new List<(Layer LayerName, Basic2D Element)>();
        }
        #endregion

        #region Public methods
        public void AddButton(Vector2 POSITION, Layer LAYER = Layer.FIRST)
        {
            Button2D element = new Button2D();
            Buttons.Add((LAYER, element));
        }
        public void AddSprite(Vector2 POSITION, Layer LAYER = Layer.FIRST)
        {
            Basic2D element = new Basic2D("", POSITION, Vector2.One);
            Sprites.Add((LAYER, element));
        }

        public void AddLabel(Vector2 POSITION, string LABEL, Color? FONT_COLOR = null, Layer LAYER = Layer.FIRST)
        {
            Label2D element = new Label2D(LABEL, POSITION, FONT_COLOR);
            Texts.Add((LAYER, element));
        }

        private void SortElements()
        {
            // TO DO
            

        }

        public void Update()
        {
            foreach (var e in Texts) { e.Element.Update(); }
            foreach (var e in Sprites) { e.Element.Update(); }
            foreach (var e in Buttons) { e.Element.Update(); }
        }

        public void Draw()
        {
            Layer[] temp = {
                Layer.ZERO,
                Layer.FIRST,
                Layer.SECOND
            };

            var b = Buttons.OrderBy(o => o.LayerName);
            var c = Texts.OrderBy(o => o.LayerName);
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
