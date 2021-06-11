using System.Collections.Generic;

namespace SmurfEngine.Attributes
{
    public class Stat : BaseStat
    {
        /// <summary>
        /// Bonuses from armor, weapons, or other permanent bonuses.
        /// </summary>
        private List<Stat> RawBonusList { get; set; } = new List<Stat>();

        /// <summary>
        /// Bonuses from skills, or other temporary bonuses that are applied 
        /// after the raw bonus.
        /// </summary>
        private List<Stat> FinalBonusList { get; set; } = new List<Stat>();

        public float Value => this.CalculateFinalValue();

        public void AddRawBonus(Stat rawBonus)
        {
            this.RawBonusList.Add(rawBonus);
        }

        public void AddFinalBonus(Stat finalBonus)
        {
            this.FinalBonusList.Add(finalBonus);
        }

        public bool RemoveRawBonus(Stat rawBonus)
        {
            return this.RawBonusList.Remove(rawBonus);
        }

        public bool RemoveFinalBonus(Stat finalBonus)
        {
            return this.FinalBonusList.Remove(finalBonus);
        }

        private float CalculateFinalValue()
        {
            float finalValue = this.BaseValue;

            this.ApplyBonusList(ref finalValue, this.RawBonusList);
            this.ApplyBonusList(ref finalValue, this.FinalBonusList);

            return finalValue;
        }

        private void ApplyBonusList(ref float result, List<Stat> bonusList)
        {
            var finalBonusValue = 0f;
            var finalBonusMultiplier = 0f;

            foreach (Stat bonus in bonusList)
            {
                finalBonusValue += bonus.BaseValue;
                finalBonusMultiplier += bonus.BaseMultiplier;
            }

            result += finalBonusValue;
            result *= 1 + finalBonusMultiplier;
        }
    }
}
