using System;
using Assets.Sashka.Infastructure.Audio;
using Assets.Sashka.Scripts.Enemyes;
using CodeBase.Infrastructure.StaticData;
using CodeBase.Tower;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Sashka.Scripts.Minions
{
    [RequireComponent(typeof(BaseMinion))]
    public class MinionHealth : MonoBehaviour, IHealth
    {
        [SerializeField] private float _current;
        [SerializeField] private float _max;
        [SerializeField] private float _defence;
        [SerializeField] private TowerStaticData _staticData;
        [SerializeField] private BaseMinion _minion;
        [SerializeField] private MinionDieSound _audioController;
        [SerializeField] private Shield _shield;

        private SpawnerController _spawnerController;
        public float _currentDefence;

        public event UnityAction DefenceChanged;
        public event UnityAction HealthChanged;
        public event Action Died;

        private void Awake()
            => _spawnerController = FindObjectOfType<SpawnerController>();

        private void Start()
        {
            _minion = this.GetComponent<BaseMinion>();
            _defence = _minion.Defence;
            SetDefence();
        }        

        public float Current
        {
            get => _current;
            set
            {
                HealthChanged?.Invoke();
                _current = value;
            }
        }

        public float Max
        {
            get => _max;
            set
            {
                HealthChanged?.Invoke();
                _max = value;
            }
        }

        public float Defence
        {
            get => _defence;
            set
            {
                _defence = value;
                DefenceChanged?.Invoke();
            }
        }

        private void SetDefence()
        {
            _currentDefence = _defence;

            if (_currentDefence > 0)
            {
                _shield.gameObject.SetActive(true);
            }            
        }

        private void OnEnable()
        {
            _current = _staticData.CurrentHP;
            _max = _staticData.MaxHP;
            DefenceChanged += SetDefence;
            _spawnerController.WaveCompleted += SetDefence;
        }

        private void OnDestroy()
        {
            DefenceChanged -= SetDefence;
            _spawnerController.WaveCompleted -= SetDefence;
        }

        public void TakeDamage(int damage)
        {
            if (_currentDefence != 0)
            {
                _shield.ActivateProtect();
                _currentDefence -= 1;
            }
            else if(_currentDefence <= 0)
            {
                _shield.gameObject.SetActive(false);
                Current -= damage;
                HealthChanged?.Invoke();
            }
            
            if (Current <= 0)
            {
                Die();
            }
        }

        public void Heal(float heal)
        {
            Current += heal;
            HealthChanged?.Invoke();

            if (Current > Max) { Current = Max; }            
        }        

        private void Die()
        {
            AudioSource dieSound;
            dieSound = _audioController.GetRandomSound();
            dieSound.Play();
            StartCoroutine(DestroyTimer());
        }

        private IEnumerator DestroyTimer()
        {
            yield return new WaitForSeconds(0.8f);
            Destroy(gameObject);
            Died?.Invoke();
        }
    }
}