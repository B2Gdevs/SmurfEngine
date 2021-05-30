using System.Collections.Generic;

namespace SmurfEngine.Attributes
{
    public class Stat : BaseStat
    {
        /// <summary>
        /// Bonuses from armor, weapons, or other permanent bonuses.
        /// </summary>
        private readonly List<RawBonus> rawBonusList;
        /// <summary>
        /// Bonuses from skills, or other temporary bonuses that are applied after the raw bonus.
        /// </summary>
        private readonly List<FinalBonus> finalBonusList;

        public Stat(string name, int value, float multiplier) : base(name, value, multiplier)
        {
            this.rawBonusList = new List<RawBonus>();
            this.finalBonusList = new List<FinalBonus>();
        }

        public float Value => this.CalculateFinalValue();

        public void AddRawBonus(RawBonus rawBonus)
        {
            this.rawBonusList.Add(rawBonus);
        }

        public void AddFinalBonus(FinalBonus finalBonus)
        {
            this.finalBonusList.Add(finalBonus);
        }

        public bool RemoveRawBonus(RawBonus rawBonus)
        {
            return this.rawBonusList.Remove(rawBonus);
        }

        public bool RemoveFinalBonus(FinalBonus finalBonus)
        {
            return this.finalBonusList.Remove(finalBonus);
        }

        private float CalculateFinalValue()
        {
            float finalValue = this.BaseValue;

            this.ApplyBonusList(ref finalValue, this.rawBonusList);
            this.ApplyBonusList(ref finalValue, this.finalBonusList);

            return finalValue;
        }

        private void ApplyBonusList<T>(ref float result, List<T> bonusList) where T : BaseStat
        {
            var finalBonusValue = 0f;
            var finalBonusMultiplier = 0f;

            foreach (T bonus in bonusList)
            {
                finalBonusValue += bonus.BaseValue;
                finalBonusMultiplier += bonus.BaseMultiplier;
            }

            result += finalBonusValue;
            result *= (1 + finalBonusMultiplier);
        }
    }
}
