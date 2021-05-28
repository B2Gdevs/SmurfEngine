using System;
using System.Collections.Generic;
using System.Text;

namespace SmurfEngine.Attributes
{
    public class Stat : BaseStat
    {
        /// <summary>
        /// Bonuses from armor, weapons, or other permanent bonuses.
        /// </summary>
        private List<RawBonus> rawBonusList;
        /// <summary>
        /// Bonuses from skills, or other temporary bonuses that are applied after the raw bonus.
        /// </summary>
        private List<FinalBonus> finalBonusList;

        public Stat(string name, int value, float multiplier) : base(name, value, multiplier)
        {
            this.rawBonusList = new List<RawBonus>();
            this.finalBonusList = new List<FinalBonus>();
        }

        public float Value => CalculateFinalValue();

        public void AddRawBonus(RawBonus rawBonus)
        {
            rawBonusList.Add(rawBonus);
        }

        public void AddFinalBonus(FinalBonus finalBonus)
        {
            finalBonusList.Add(finalBonus);
        }

        public bool RemoveRawBonus(RawBonus rawBonus)
        {
            return rawBonusList.Remove(rawBonus);
        }

        public bool RemoveFinalBonus(FinalBonus finalBonus)
        {
            return finalBonusList.Remove(finalBonus);
        }

        private float CalculateFinalValue() 
        {
            float finalValue = BaseValue;

            ApplyBonusList(ref finalValue, rawBonusList);
            ApplyBonusList(ref finalValue, finalBonusList);

            return finalValue;
        }

        private void ApplyBonusList<T>(ref float result, List<T> bonusList) where T:BaseStat
        {
            var finalBonusValue = 0f;
            var finalBonusMultiplier = 0f;

            foreach (var bonus in bonusList)
            {
                finalBonusValue += bonus.BaseValue;
                finalBonusMultiplier += bonus.BaseMultiplier;
            }

            result += finalBonusValue;
            result *= (1 + finalBonusMultiplier);
        }
    }
}
