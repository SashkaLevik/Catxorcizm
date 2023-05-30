using System;
using CodeBase.Data;
using UnityEngine;
using UnityEngine.Events;

namespace CodeBase.Player
{
    public class HeroHealth : MonoBehaviour
    {
        [SerializeField] private float _currentHP;
        [SerializeField] private float _maxHP;

        private State _state;

        public UnityAction HealthChanged;

        public float Current
        {
            get => _currentHP;
            set
            {
                _currentHP = value;
                HealthChanged?.Invoke();
            }
        }

        public float Max => _maxHP;

        public void TakeDamage(int damage)
        {
            if (Current <= 0)
                return;

            Current -= damage;
        }
    }
}