using System;
using System.Collections.Generic;
using System.Text;

namespace CrimsonEngine.SimpleGame
{
    public sealed class Properties
    {
        private static Properties _instance = null;
        private static readonly object padlock = new object();

        public string WindowTitle { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Framerate { get; set; }
        public string Version { get; set; }
        public bool IsBeta { get; set; }

        private Properties()
        {
            Framerate = 60;
            Height = 320;
            Width = 640;
            WindowTitle = "Single game - Tests - Crimson Engine";

            Version = String.Format("{0}.{1}.{2}", 0, 0, 1);
            if (IsBeta)
            {
                Version += "b";
            }
        }

        public static Properties Instance
        {
            get
            {
                lock (padlock)
                {
                    if (_instance == null)
                    {
                        _instance = new Properties();
                    }
                    return _instance;
                }
            }
        }
    }
}
