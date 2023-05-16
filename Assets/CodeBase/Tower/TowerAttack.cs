using UnityEngine;

namespace CodeBase.Tower
{
        public class TowerAttack : MonoBehaviour
        {
                public float Damage;
                public float AttackRange;
                public float Cooldown;

                private Transform _heroTransform;

                public void Construct(Transform heroTransform)
                {
                        _heroTransform = heroTransform;
                }
        }
}