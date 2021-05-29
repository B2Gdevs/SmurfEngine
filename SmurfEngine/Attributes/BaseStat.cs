using System;
using System.Collections.Generic;
using System.Text;

namespace SmurfEngine.Attributes
{
    public class BaseStat
    {
        public string Name { get; private set; }
        public int BaseValue { get; set; }
        public float BaseMultiplier { get; set; }

        public BaseStat(string name, int value, float multiplier)
        {
            this.Name = name;
            this.BaseValue = value;
            this.BaseMultiplier = multiplier;
        }
    }
}
