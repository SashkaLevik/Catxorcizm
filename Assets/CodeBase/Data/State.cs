using System;

namespace CodeBase.Data
{
    [Serializable]
    public class State
    {
        public int Lives;
        public int Level;
        public float CurrentHP;
        public float MaxHP;
        public int MeleeAttack;
        public int SpellAmount;

        public int PriceLevel;
        public int PriceSpell;
        public int PriceNewMinions;
        public void ResetHP() => CurrentHP = MaxHP;

        public State()
        {
            Lives = 9;
            Level = 1;
            CurrentHP = 6;
            MaxHP = 6;
            MeleeAttack = 2;
            SpellAmount = 2;

            PriceLevel = 250;
            PriceSpell = 200;
            PriceNewMinions = 150;
        }
    }
}