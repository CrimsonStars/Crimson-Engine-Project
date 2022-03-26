
using System;
using System.Collections.Generic;
using System.Text;

namespace CrimsonEngine.SimpleGame.Game_objects
{
    class CurrentState
    {
        public Player PlayerInstance;
        public Room CurrentRoom;

        public CurrentState(Player PLAYER, Room CURRENT_ROOM)
        {
            PlayerInstance = PLAYER;
            CurrentRoom = CURRENT_ROOM;
        }

        #region Game actions
        /* 
         * RemoveItemFromInventory
         * AddItemToInventory
         * ReplaceItem
         * GoDirection
         * 
         */
        #endregion
    }
}
