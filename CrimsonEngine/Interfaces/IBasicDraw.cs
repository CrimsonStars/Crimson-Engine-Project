using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrimsonEngine
{
    public interface IBasicDraw
    {
        void Draw();
        void Draw(Vector2 OFFSET);
    }
}
