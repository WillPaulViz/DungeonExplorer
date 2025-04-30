using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Room : Entity
    {
        public Room(string name, List<Entity> monsters):base(name)
        {
            Inventory = monsters;
        }
        public override void GetDescription()
        {
            Console.WriteLine(Name);
            InventoryContents();
        }
    }
}