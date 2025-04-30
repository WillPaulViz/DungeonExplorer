using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Room
    {
        public string Name { get; private set; }
        public List<Monster> Monsters { get; private set; }

        public Room(string name, List<Monster> monsters)
        {
            Name = name;
            Monsters = monsters;
        }
        public void MonstersContents()
        {
            if (Monsters.Count != 0)
            {
                foreach (Monster monster in Monsters)
                {
                    monster.GetDescription();
                    monster.MakeNoise();
                }
            }
            else
            {
                Console.WriteLine("No Monsters");
            }
        }
        public void GetDescription()
        {
            Console.WriteLine(Name);
            MonstersContents();
        }
    }
}