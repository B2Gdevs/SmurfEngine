using SmurfEngine.Utilities.Enums;
using System.Collections.Generic;

namespace SmurfEngine.Attributes
{
    public static class Stats
    {
        public static Dictionary<string, Stat> GetDefaultStats()
        {
            return new Dictionary<string, Stat>
                {
                    { StatType.STR.ToString(),
                        new Stat { Name = StatType.STR.ToString(), BaseMultiplier = 0f, BaseValue = 0 } },
                    { StatType.INT.ToString(),
                        new Stat { Name = StatType.INT.ToString(), BaseMultiplier = 0f, BaseValue = 0 } },
                    { StatType.WIS.ToString(),
                        new Stat { Name = StatType.WIS.ToString(), BaseMultiplier = 0f, BaseValue = 0 } },
                    { StatType.DEX.ToString(),
                        new Stat { Name = StatType.DEX.ToString(), BaseMultiplier = 0f, BaseValue = 0 } },
                    { StatType.CON.ToString(),
                        new Stat { Name = StatType.CON.ToString(), BaseMultiplier = 0f, BaseValue = 0 } },
                    { StatType.CHA.ToString(),
                        new Stat { Name = StatType.CHA.ToString(), BaseMultiplier = 0f, BaseValue = 0 } },
                };
        }
    }
}
