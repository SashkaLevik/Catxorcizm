using CodeBase.Data;
using CodeBase.Infrastructure.Service.SaveLoad;
using CodeBase.Tower;
using UnityEngine;
using UnityEngine.Events;

namespace CodeBase.Player
{
    public class HeroHealth : MonoBehaviour, IHealth, ISavedProgress
    {
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

        public void LoadProgress(PlayerProgress progress)
        {
            _state = progress.HeroState;
            Debug.Log("загрузить данные Жизней");
        }

        public void UpdateProgress(PlayerProgress progress)
        {
        }
    }
}