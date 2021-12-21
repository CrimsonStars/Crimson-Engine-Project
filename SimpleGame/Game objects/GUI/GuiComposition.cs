using CrimsonEngine.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGame.Game_objects.GUI
{
    public class GuiComposition
    {
        public List<Button2D> Buttons { get; set; }
        public List<Basic2D> Sprites { get; set; }
        private List<int> Labels;

        public GuiComposition()
        {
            Buttons = new List<Button2D>();
            Sprites = new List<Basic2D>();
        }

        public void AddButton(Button2D BUTTON)
        {
            Buttons.Add(BUTTON);
        }

        public void AddSprite(Basic2D SPRITE)
        {
            Sprites.Add(SPRITE);
        }

        public void Clear()
        {
            Sprites.Clear();
            Buttons.Clear();
        }

        public void Draw()
        {
            foreach(var s in Sprites)
            {
                s.Draw();
            }

            foreach(var b in Buttons)
            {
                b.Draw();
            }

            // draw labels/text
        }

        public void Update()
        {
            foreach (var s in Sprites)
            {
                s.Update();
            }

            foreach (var b in Buttons)
            {
                b.Update();
            }

            // update text/labels
        }
    }
}
