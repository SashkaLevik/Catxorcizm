using CodeBase.Data;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Service;
using CodeBase.Infrastructure.Service.PersistentProgress;
using CodeBase.Infrastructure.Service.SaveLoad;
using CodeBase.Tower;
using UnityEngine;
using UnityEngine.Events;

namespace CodeBase.Player
{
    public class HeroHealth : MonoBehaviour, IHealth, ISavedProgressReader
    {
        private State _state;
        private Animator _animator;
        private int _level;

        public event UnityAction HealthChanged;
        public event UnityAction Died;

        public int Level => _level;

        private void Awake()
        {
            IPersistentProgressService progress = AllServices.Container.Single<IPersistentProgressService>();
        }

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _level = _state.Level;
        }

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
            Current -= damage;

            if (Current <= 0)
                Die();
        }

        public void LoadProgress(PlayerProgress progress)
        {
           Debug.Log("загрузить данные Жизней");
            _state = progress.HeroState;
            _state.ResetHP();
        }

        public void RemoveCat()
            => Destroy(gameObject);

        private void Die()
        {
            _animator.SetTrigger("Die");
            Died?.Invoke();            
        }
    }
}