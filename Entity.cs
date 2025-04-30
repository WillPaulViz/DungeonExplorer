using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public abstract class Entity
    {
        public string Name { get; private set; }
        public List<Entity> Inventory { get; }

        public Entity(string name, List<Entity> entities = null)
        {
            Name = name;
            Inventory = entities ?? new List<Entity>();
        }

        public virtual void GetDescription() { }

        public bool AddToInv(Entity entity)
        {
            if (entity != null)
            {
                Inventory.Add(entity);
                return true;
            }
            return false;
        }
        public bool DelFromInv(Entity entity)
        {
            if (entity != null)
            {
                return Inventory.Remove(entity);
            }
            return false;
        }
        public int ReturnInventoryIndex(string name)
        {
            if (Inventory.Count != 0)
            {
                for (int i = 0; i < Inventory.Count; i++)
                {
                    if (Inventory[i].Name == name)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }
        public Entity ReturnInventoryEntity(string name)
        {
            if (Inventory.Count != 0)
            {
                for (int i = 0; i < Inventory.Count; i++)
                {
                    if (Inventory[i].Name == name)
                    {
                        return Inventory[i];
                    }
                }
            }
            return null;
        }
        public List<Entity> ReturnInventory()
        {
            return Inventory;
        }


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
