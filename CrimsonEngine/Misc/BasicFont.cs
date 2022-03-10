using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrimsonEngine.Misc
{
    class BasicFont : IBasicDraw, IBasicUpdate
    {
        #region Properties
        public SpriteFont Font{ get; set; }
        public Vector2 Position { get; set; }
        public int FontSize { get; set; }
        public Color FontColor { get; set; }
        #endregion

        #region Constructors
        public BasicFont()
        {
            Font = null;
            Position = Vector2.Zero;
            FontSize = 0;
            FontColor = Color.Black;
        }

        public BasicFont(string FONTNAME, Vector2 POSITION, int FONTSIZE, Color ? FONTCOLOR)
        {
            Position = POSITION;
            FontSize = FontSize;
            
            if (FONTCOLOR != null)
            {
                FontColor = (Color)FONTCOLOR;
            }

            LoadSpriteFont(FONTNAME);
        }
        #endregion

        private void LoadSpriteFont(string fontName)
        {
            if(string.IsNullOrEmpty(fontName))
            {
                throw new ArgumentNullException("fontName");
            }

            this.Font = LibGlobals.LibContentManager.Load<SpriteFont>("fonts/" + fontName);

        }


        public void Draw()
        {
            throw new NotImplementedException();
        }

        public void Draw(Vector2 OFFSET)
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        #region Public methods
        #endregion

        #region Private methods
        #endregion
        
    }
}
