using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrimsonEngine.Graphics.GUI
{
    interface IClickable
    {
        bool Hovered();
        bool IsClicked();
    }
}
