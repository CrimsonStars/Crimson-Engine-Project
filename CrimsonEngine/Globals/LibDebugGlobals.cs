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

            fontsList.Add(("pixeloid_12", "fonts/pixeloid_12"));
            fontsList.Add(("pixeloid_24", "fonts/pixeloid_24"));
            fontsList.Add(("pixeloid_32", "fonts/pixeloid_32"));
            fontsList.Add(("pixeloid_32_bold", "fonts/pixeloid_32_bold"));
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
