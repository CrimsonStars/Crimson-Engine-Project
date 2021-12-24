using CrimsonEngine;
using CrimsonEngine.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGame.Game_objects.GUI
{
    public class Button2D : Basic2D
    {
        public string Label;
        public Action ClickAction;

        public Button2D(string LABEL, string TEXTURE, Vector2 POSITION, Vector2 DIMS)
            : base(TEXTURE, POSITION, DIMS)
        {
            Label = LABEL;
        }


        public void WasButtonClicked()
        {

        }

        public void Click()
        {
            ClickAction.Invoke();
        }

        public void SetButtonAction(Action ACTION)
        {
            ClickAction = ACTION;
        }
    }
}
