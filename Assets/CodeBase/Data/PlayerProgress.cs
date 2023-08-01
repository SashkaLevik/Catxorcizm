using System;
using System.Collections.Generic;
using CodeBase.Infrastructure.StaticData;
using UnityEngine;

namespace CodeBase.Data
{
    [Serializable]
    public class PlayerProgress
    {
        public State HeroState;
        public WorldData WorldData;
        public int NumberOfMinions = 2;
        public int CurrentSoul;
        public int NumberOfMinions = 1;
        public List<TowerStaticData> StaticData = new();

        public PlayerProgress(string initialLevel)
        {
            HeroState = new State();
            WorldData = new WorldData(initialLevel);
        }
    }
}