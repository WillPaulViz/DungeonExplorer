using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace DungeonExplorer
{
    internal class Game
    {
        public int CurrentRoom;
        public int MaxRooms;
        public List<Room> MapRooms = new List<Room>();
        public Player Player;

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
            
            List<Character> monsterTemplate = new List<Character>
            {
                new Zombie("Luca", 50,10, Entity.GetRandomItems()),
                new Zombie("Tyler", 125,25, Entity.GetRandomItems()),
                new Creeper("Fredrick", 75,15, Entity.GetRandomItems()),
                new Creeper("DanTheMan", 100,20, Entity.GetRandomItems())
            };

            string[] roomNames = { "A cold room", "A dark room", "A cave system", "A small room" };

            for (int item = 0; item < rng.Next(1,4); item++)
            {
                Player.AddToInv(Entity.GetRandomItems()[rng.Next(Entity.GetRandomItems().Count)]);
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
                string movement = CleanInput();
                if ("left" == movement && moveLeft)
                {
                    CurrentRoom -= 1;
                }
                else if ("right" == movement && moveRight)
                {
                    CurrentRoom += 1;
                }
                else
                {
                    Console.WriteLine("Choose a valid option");
                }
            }
        }
        private string CleanInput()
        {
            string cleaned = "";
            foreach (char c in Console.ReadLine())
            {
                if (!char.IsWhiteSpace(c))
                {
                    cleaned += char.ToLower(c);
                }
            }
            return cleaned;
        }
        private void EnterRoom()
        {
            Console.WriteLine("You have entered the room");

            Random rng = new Random();
            while (true)
            {

                MapRooms[CurrentRoom].GetDescription();
                Console.Write("\nWho would you want to attack? (Select a valid name) > ");
                string monsterName = CleanInput();

                int monsterIndex = MapRooms[CurrentRoom].ReturnInventoryIndex(monsterName);
                if (monsterIndex != -1){
                    Console.WriteLine();
                    Player.GetDescription();
                    Console.Write("What item do you want to use? (Choose an item or 'random'/'hands'/'exit') > ");
                    string itemName = CleanInput();
                    int itemIndex = Player.ReturnInventoryIndex(itemName);
                    int damage;

                    if (itemName == "exit") 
                    {
                        break;
                    }
                    else if (itemName == "hands")
                    {
                        damage = Player.Damage;

                    }
                    else if (itemName == "random")
                    {
                        Player.AddToInv(Entity.GetRandomItems()[0]);
                        Console.WriteLine("You got a new item");
                        break;
                    }
                    else if (itemIndex != -1 && Player.Inventory.Count != 0)
                    {
                        damage = ((Item)Player.Inventory[itemIndex]).GetDMG();
                        Player.DelFromInvIndex(itemIndex);
                    }
                    else
                    {
                        Console.WriteLine("Choose a valid option");
                        continue;
                    }


                    if (damage < 0)
                    {
                        Player.TakeDMG(damage);
                        Console.WriteLine($"You healed {damage} HP");
                    }
                    else
                    {
                        ((Character)MapRooms[CurrentRoom].Inventory[monsterIndex]).TakeDMG(damage);
                        Console.WriteLine($"You dealt {damage} damage");
                    }
                    
                    
                    int randomMonster = rng.Next(MapRooms[CurrentRoom].Inventory.Count);
                    Character monster = (Character)MapRooms[CurrentRoom].Inventory[randomMonster];
                    
                    Console.WriteLine($"A {monster.Name} comes back with a random item.");
                    if (monster.Inventory.Count != 0)
                    {
                        damage = ((Item)monster.Inventory[rng.Next(monster.Inventory.Count)]).GetDMG();
                        MapRooms[CurrentRoom].Inventory[randomMonster].DelFromInvIndex(itemIndex);
                    }
                    else
                    {
                        damage = ((Character)MapRooms[CurrentRoom].Inventory[monsterIndex]).Damage;
                    }
                    if (damage < 0)
                    {
                        ((Character)MapRooms[CurrentRoom].Inventory[monsterIndex]).TakeDMG(damage);
                        Console.Write($"Monster healed {damage} HP");
                    }
                    else
                    {
                        Player.TakeDMG(damage);
                        Console.WriteLine($"You took {damage} HP");
                    }
                    
                }
                else {
                    Console.WriteLine("Choose a valid option");
                    continue;
                }
            
            return;
            }
        public void Start()
        {
            bool playing = true;
            while (playing)
            {
                Console.WriteLine($"\nWhat would you like to do {Player.Name}?\nTo use items go into a room\n\n1. Display your status\n2. View room's description\n3. Enter Room\n4. Move Rooms\n5. End Game");
                int.TryParse(Console.ReadLine(), out int choice);
                Console.WriteLine();
                switch (choice)
                {
                    case 1:
                        Player.GetDescription();
                        break;

                    case 2:
                        MapRooms[CurrentRoom].GetDescription();
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