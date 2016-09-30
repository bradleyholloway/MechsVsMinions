using System;

namespace MechsVsMinions
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (MechsVsMinions game = new MechsVsMinions())
            {
                game.Run();
            }
        }
    }
#endif
}

