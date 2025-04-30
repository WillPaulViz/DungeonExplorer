using System;

namespace DungeonExplorer
{
    public class Player : Character
    {
        public Player(string name, int health, int damage) : base(name, health, damage) { }
        public override void GetDescription()
        {
            Console.WriteLine($"Player: {Name}, Health: {Health}, Damage: {Damage}");
            InventoryContents();
        }
    }
}