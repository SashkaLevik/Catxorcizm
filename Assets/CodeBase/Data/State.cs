using System;

namespace CodeBase.Data
{
    [Serializable]
    public class State
    {
        public float CurrentHP = 4;
        public float MaxHP = 4;
        public int MeleeAttack = 3;
        public int SpellAmount = 2;
        public int Price;
        public int Level = 1;
        public void ResetHP() => CurrentHP = MaxHP;
    }
}