using System;
using System.Collections.Generic;
using System.Text;

namespace CrimsonEngine.SimpleGame.Game_objects
{
    class Player
    {
        public string Name;
        public List<Item> Inventory;

        public Player(string NAME)
        {
            Name = NAME;
            Inventory = new List<Item>();

        }
    }
}
