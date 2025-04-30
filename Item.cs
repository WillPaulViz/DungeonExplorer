using System;

namespace DungeonExplorer
{
    public abstract class Item : Entity
    {
        public Item(string name) : base(name){}
        public virtual int UseItem(){ return 0; }
        }
    public class Weapon : Item
    {
        public int Damage { get; private set; }
        public Weapon(string name, int damage) : base(name)
        {
            Damage = damage;
        }
        public override void GetDescription()
        {
            Console.WriteLine($"Weapon: {Name}, Damage: {Damage}");
        }
        public override int UseItem()
        {
            return Damage;
        }
    }
    public class Potion : Item
    {
        public int Health { get; private set; }
        public Potion(string name, int health) : base(name)
        {
            Health = health;
        }
        public override void GetDescription()
        {
            Console.WriteLine($"Potion: {Name}, Health: {Health}");
        }
        public override int UseItem()
        {
            return -Health;
        }
    }
}
