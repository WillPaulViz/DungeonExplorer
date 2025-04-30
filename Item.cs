using System;

namespace DungeonExplorer
{
    public abstract class Item
    {
        public string Name { get; protected set; }
        public Item(string name)
        {
            Name = name;
        }
        public virtual void SayAction() { }
    }
    public class Weapon : Item
    {
        public int Damage { get; private set; }
        public Weapon(string name, int damage) : base(name)
        {
            Damage = damage;
        }
        public override void SayAction()
        {
            Console.WriteLine($"Weapon: {Name}, Damage: {Damage}");
        }
    }
    public class Potion : Item
    {
        public int Health { get; private set; }
        public Potion(string name, int health) : base(name)
        {
            Health = health;
        }
        public override void SayAction()
        {
            Console.WriteLine($"Potion: {Name}, Health: {Health}");
        }
    }
}
