using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Zombie : Character
    {
        public Zombie(string name, int health, int damage, List<Entity> entity) : base(name, health, damage, entity) { }
        public override void GetDescription()
        {
            Console.WriteLine();
            Console.WriteLine($"Creeper: {Name}, Health: {Health}, Damage: {Damage}");
            InventoryContents();
        }
    }
    public class Creeper : Character
    {
        public Creeper(string name, int health, int damage, List<Entity> entity) : base(name, health, damage, entity) { }
        public override void GetDescription()
        {
            Console.WriteLine();
            Console.WriteLine($"Zombie: {Name}, Health: {Health}, Damage: {Damage}");
            InventoryContents();
        }
    }
}
