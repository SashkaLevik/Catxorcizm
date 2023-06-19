using System;
using Assets.Sashka.Scripts.Enemyes;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Sashka.Scripts.Minions
{
    public class AttackTrigger : MonoBehaviour
    {
        public event Action<BaseEnemy> AttackZoneEntered;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out BaseEnemy enemy))
            {
                AttackZoneEntered?.Invoke(enemy);
            }
        }
    }
}

