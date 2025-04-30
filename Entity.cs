using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public abstract class Entity : IDamageable
    {
        public string Name { get; private set; }
        public int Health { get; protected set; }
        public int MaxHealth { get; protected set; }
        public int Damage { get; protected set; }
        public List<Item> Inventory { get; protected set; } = new List<Item>();
        public Entity(string name, int health, int damage)
        {
            Name = name;
            Health = health;
            MaxHealth = health;
            Damage = damage;
        }
        public virtual void GetDescription() { }
        public bool AddItem(Item item)
        {
            if (item != null)
            {
                Inventory.Add(item);
                return true;
            }
            return false;
        }
        public void InventoryContents()
        {
            if (Inventory.Count != 0)
            {
                foreach (Item item in Inventory)
                {
                    item.SayAction();
                }
            }
            else
            {
                Console.WriteLine("Nothing in inventory");
            }

        }
    }
}
