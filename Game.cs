using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace DungeonExplorer
{
    internal class Game
    {
        public int CurrentRoom { get; private set; }
        public int MaxRooms { get; private set; }
        public List<Room> MapRooms { get; private set; } = new List<Room>();
        public Player Player { get; private set; }

        public Game(Player player, int rooms)
        {
            Player = player;
            MaxRooms = rooms;
            CurrentRoom = 0;
            Debug.Assert(0 < MaxRooms, $"{MaxRooms} rooms were generated");
            InitializeGame();
        }
        private void InitializeGame()
        {
            Random rng = new Random();
            List<Entity> itemTemplate = new List<Entity>
            {
                new Weapon("Sword", 30),
                new Weapon("Gun", 50),
                new Potion("Apple", 10),
                new Potion("Steak", 30)
            };
            
            List<Entity> monsterTemplate = new List<Entity>
            {
                new Zombie("Luca", 50,10, GetRandomItem(itemTemplate,2)),
                new Zombie("Tyler", 125,25, GetRandomItem(itemTemplate,1)),
                new Creeper("Fredrick", 75,15, GetRandomItem(itemTemplate,4)),
                new Creeper("DanTheMan", 100,20, GetRandomItem(itemTemplate,3))

            };

            List<Entity> GetRandomItem(List<Entity> source, int count)
            {
                return source.OrderBy(x => rng.Next()).Take(count).ToList();
            }

            string[] roomNames = { "A cold room", "A dark room", "A cave system", "A small room" };

            for (int item = 0; item < 1; item++)
            {
                Player.AddToInv(itemTemplate[rng.Next(itemTemplate.Count)]);
            }

            for (int room = 0; room < MaxRooms; room++)
            {
                MapRooms.Add(new Room(roomNames[rng.Next(roomNames.Length)]));
            }

            for (int room = 0; room < MaxRooms; room++)
            {
                MapRooms[room].AddToInv(monsterTemplate[rng.Next(monsterTemplate.Count)]);
            }
        }
        private void MoveRooms()
        {
            string movementText = "You can";
            if (MaxRooms == 1)
            {
                movementText += "not move anywhere";
                Console.WriteLine(movementText);
            }
            else
            {
                bool moveLeft = false;
                bool moveRight = false;
                if (CurrentRoom != 0 && MaxRooms != 1)
                {
                    movementText += ", move to the left";
                    moveLeft = true;
                }
                if (CurrentRoom != MaxRooms - 1 && MaxRooms != 1)
                {
                    movementText += ", move to the right";
                    moveRight = true;
                }
                Console.WriteLine($"{movementText}, where do you want to go?");
                string movement = Console.ReadLine();
                if ("left".Equals(movement, StringComparison.OrdinalIgnoreCase) && moveLeft)
                {
                    CurrentRoom -= 1;
                }
                else if ("right".Equals(movement, StringComparison.OrdinalIgnoreCase) && moveRight)
                {
                    CurrentRoom += 1;
                }
                else
                {
                    Console.WriteLine("Choose a valid option");
                }
            }
        }
        private void EnterRoom()
        {
            Room room = MapRooms[CurrentRoom];
            Console.WriteLine("You have entered the room");
            room.GetDescription();

            while (true)
            {
                Console.Write("Who would you want to attack? (Select a valid name) > ");
                string monsterName = Console.ReadLine();

                //List<Entity> monsters = MapRooms[CurrentRoom].ReturnInventory();
                Entity monsterResult = room.ReturnInventoryEntity(monsterName);
                if (monsterResult != null){
                    Player.GetDescription();
                    Console.Write("What item do you want to use? (Select a valid name) > ");
                    string itemName = Console.ReadLine();

                    Entity itemResult = Player.ReturnInventoryEntity(monsterName);
                    if (itemResult != null)
                    {
                    }
                    else
                    {
                    }
                }
                else {
                    Console.WriteLine("Choose a valid option");
                    continue;
                }

                    break;
            }


            return;

            //if (items.Count != 0)
            //{
            //    Console.WriteLine($"There are {items.Count} items, which do you want to pick up: {allRooms[currentRoom].ItemsContents()}");
            //    string selectedItem = Console.ReadLine();

            //    bool found = false;
            //    foreach (string item in items)
            //    {
            //        if (selectedItem.Equals(item, StringComparison.OrdinalIgnoreCase))
            //        {
            //            found = true;
            //            allRooms[currentRoom].DeleteItem(item);
            //            player.PickUpItem(item);
            //            break;
            //        }
            //    }
            //    if (!found)
            //    {
            //        Console.WriteLine("Choose a valid option");
            //    }
            }
        public void Start()
        {
            bool playing = true;
            while (playing)
            {
                Console.WriteLine($"\nWhat would you like to do {Player.Name}?\n1. View room's description\n2. Display your status\n3. Enter Room\n4. Move Rooms\n5. End Game");
                int.TryParse(Console.ReadLine(), out int choice);
                Console.WriteLine();
                switch (choice)
                {
                    case 1:
                        MapRooms[CurrentRoom].GetDescription();
                        break;

                    case 2:
                        Player.GetDescription();
                        break;

                    case 3:
                        EnterRoom();
                        break;

                    case 4:
                        MoveRooms();
                        break;

                    case 5:
                        playing = false;
                        break;

                    default:
                        Console.WriteLine("Choose a valid option");
                        break;

                }
            }
        }
    }
}