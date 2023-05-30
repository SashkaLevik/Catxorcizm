using Assets.Sashka.Scripts.Enemyes;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Sashka.Scripts.Minions
{
    public class AttackTrigger : MonoBehaviour
    {
        [SerializeField] private BaseEnemy _enemy;

        public event UnityAction AttackZoneEntered;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out _enemy))
            {
                AttackZoneEntered?.Invoke();
            }
        }
    }
}

