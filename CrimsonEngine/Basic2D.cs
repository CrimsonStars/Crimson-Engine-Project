using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrimsonEngine
{
    public class Basic2D : IBasicUpdate, IBasicDraw
    {
        #region Fields
        public Texture2D Texture;
        public string Label { get; set; }
        public Vector2 Position;
        public Vector2 Dimensions;
        public Color SpriteColor;
        #endregion

        public Basic2D(Vector2 POSITION, Vector2 DIMS, string LABEL)
        {
            Position = POSITION;
            Dimensions = DIMS;
            Label = String.IsNullOrEmpty(LABEL) ? "" : LABEL;
            SpriteColor = Color.White;
        }

        #region Methods

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void Draw()
        {
            Draw(Vector2.Zero);
        }

        public virtual void Draw(Vector2 OFFSET)
        {
            if (Texture != null)
            {
                LibGlobals.LibSpriteBatch.Draw(Texture,
                    new Rectangle((int)(Position.X + OFFSET.X), (int)(Position.Y + OFFSET.Y),
                    (int)(Dimensions.X), (int)(Dimensions.Y)),
                    null, Color.White, 0.0f,
                    new Vector2(Texture.Bounds.Width / 2, Texture.Bounds.Height / 2),
                    new SpriteEffects(), 0)
                    ;
            }
        }

        #endregion
    }
}
