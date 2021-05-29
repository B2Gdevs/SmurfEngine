using SmurfEngine.Attributes;
using SmurfEngine.Items;
using SmurfEngine.UI;
using SmurfEngine.Utilities;
using SmurfEngine.Utilities.Enums;
using System;
using System.Collections.Generic;

namespace SmurfEngine.Characters
{
    public class Character
    {
        #region Public Properties
        public string Name { get; set; }
        public virtual int Health { get; set; }
        public Inventory Inventory { get; set; }
        #endregion

        #region Stats
        private Dictionary<string, Stat> stats = new Dictionary<string, Stat>();

        public virtual Stat Strength     => this.GetStat(StatType.STR.ToString());
        public virtual Stat Intelligence => this.GetStat(StatType.INT.ToString());
        public virtual Stat Wisdom       => this.GetStat(StatType.WIS.ToString());
        public virtual Stat Dexterity    => this.GetStat(StatType.DEX.ToString());
        public virtual Stat Constitution => this.GetStat(StatType.CON.ToString());
        public virtual Stat Charisma     => this.GetStat(StatType.CHA.ToString());
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a Character with stats defaulted to zero
        /// </summary>
        /// <param name="name">The name of the character.</param>
        /// <param name="health">The character's base health</param>
        /// <param name="inventory">The inventory for the chacter to have.</param>
        public Character(string name, int health, Inventory inventory)
        {
            this.Name = name;
            this.Health = health;
            this.Inventory = inventory;

            // Initialize stats
            foreach (var statName in Enum.GetNames(typeof(StatType)))
                this.stats.Add(statName, new Stat(statName, 0, 0));

        }

        /// <summary>
        /// Create a character and sets all base stats. 
        /// For testing purposes, not sure if this is the right approach.
        /// </summary>
        /// <param name="name">The name of the character.</param>
        /// <param name="health">The character's base health</param>
        /// <param name="inventory">The inventory for the chacter to have.</param>
        /// <param name="stats">Players stats in order STR, INT, WIS, DEX, CON, CHA</param>
        public Character(string name, int health, Inventory inventory, Tuple<int,int,int,int,int,int> stats)
        {
            this.Name = name;
            this.Health = health;
            this.Inventory = inventory;

            this.stats.Add(StatType.STR.ToString(), new Stat(StatType.STR.ToString(), stats.Item1, 0));
            this.stats.Add(StatType.INT.ToString(), new Stat(StatType.INT.ToString(), stats.Item2, 0));
            this.stats.Add(StatType.WIS.ToString(), new Stat(StatType.WIS.ToString(), stats.Item3, 0));
            this.stats.Add(StatType.DEX.ToString(), new Stat(StatType.DEX.ToString(), stats.Item4, 0));
            this.stats.Add(StatType.CON.ToString(), new Stat(StatType.CON.ToString(), stats.Item5, 0));
            this.stats.Add(StatType.CHA.ToString(), new Stat(StatType.CHA.ToString(), stats.Item6, 0));
        }
        #endregion

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
            _ = this.stats.TryGetValue(statName, out Stat stat);
            return stat;
        }

        #region Display Information
        public virtual void DisplayInventory()
        {
            Console.Write("Inventory for ");
            ConsoleExt.WriteColor(Name, ConsoleExt.PlayerNameColor);
            Console.Write(":\n");
            Console.WriteLine(("").PadRight(24, '*'));
            Inventory.Display();
            Console.WriteLine(("").PadRight(24, '*'));
        }

        public virtual void DisplayStats()
        {
            Console.Write("Stats for ");
            ConsoleExt.WriteColor(Name, ConsoleExt.PlayerNameColor);
            Console.Write(":\n");
            Console.WriteLine($"Stat:\tBase : Total");
            Console.WriteLine(("").PadRight(24, '*'));

            foreach(var stat in stats.Values)
            {
                ConsoleExt.WriteColor($" {stat.Name}: \t{stat.BaseValue} : ", ConsoleColor.DarkGreen);
                ConsoleExt.WriteColor($"{stat.Value}\n", ConsoleColor.Green);
            }

            Console.WriteLine(("").PadRight(24, '*'));
        }
        #endregion
    }
}