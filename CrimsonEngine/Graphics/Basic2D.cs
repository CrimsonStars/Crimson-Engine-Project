using CrimsonEngine.Simple_math;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using System;

namespace CrimsonEngine.Graphics
{
    /// <summary>
    /// Basic static sprite in 2D with no movement or animation.
    /// </summary>
    public class Basic2D : IBasicUpdate, IBasicDraw
    {
        public Texture2D Texture { get; set; }
        public float Transparency { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Dimensions { get; set; }
        public bool DrawBoundingBox { get; set; } = true;

        public Basic2D(string TEXTURE_PATH, Vector2 POSITION, Vector2 DIMS)
        {
            Transparency = 1.0f;
            Position = POSITION;
            Dimensions = DIMS;

            try
            {
                Texture = LibGlobals.LibContentManager.Load<Texture2D>(TEXTURE_PATH);

                if (DIMS == Vector2.Zero && Texture != null)
                {
                    Dimensions = new Vector2(Texture.Width, Texture.Height);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(
                    String.Format("ERROR FOR: '{0}'\n{1}", TEXTURE_PATH, e.ToString())
                    );
            }
        }

        private Polygon GetBoundingPolygon()
        {
            Polygon res = new Polygon();

            var Dims = Vector2.Multiply(Dimensions, 0.5f);
            res.AddPoint(Position.X - Dims.X, Position.Y - Dims.Y);
            res.AddPoint(Position.X + Dims.X, Position.Y - Dims.Y);
            res.AddPoint(Position.X + Dims.X, Position.Y + Dims.Y);
            res.AddPoint(Position.X - Dims.X, Position.Y + Dims.Y);

            return res;
        }

        public virtual void Update()
        {

        }

        public virtual void Draw()
        {
            Draw(Vector2.Zero);
        }

        public virtual void Draw(Vector2 OFFSET)
        {
            if (Texture != null)
            {
                LibGlobals.LibSpriteBatch.Draw(
                    Texture,
                    new Rectangle(
                        (int)(Position.X + OFFSET.X),
                        (int)(Position.Y + OFFSET.Y),
                        (int)(Dimensions.X),
                        (int)(Dimensions.Y)
                        ),
                    null,
                    Color.White,
                    0.0f,
                    new Vector2(
                        Texture.Bounds.Width / 2, 
                        Texture.Bounds.Height / 2
                        ),
                    new SpriteEffects(),
                    0);

                if(DrawBoundingBox)
                {
                    GetBoundingPolygon().Draw();
                }
            }
        }
    }
}
