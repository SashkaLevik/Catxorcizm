﻿using CodeBase.Data;
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
        //public HeroAttack Attack;

        public event UnityAction HealthChanged;
        public event UnityAction Died;


        private void Awake()
        {
            IPersistentProgressService progress = AllServices.Container.Single<IPersistentProgressService>();
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
        }

        private void Die()
        {
            Died?.Invoke();
            //Attack.enabled = false;
            Destroy(gameObject);
            //Animator.PlayDeath();

            //Instantiate(DeathFx, transform.position, Quaternion.identity);
        }
    }
}