using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Sashka.Scripts.StaticData
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "StaticData/Enemy")]
    public class EnemyStaticData : ScriptableObject
    {
        public float Health;
        public int Damage;
        public float Cooldown;
        public float Speed;
        public int Reward;
    }
}

