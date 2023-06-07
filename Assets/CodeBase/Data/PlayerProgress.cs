using System;
using UnityEngine;

namespace CodeBase.Data
{
    [Serializable]
    public class PlayerProgress
    {
        public State HeroState;

        public PlayerProgress()
        {
            HeroState = new State();
        }
    }
}