using System;
using System.Collections.Generic;
using System.Diagnostics;

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
            InitializeRoom();
        }
        private void InitializeRoom()
        {
            

            
            List<Item> itemTemplate = new List<Item>
            {
                new Weapon("Sword", 30),
                new Weapon("Gun", 50),
                new Potion("Apple", 10),
                new Potion("Steak", 30)
            };
            List<Monster> monsterTemplate = new List<Monster>
            {
                new Zombie("Dr. Dre", 50,10),
                new Zombie("Tyler", 125,25),
                new Creeper("Fredrick", 75,15),
                new Creeper("Dan the Man", 100,20)
            };
            string[] roomNames = { "A cold room", "A dark room", "A cave system", "A room" };

            Random r = new Random();
            int rPlayerItemAmmount = r.Next(0, 5);

            for (int item = 0; item < rPlayerItemAmmount; item++)
            {
                Player.AddItem(itemTemplate[r.Next(0, itemTemplate.Count)]);
            }

            for (int room = 0; room < MaxRooms; room++)
            {
                int rMonsterSpawnAmmount = r.Next(0, 4);
                int rMonsterItemAmmount = r.Next(0, 3);
                List<Monster> monsters = new List<Monster>();
                for (int monster = 0; monster < rMonsterSpawnAmmount; monster++)
                {
                    monsters.Add(monsterTemplate[r.Next(0, monsterTemplate.Count)]);
                    for (int item = 0; item < rMonsterItemAmmount; item++)
                    {
                        monsters[monster].AddItem(itemTemplate[r.Next(0, itemTemplate.Count)]);
                    }
                }
                MapRooms.Add(new Room(roomNames[r.Next(0, roomNames.Length)], monsters));
            }
        }
        private void MoveRooms()
        {
            string movementText = "You can";
            if (MaxRooms == 1)
            {
                movementText = "not move anywhere";
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
        private void BattleStart()
        {

        }
        public void Start()
        {
            bool playing = true;
            while (playing)
            {
                Console.WriteLine($"\nWhat would you like to do {Player.Name}?\n1. View room's description\n2. Display your status\n3. Pick up an item\n4. Move room\n5. End Game");
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
                        BattleStart();
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