using ImGuiNET;
using Microsoft.Xna.Framework;
using MonoGame.ImGui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGame.Game_objects.GUI
{
    public class ImGuiDebug
    {
        private ImGUIRenderer Renderer;

        #region Not so much used variables
        private int SeletedItemIndex = -1;
        private string[] Items = { "Jeden", "Dwa", "Trzy" };
        private List<string> History = new List<string>();
        private Queue<string> historyQ = new Queue<string>();
        private const int HistoryLength = 4;
        #endregion

        public ImGuiDebug(Game GAME)
        {
            Renderer = new ImGUIRenderer(GAME).Initialize().RebuildFontAtlas();
            for(int i=0; i<HistoryLength; i++)
            {
                historyQ.Enqueue("");
            }
        }

        public void Draw(GameTime GAMETIME)
        {
            Renderer.BeginLayout(GAMETIME);

            // ImGUI layout code
            bool p_open = true;

            ImGui.ShowDemoWindow();
            ImGui.Text("Lorem ipsum");
            if (ImGui.Button("Don't click me!"))
            {
                string txt = "";

                if (SeletedItemIndex < 0)
                {
                    txt = "Nothing was selected. (index: -1)";
                }
                else
                {
                    txt = String.Format("Selected item: {0} (index: {1})", Items[SeletedItemIndex], SeletedItemIndex);
                }

                Console.WriteLine(txt);
            }
            ImGui.Combo("Testing combo", ref SeletedItemIndex, Items, Items.Length);

            // semi-console?
            ImGui.Separator();
            foreach (var i in historyQ)
            {
                ImGui.TextUnformatted(i);
                ImGui.LogText(i);
            }

            bool reclaimFocus = false;
            int s = 16;
            string inputson = "";
            ImGuiInputTextFlags flagsony =
                ImGuiInputTextFlags.EnterReturnsTrue;

            if (ImGui.InputText("Command", ref inputson, (uint)s, flagsony) && !String.IsNullOrWhiteSpace(inputson))
            {
                Console.WriteLine(historyQ.Count);
                historyQ.Dequeue();
                historyQ.Enqueue(inputson);
                Console.WriteLine(inputson);

                if (String.Equals(inputson.ToUpper(), "ZIOM"))
                {
                    historyQ.Dequeue();
                    historyQ.Enqueue("Spoko komenda. Nieźle, co nie? LOL xD !!!!1!!1!1!");
                }

                reclaimFocus = true;
            }
            
            if(reclaimFocus)
            {
                ImGui.SetKeyboardFocusHere(-1);
            }

            ImGui.Separator();
            ImGui.Text("Room: ");
            ImGui.SameLine();
            ImGui.InputText("", ref inputson, (uint)4);
            ImGui.SameLine();
            if (ImGui.Button("Go!"))
            {
                Console.WriteLine(inputson);
            }


            Renderer.EndLayout();
        }

        public struct Fogo
        {
            public int a; 
            public int b;
        }

        public void Cebula(ref Fogo x)
        {
            x.a = 90;
            x.b = -10;
        }

        public void Update()
        {

        }
    }
}
