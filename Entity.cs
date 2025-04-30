using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public abstract class Entity
    {
        public string Name { get; private set; }
        public List<Entity> Inventory { get; protected set; } = new List<Entity>();

        public Entity(string name)
        {
            Name = name;
        }
        
        public virtual void GetDescription() { }
        
        public void InventoryContents()
        {
            if (Inventory.Count != 0)
            {
                foreach (Entity entity in Inventory)
                {
                    entity.GetDescription();
                }
            }
            else
            {
                Console.WriteLine("Nothing in inventory");
            }

        }
    }
}
