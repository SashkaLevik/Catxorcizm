using Assets.Sashka.Scripts.StaticData;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Sashka.Scripts.Enemyes
{
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] private float _current;
        [SerializeField] private float _max;
        [SerializeField] private EnemyStaticData _staticData;
        [SerializeField] private BaseEnemy _enemy;

        public event UnityAction HealthChanged;
        public event UnityAction<BaseEnemy> Died;        

        public float Current
        {
            get => _current;
            set
            {
                HealthChanged?.Invoke();
                _current = value;
            }
        }

        public float Max { get => _max; set => _max = value; }

        private void OnEnable()
        {
            _current = _staticData.Health;
            _max = _staticData.Health;
        }

        public void TakeDamage(int damage)
        {
            Current -= damage;
            HealthChanged?.Invoke();

            if (Current <= 0)
            {
                Died?.Invoke(_enemy);
                //Invoke(nameof(Die), 0.6f);
            }
        }        

        private void Die()
        {
            Destroy(_enemy.gameObject);
        }
    }
}

