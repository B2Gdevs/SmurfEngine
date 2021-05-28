using SmurfEngine.Attributes;
using SmurfEngine.Items;
using SmurfEngine.UI;
using SmurfEngine.Utilities;
using System;
using System.Collections.Generic;

using Stats = SmurfEngine.Utilities.Consts.Stats;

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
        private Stat[] stats = new Stat[Consts.NUM_STATS];

        public virtual Stat Strength     => stats[Stats.STR];
        public virtual Stat Intelligence => stats[Stats.INT];
        public virtual Stat Wisdom       => stats[Stats.WIS];
        public virtual Stat Dexterity    => stats[Stats.DEX];
        public virtual Stat Constitution => stats[Stats.CON];
        public virtual Stat Charisma     => stats[Stats.CHA];
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a Character with stats defaulted to zero
        /// </summary>
        /// <param name="name"></param>
        /// <param name="health"></param>
        /// <param name="inventory"></param>
        public Character(string name, int health, Inventory inventory)
        {
            this.Name = name;
            this.Health = health;
            this.Inventory = inventory;

            this.stats[Stats.STR] = new Stat("STR", 0, 0);
            this.stats[Stats.INT] = new Stat("INT", 0, 0);
            this.stats[Stats.WIS] = new Stat("WIS", 0, 0);
            this.stats[Stats.DEX] = new Stat("DEX", 0, 0);
            this.stats[Stats.CON] = new Stat("CON", 0, 0);
            this.stats[Stats.CHA] = new Stat("CHA", 0, 0);
        }

        /// <summary>
        /// Create a character and sets all base stats. 
        /// For testing purposes, not sure if this is the right approach.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="health"></param>
        /// <param name="inventory"></param>
        /// <param name="stats">Players stats in order STR, INT, WIS, DEX, CON, CHA</param>
        public Character(string name, int health, Inventory inventory, Tuple<int,int,int,int,int,int> stats)
        {
            this.Name = name;
            this.Health = health;
            this.Inventory = inventory;

            this.stats[Stats.STR] = new Stat("STR", stats.Item1, 0);
            this.stats[Stats.INT] = new Stat("INT", stats.Item2, 0);
            this.stats[Stats.WIS] = new Stat("WIS", stats.Item3, 0);
            this.stats[Stats.DEX] = new Stat("DEX", stats.Item4, 0);
            this.stats[Stats.CON] = new Stat("CON", stats.Item5, 0);
            this.stats[Stats.CHA] = new Stat("CHA", stats.Item6, 0);
        }
        #endregion

        public virtual void AddItemToInventory(Item item, int quantity = 1)
        {
            Inventory.Add(item, quantity);
        }

        public virtual bool RemoveItemFromInventory(Item item, int quantity = 1)
        {
            return Inventory.Remove(item, quantity);
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

            foreach(var stat in stats)
            {
                ConsoleExt.WriteColor($" {stat.Name}: \t{stat.BaseValue} : ", ConsoleColor.DarkGreen);
                ConsoleExt.WriteColor($"{stat.Value}\n", ConsoleColor.Green);
            }

            Console.WriteLine(("").PadRight(24, '*'));
        }
        #endregion
    }

}