using CrimsonEngine.SimpleGame.Game_objects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CrimsonEngine.SimpleGame
{
    class World
    {
        public List<Basic2D> Sprites;
        public List<IBasicDraw> SpritesToDraw;
        public List<IBasicUpdate> SpritesToUpdate;
        public MultipleRooms Rooms;
        public MultipleItems Items;
        public Player PlayerInstance;
        public GameStates GAME_STATE;
        public CurrentState GameState;

        public World()
        {
            Sprites = new List<Basic2D>();
            SpritesToDraw = new List<IBasicDraw>();
            SpritesToUpdate = new List<IBasicUpdate>();
            GAME_STATE = GameStates.GAME;
        }

        public void AddSprite(Basic2D Siema)
        {
            SpritesToDraw.Add(Siema);
            SpritesToUpdate.Add(Siema);
            Sprites.Add(Siema);
        }

        public string GenerateWorld()
        {
            string result = "";

            #region ITEMS
            Console.WriteLine("Generating items . . .");
            Items = new MultipleItems();
            Items.Items.Add(new Item("Stick", "ITEM." + Guid.NewGuid().ToString().ToUpper(), 0.0f, "ACTIVE"));
            Items.Items.Last().AddDescription("Just a stick made out of wood.");
            Items.Items.Last().AddDescription("Stick... nothing else to say.");

            Items.Items.Add(new Item("Coin", "ITEM." + Guid.NewGuid().ToString().ToUpper(), 1.0f, "ACTIVE"));
            Items.Items.Last().AddDescription("Just a coin. Not much, but it's better than nothing.");

            Items.Items.Add(new Item("Knife", "ITEM." + Guid.NewGuid().ToString().ToUpper(), 5.0f, "ACTIVE"));
            Items.Items.Last().AddDescription("Sharp knife. It's good for defending yourself or slicing bread.");
            Items.Items.Last().AddDescription("Simple knife. It cuts. It slices. It's a basic knife.");

            Items.Items.Add(new Item("Sharp stick", "ITEM." + Guid.NewGuid().ToString().ToUpper(), 0.0f, "ACTIVE"));
            Items.Items.Last().AddDescription("It's a very sharp stick. You should be careful with it.");

            Items.Items.Add(new Item("Tarock card (XIII)", "ITEM." + Guid.NewGuid().ToString().ToUpper(), 0.0f, "ACTIVE"));
            Items.Items.Last().AddDescription("Card of the 'Death' with a  very nice skeleton with sycle.");
            Items.Items.Last().AddDescription("Pretty card with number XIII and label 'Death'.");

            Items.Items.Add(new Item("Tarock card (XVI)", "ITEM." + Guid.NewGuid().ToString().ToUpper(), 0.0f, "ACTIVE"));
            Items.Items.Last().AddDescription("'The Tower' card. It's not really good.");
            Items.Items.Last().AddDescription("Tarock card with a picture of tower struck by lightning.");

            Items.Items.Add(new Item("Red button", "ITEM." + Guid.NewGuid().ToString().ToUpper(), 0.0f, "PASSIVE"));
            Items.Items.Last().AddDescription("Big red button. Nobody knows what it does...");
            Items.Items.Last().AddDescription("A button - nothing else, nothing more. It's even red!");

            Console.WriteLine("{0} items created.", Items.Items.Count);
            Console.WriteLine("DONE!");
            //Items.Items.Last().AddDescription("");
            #endregion

            #region ROOMS
            Console.WriteLine("Generating rooms . . .");
            Rooms = new MultipleRooms();

            Rooms.Rooms.Add(new Room());
            Rooms.Rooms.Last().Name = "Open field";
            Rooms.Rooms.Last().AddDescription("A large field with nothing around you. Just sand and scrapes of steel." +
                " You see a house in front of you.");
            //Rooms.Rooms.Last().Items.Add()


            Rooms.Rooms.Add(new Room());
            Rooms.Rooms.Last().Name = "Big room";
            Rooms.Rooms.Last().AddDescription("Room with lots to stuff to pick. But you're not a thief," +
                "so you politely won't touch anything here. Right?");

            Rooms.Rooms.Add(new Room());
            Rooms.Rooms.Last().Name = "Closet";
            Rooms.Rooms.Last().AddDescription("It's very comfy in here... not!");
            Rooms.Rooms.Last().AddDescription("A small closet. Nothing fancy & nothing special.");

            Rooms.Rooms.Add(new Room());
            Rooms.Rooms.Last().Name = "Lobby";
            Rooms.Rooms.Last().AddDescription("Very small lobby. There're two doors here.");
            Rooms.Rooms.Last().AddDescription("Nothing special, but you can see doors leading to somewhere.");

            // DIRECTIONS
            Rooms.Rooms[0].Directions.Add(new KeyValuePair<string, string>("North", Rooms.Rooms.First(r => r.Name == "Lobby").Id));
            Rooms.Rooms[1].Directions.Add(new KeyValuePair<string, string>("South", Rooms.Rooms.First(r => r.Name == "Open field").Id));
            Rooms.Rooms[1].Directions.Add(new KeyValuePair<string, string>("Door I", Rooms.Rooms.First(r => r.Name == "Big room").Id));
            Rooms.Rooms[2].Directions.Add(new KeyValuePair<string, string>("Door I", Rooms.Rooms.First(r => r.Name == "Lobby").Id));
            Rooms.Rooms[1].Directions.Add(new KeyValuePair<string, string>("Door II", Rooms.Rooms.First(r => r.Name == "Closet").Id));
            Rooms.Rooms[3].Directions.Add(new KeyValuePair<string, string>("Door II", Rooms.Rooms.First(r => r.Name == "Lobby").Id));

            // ITEMS IN ROOMS

            Console.WriteLine("{0} rooms created.", Rooms.Rooms.Count);
            Console.WriteLine("DONE!");
            #endregion

            #region PLAYER
            Console.WriteLine("Creating player instance . . .");
            GameState = new CurrentState(new Player("Crimson"), Rooms.Rooms.First());

            GameState.PlayerInstance.Inventory.Add(Items.Items[2]);
            GameState.PlayerInstance.Inventory.Add(Items.Items[1]);
            Console.WriteLine("DONE!");
            #endregion

            result = String.Format("");

            return result;
        }

        public void Draw()
        {
            foreach(var x in SpritesToDraw)
            {
                x.Draw();
            }
        }

        public void Update()
        {
            foreach (var x in SpritesToUpdate)
            {
                x.Update();
            }
        }

        public override string ToString()
        {
            string result = "...work in progress...";

            // TO DO!

            return result;
        }
    }
}
