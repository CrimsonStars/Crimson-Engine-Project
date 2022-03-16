using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CrimsonEngine.Globals
{
    public static class LibDebugGlobals
    {
        private static List<(string fontname, string path)> fontsList;
        private static bool wasInitialised = false;
        private static int lastRandomisedNumber = -1;

        private static void InitializeAllElements()
        {
            fontsList = new List<(string fontname, string path)>();

            fontsList.Add(("Pixeloid - 8", "fonts/Pixeloid_regular_8"));
            fontsList.Add(("Pixeloid - 10", "fonts/Pixeloid_regular_10"));
            fontsList.Add(("Pixeloid - 12", "fonts/Pixeloid_regular_12"));
            fontsList.Add(("Pixeloid - 18", "fonts/Pixeloid_regular_18"));
        }

        public static string GetRandomFontName()
        {
            Random rnd = new Random();
            string result = "";
            int randomNumber = -1;


            if(!wasInitialised)
            {
                InitializeAllElements();
                wasInitialised = true;
            }
            
            do
            {
                randomNumber = rnd.Next(0, fontsList.Count);
                lastRandomisedNumber = randomNumber;
            } 
            while (randomNumber != lastRandomisedNumber);


            if(!fontsList.Any()) return result;

            return fontsList.ElementAtOrDefault(randomNumber).path;
        }
    }
}
