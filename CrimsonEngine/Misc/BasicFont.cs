using CrimsonEngine.Globals;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrimsonEngine.Misc
{
    public class BasicFont : IBasicDraw
    {
        #region Properties
        public SpriteFont Font{ get; set; }
        public Vector2 Position { get; set; }
        public int FontSize { get; set; }
        public Color FontColor { get; set; }
        public string TextToDisplay { get; set; }
        private string FontName { get; set; } // just to have that information for debugging
        #endregion

        #region Constructors
        public BasicFont()
        {
            Font = null;
            Position = Vector2.Zero;
            FontSize = 0;
            FontColor = Color.Black;
        }

        public BasicFont(string FONTNAME, Vector2 POSITION, Color ? FONTCOLOR,int FONTSIZE=8)
        {
            Position = POSITION;
            FontSize = FONTSIZE;
            FontColor = (Color)(FONTCOLOR == null ? Color.White : FONTCOLOR);
            FontName = FONTNAME;

            LoadSpriteFont(FONTNAME);
        }
        #endregion

        private void LoadSpriteFont(string fontName)
        {
            if(string.IsNullOrEmpty(fontName))
            {
                throw new ArgumentNullException("fontName");
            }

            Font = LibGlobals.LibContentManager.Load<SpriteFont>("fonts/" + fontName);

        }

        public void Draw()
        {
            Draw(Vector2.Zero);
        }

        public void Draw(Vector2 OFFSET)
        {
            if (Font == null)
            {
                throw new ArgumentNullException("Font");
            }
         
            if (string.IsNullOrEmpty(TextToDisplay))
            {
                throw new NullReferenceException("TextToDisplay");
            }

            LibGlobals.LibSpriteBatch.DrawString(Font, TextToDisplay, Position, FontColor);
        }
    }
}
