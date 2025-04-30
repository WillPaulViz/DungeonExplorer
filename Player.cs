using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player : Entity
    {
        public Player(string name, int health, int damage) : base(name, health, damage) { }
        public override void GetDescription()
        {
            Console.WriteLine($"Player: {Name}, Health: {Health}, Damage: {Damage}");
            InventoryContents();
        }
    }
}