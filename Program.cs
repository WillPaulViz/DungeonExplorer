using System;

namespace DungeonExplorer
{
    internal class Program
    {
        /// <summary>
        /// start of the program
        /// </summary>
        static void Main()
        {
            /// <summary>
            /// start the game in a try-catch, in case there was unexpected error
            /// </summary>
            try
            {
                Console.WriteLine("What username do you want?");
                Game game = new Game(Console.ReadLine(),10);
                game.Start();
            }
            catch ( Exception e) 
            {
                Console.WriteLine("Fatal error made game crash: "+e);
            }
            finally
            {
                Console.WriteLine("Goodbye!\nPress any key to exit...");
                Console.ReadKey();
            }
            
        }
    }
}
