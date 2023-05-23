using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sashka
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "StaticData/Enemy")]
    public class EnemyStaticData : ScriptableObject
    {
        public float Health;
        public int Damage;
        public float AttackRange;
        public float AttackRate;
        public float Speed;
    }
}

