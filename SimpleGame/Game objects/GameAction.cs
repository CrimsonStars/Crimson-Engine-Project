using System;
using System.Collections.Generic;
using System.Text;

namespace CrimsonEngine.SimpleGame.Game_objects
{
    class GameAction
    {
        public string ActionString;
        public delegate int Akcja(string Input0, string Input1);

        public GameAction() { }

        public GameAction(string ACTION_STRING)
        {

        }

        public GameAction ParseScript(string SCRIPT)
        {
            GameAction ga = new GameAction();



            return ga;
        }
    }
}
