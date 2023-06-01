using Assets.Sashka.Scripts.Enemyes;
using Assets.Sashka.Scripts.StaticData;
using CodeBase.Infrastructure.StaticData;
using CodeBase.Tower;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Sashka.Scripts.Minions
{
    public class MinionHealth : MonoBehaviour, IHealth
    {
        [SerializeField] private float _current;
        [SerializeField] private float _max;
        [SerializeField] private TowerStaticData _staticData;
        [SerializeField] private BaseMinion _minion;

        public event UnityAction HealthChanged;
        public event UnityAction<BaseMinion> Died;

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
            _current = _staticData.CurrentHP;
            _max = _staticData.MaxHP;
        }

        public void TakeDamage(int damage)
        {
            Current -= damage;
            HealthChanged?.Invoke();

            if (Current <= 0)
            {
                Died?.Invoke(_minion);
                Die();
            }
        }

        private void Die()
        {
            Destroy(_minion.gameObject);
        }
    }
}