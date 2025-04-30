using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonExplorer
{
    public class Character : Entity, IDamageable
    {
        public int Health { get; protected set; }
        public int MaxHealth { get; protected set; }
        public int Damage { get; protected set; }
        public Character(string name, int health, int damage) : base(name)
        {
            Health = health;
            MaxHealth = health;
            Damage = damage;
        }
    }
}
