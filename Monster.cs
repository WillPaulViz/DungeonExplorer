using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public abstract class Monster : Entity
    {
        public Monster(string name, int health, int damage) : base(name, health, damage) { }
        public virtual void MakeNoise() { }
    }
    public class Zombie : Monster
    {
        public Zombie(string name, int health, int damage) : base(name, health, damage) { }
        public override void MakeNoise()
        {
            Console.WriteLine("aaaauuuugggghhhh");
        }
        public override void GetDescription()
        {
            Console.WriteLine($"Creeper: {Name}, Health: {Health}, Damage: {Damage}");
            InventoryContents();
        }
    }
    public class Creeper : Monster
    {
        public Creeper(string name, int health, int damage) : base(name, health, damage) { }
        public override void MakeNoise()
        {
            Console.WriteLine("ZZZZzzzz....BOOM");
        }
        public override void GetDescription()
        {
            Console.WriteLine($"Zombie: {Name}, Health: {Health}, Damage: {Damage}");
            InventoryContents();
        }
    }
}
