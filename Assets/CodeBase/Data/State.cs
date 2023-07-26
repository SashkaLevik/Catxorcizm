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
        public int Price;
        public int Level;
        public void ResetHP() => CurrentHP = MaxHP;

        public State()
        {
            CurrentHP = 10;
            MaxHP = 10;
            MeleeAttack = 3;
            SpellAmount = 2;
            Price = 50;
            Level = 1;
        }
    }
}