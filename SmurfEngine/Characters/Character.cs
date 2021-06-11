using SmurfEngine.Attributes;
using SmurfEngine.Items;
using SmurfEngine.UI;
using System;

namespace SmurfEngine.Characters
{
    public class Character
    {
        public string Name { get; set; }
        public virtual int Health { get; set; }
        public Inventory Inventory { get; set; }

        public CharacterStats Stats { get; set; }

        /// <summary>
        /// Creates a Character with stats defaulted to zero
        /// </summary>
        /// <param name="name">The name of the character.</param>
        /// <param name="health">The character's base health</param>
        /// <param name="inventory">The inventory for the chacter to have.</param>
        public Character(string name, int health, Inventory inventory, CharacterStats stats)
        {
            this.Name = name;
            this.Health = health;
            this.Inventory = inventory;
            this.Stats = stats;
        }

        /// <summary>
        /// Adds the item to the inventory by quantity amount.  
        /// </summary>
        /// <param name="item">The item to be added to the inventory.</param>
        /// <param name="quantity">The number of the same item to be added. Default = 1</param>
        public virtual void AddItemToInventory(Item item, int quantity = 1)
        {
            this.Inventory.Add(item, quantity);
        }

        /// <summary>
        /// Removes the item to the inventory by quantity amount.  
        /// </summary>
        /// <param name="item">The item to be removed to the inventory.</param>
        /// <param name="quantity">The number of the same item to be removed. Default = 1</param>
        /// <returns>A boolean determining if the</returns>
        public virtual bool RemoveItemFromInventory(Item item, int quantity = 1)
        {
            return this.Inventory.Remove(item, quantity);
        }

        /// <summary>
        /// Retreives the character stat given the stat name.
        /// </summary>
        /// <param name="statName">The stat name.</param>
        /// <returns>The stat object.</returns>
        public Stat GetStat(string statName)
        {
            return this.Stats.GetStat(statName);
        }

        /// <summary>
        /// Attempts to change the characters stat to a new value. 
        /// If no stat exists with name statName a new stat is
        /// created and defaulted to that value
        /// </summary>
        /// <param name="statName">The stat to change</param>
        /// <param name="value">The new value to change it to</param>
        public void SetStat(string statName, int value)
        {
            this.Stats.SetStat(statName, value);
        }

        /// <summary>
        /// Displays the inventory
        /// </summary>
        public virtual void DisplayInventory()
        {
            Console.Write("Inventory for ");
            ConsoleExt.WriteColor(this.Name, ConsoleExt.PlayerNameColor);
            Console.Write(":\n");
            Console.WriteLine(("").PadRight(24, '*'));
            this.Inventory.Display();
            Console.WriteLine(("").PadRight(24, '*'));
        }

        /// <summary>
        /// Displays the players stats
        /// </summary>
        public virtual void DisplayStats()
        {
            Console.Write("Stats for ");
            ConsoleExt.WriteColor(this.Name, ConsoleExt.PlayerNameColor);
            Console.Write(":\n");
            Console.WriteLine($"Stat:\tBase : Total");
            Console.WriteLine(("").PadRight(24, '*'));
            this.Stats.Display();
            Console.WriteLine(("").PadRight(24, '*'));
        }
    }
}