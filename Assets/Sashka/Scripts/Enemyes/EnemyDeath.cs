using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Sashka.Scripts.Enemyes
{
    [RequireComponent(typeof(EnemyHealth))]
    public class EnemyDeath : MonoBehaviour
    {
        [SerializeField] private EnemyHealth _health;

        public event UnityAction Died;

        private void Start() => _health.HealthChanged += OnHealthChanged;

        private void OnDestroy() => _health.HealthChanged -= OnHealthChanged;

        private void OnHealthChanged()
        {
            if (_health.Current <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            _health.HealthChanged -= OnHealthChanged;
            Died?.Invoke();
            Destroy(gameObject);
        }
    }
}

