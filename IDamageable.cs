﻿namespace DungeonExplorer
{
    interface IDamageable
    {
        int Health { get; }
        int MaxHealth { get; }
        int Damage { get; }

        void TakeDMG(int damage);
    }
}
