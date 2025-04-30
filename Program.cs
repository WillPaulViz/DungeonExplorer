using System;

namespace DungeonExplorer
{
    internal class Program
    {
        static void Main()
        {
            try
            {
                string username;
                int roomInt;

                while (true)
                {
                    Console.Write("Enter username (No Null/Space) > ");
                    username = Console.ReadLine();

                    if (!string.IsNullOrEmpty(username))
                    {
                        break;
                    }

                    Console.WriteLine("Choose a valid option");
                }

                while (true)
                {

                    Console.Write("Enter room ammount, (Greater Than 0) ? > ");
                    int.TryParse(Console.ReadLine(), out roomInt);

                    if (roomInt > 0)
                    {
                        break;
                    }

                    Console.WriteLine("Choose a valid option");
                }

                Player player = new Player(username, 100, 25);
                Game game = new Game(player, roomInt);
                game.Start();
            }

            catch (Exception e) 
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
