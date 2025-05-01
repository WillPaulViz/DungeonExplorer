using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Room : Entity
    {
        public Room(string name) : base(name) { }
        public override void GetDescription()
        {
            Console.WriteLine(Name);
            InventoryContents();
        }
    }
}