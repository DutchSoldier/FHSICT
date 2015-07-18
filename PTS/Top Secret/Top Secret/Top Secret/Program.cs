using System;

namespace Top_Secret
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (TopSecret game = new TopSecret())
            {
                game.Run();
            }
        }
    }
#endif
}

