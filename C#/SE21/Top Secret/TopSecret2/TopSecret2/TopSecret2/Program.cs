using System;

namespace TopSecret2
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (TopSecret2 game = new TopSecret2())
            {
                game.Run();
            }
        }
    }
#endif
}

