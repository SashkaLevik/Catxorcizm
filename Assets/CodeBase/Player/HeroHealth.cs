using System;
using CodeBase.Data;
using CodeBase.Tower;
using UnityEngine;
using UnityEngine.Events;

namespace CodeBase.Player
{
    public class HeroHealth : MonoBehaviour, IHealth
    {
        // [SerializeField] private float _currentHP;
        // [SerializeField] private float _maxHP;

        private State _state;
        public event UnityAction HealthChanged;

        public float Current
        {
            get => _state.CurrentHP;
            set
            {
                _state.CurrentHP = value;
                HealthChanged?.Invoke();
            }
        }

        public float Max { get => _state.MaxHP; set => _state.MaxHP = value; }

        public void TakeDamage(int damage)
        {
            if (Current <= 0)
                return;

            Current -= damage;
        }
    }
}