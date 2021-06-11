using SmurfEngine.UI;
using System;
using System.Collections.Generic;

namespace SmurfEngine.Attributes
{
    public class CharacterStats
    {
        public Dictionary<string, Stat> Stats { get; set; } = new Dictionary<string, Stat>();

        /// <summary>
        /// Retreives the character stat given the stat name.
        /// </summary>
        /// <param name="statName">The stat name.</param>
        /// <returns>The stat object.</returns>
        public Stat GetStat(string statName)
        {
            _ = this.Stats.TryGetValue(statName, out Stat stat);
            return stat;
        }

        /// <summary>
        /// Changes the baseValue of a stat to value. If no stat 
        /// exists with statName a new one is created and defaulted to value 
        /// </summary>
        /// <param name="statName">The stat to change</param>
        /// <param name="value">the new baseValue for stat</param>
        public void SetStat(string statName, int value)
        {
            if (this.Stats.TryGetValue(statName, out Stat stat))
                stat.BaseValue = value;
            else
                this.Stats.Add(statName, new Stat { Name = statName, BaseValue = value, BaseMultiplier = 0 });
        }

        /// <summary>
        /// Writes all stats to the console
        /// </summary>
        public void Display()
        {
            foreach (Stat stat in this.Stats.Values)
            {
                ConsoleExt.WriteColor($" {stat.Name}: \t{stat.BaseValue} : ", ConsoleColor.DarkGreen);
                ConsoleExt.WriteColor($"{stat.Value}\n", ConsoleColor.Green);
            }
        }
    }
}
