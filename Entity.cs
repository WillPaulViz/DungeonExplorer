using System;
using System.Collections.Generic;
using System.Linq;

namespace DungeonExplorer
{
    public abstract class Entity
    {
        public string Name;
        public List<Entity> Inventory;

        public Entity(string name, List<Entity> entities = null)
        {
            Name = name;
            Inventory = entities ?? new List<Entity>();
        }

        public static List<Entity> GetRandomItems()
        {
            List<Entity> itemTemplate = new List<Entity>
            {
                new Weapon("Sword", 30),
                new Weapon("Gun", 50),
                new Potion("Apple", 10),
                new Potion("Steak", 30)
            };

            Random rng = new Random();
            return itemTemplate.OrderBy(x => rng.Next()).Take(rng.Next(itemTemplate.Count)).ToList();
        }

        public virtual void GetDescription() { }

        public void AddToInv(Entity entity)
        {
            if (entity != null)
            {
                Inventory.Add(entity);
            }
            else
            {
                Console.WriteLine("Couldn't Add");
            }
        }
        public void DelFromInvIndex(int index)
        {
            if (index >= 0 && index < Inventory.Count)
            {
                Inventory.RemoveAt(index);
            }
            else
            {
                Console.WriteLine("Couldn't Delete");
            }
        }
        public int ReturnInventoryIndex(string name)
        {
            if (Inventory.Count != 0)
            {
                for (int i = 0; i < Inventory.Count; i++)
                {
                    if (Inventory[i].Name.ToLower() == name)
                    {
                        return i;
                    }
                }
            }
            return -1;
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
