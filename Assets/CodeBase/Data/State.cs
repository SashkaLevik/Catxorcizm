using System;

namespace CodeBase.Data
{
    [Serializable]
    public class State
    {
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
            Level = 1;
            CurrentHP = 4;
            MaxHP = 4;
            MeleeAttack = 3;
            SpellAmount = 2;
            PriceLevel = 250;
            PriceSpell = 220;
            PriceNewMinions = 150;
        }
    }
}