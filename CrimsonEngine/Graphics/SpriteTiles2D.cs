using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrimsonEngine.Graphics
{
    class SpriteTiles2D : Basic2D, IBasicDraw, IBasicUpdate
    {
        public int X_Index { get; set; }
        public int Y_Index { get; set; }
        public int WidthTiles { get; set; }
        public int HeightTiles { get; set; }
        public int TileSizeInPixels { get; set; }

        public SpriteTiles2D(
            string TexturePath,
            Vector2 Position, Vector2 Dimensions,
            int x_Index, int y_Index,
            int widthTiles, int heightTiles,
            int tileSizeInPixels = 16)
            : base(TexturePath, Position, Dimensions)
        {
            X_Index = x_Index;
            Y_Index = y_Index;
            WidthTiles = widthTiles;
            HeightTiles = heightTiles;
            TileSizeInPixels = tileSizeInPixels;
        }

        public override void Draw()
        {
            Draw(Vector2.Zero);
        }

        public override void Draw(Vector2 OFFSET)
        {
            throw new NotImplementedException();
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
