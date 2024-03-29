﻿using System;
using System.Collections.Generic;
using CodeBase.Infrastructure.StaticData;

namespace CodeBase.Data
{
    [Serializable]
    public class PlayerProgress
    {
        public State HeroState;
        public WorldData WorldData;
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