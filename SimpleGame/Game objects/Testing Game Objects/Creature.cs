using System;
using System.Collections.Generic;
using System.Text;

namespace CrimsonEngine.SimpleGame.Game_objects.Testing_Game_Objects
{
    public class Creature
    {
        public int HealthPoints;
        public int MagicPoints;
        public string Name { get; set; }


        /// <summary>
        /// Generates a random "monster" creature.
        /// </summary>
        public Creature()
        {
            Random rnd = new Random();
            int randomIntValue = rnd.Next(0, 2);
            Console.WriteLine(GenerateRandomCreature(randomIntValue));
        }

        public string GenerateRandomCreature(int INDEX = 0)
        {
            string result;

            if (INDEX == 0)
            {
                Name = "Wolf";
                HealthPoints = 0;
                HealthPoints = 0;
            }
            else if (INDEX == 1)
            {
                Name = "";
                HealthPoints = 0;
                MagicPoints = 0;
            }
            else if (INDEX == 2)
            {
                Name = "";
                HealthPoints = 0;
                MagicPoints = 0;
            }

            result = String.Format("-- GENERATED RANDOM CRETURE --\n" +
                "NAME:\t{0}\nHP:\t{1}\nMP:\t{2}",
                Name,HealthPoints,MagicPoints);

            return result;
        }
    }
}
