using SmurfEngine.Attributes;
using SmurfEngine.Items;
using SmurfEngine.UI;
using System;

namespace SmurfEngine.Characters
{
    public class Player : Character
    {
        public Player(string name, int health, Inventory inventory, CharacterStats stats) : base(name, health, inventory, stats)
        {
            this.Name = name;
            this.Health = health;
            this.Inventory = inventory;
            this.Stats = stats;
        }
    }
}