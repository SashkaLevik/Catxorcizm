using System;

namespace CodeBase.Data
{
    [Serializable]
    public class State
    {
        public float CurrentHP;
        public float MaxHP;
        public int MeleeAttack;
        public int SpellAmount;
        public int PriceLevel;
        public int PriceSpell;
        public int Level;
        public void ResetHP() => CurrentHP = MaxHP;

        public State()
        {
            Level = 1;
            CurrentHP = 4;
            MaxHP = 4;
            MeleeAttack = 3;
            SpellAmount = 2;
            PriceLevel = 50;
            PriceSpell = 50;
        }
    }
}