using UnityEngine;

namespace CodeBase.Data
{
    [SerializeField]
    public class PlayerProgress
    {
        public Stats HeroStats;
        public State HeroState;

        public PlayerProgress()
        {
            HeroState = new State();
            HeroStats = new Stats();
        }
    }
}