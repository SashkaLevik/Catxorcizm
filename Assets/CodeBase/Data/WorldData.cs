using System;
using UnityEngine;

namespace CodeBase.Data
{
    [Serializable]
    public class WorldData
    {
        public string Level;

        public WorldData(string level)
        {
            Level = level;
        }
    }
}