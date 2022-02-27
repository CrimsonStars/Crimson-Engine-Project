﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CrimsonEngine.Globals
{
    public static class LibDebugGlobals
    {
        private static List<string> fontsList;
        private static bool wasInitialised = false;
        private static int lastRandomisedNumber = -1;

        private static void InitializeAllElements()
        {
            fontsList = new List<string>();
            fontsList.Add("Gamepixies");
            fontsList.Add("LittleMissLoudonBold");
            fontsList.Add("PressStart2P");
        }

        public static string GetRandomFontName()
        {
            Random rnd = new Random();
            string result = "";

            if (!wasInitialised)
            {
                InitializeAllElements();
                wasInitialised = true;
            }

            int randomNumber;
            do
            {
                randomNumber = rnd.Next(0, fontsList.Count);
                lastRandomisedNumber = randomNumber;
            }
            while (randomNumber != lastRandomisedNumber);

            if (!fontsList.Any())
            {
                return result;
            }

            return fontsList.ElementAtOrDefault(randomNumber);
        }
    }
}
