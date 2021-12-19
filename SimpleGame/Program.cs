using System;

namespace CrimsonEngine.GL
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new SimpleGame())
                game.Run();
        }
    }
}
