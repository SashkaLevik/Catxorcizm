using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sashka.Scripts.Enemyes
{
    public class SpawnerController : MonoBehaviour
    {
        [SerializeField] private EnemySpawner[] _spawners;
        [SerializeField] private GameObject _treasureBackground;

        private int _enemiesCount;
        private float _enemiesPercent = 100;
        private float _killedEnemiesPercent;
        private int _spawned;
        private int _killedEnemies;
        private int _currentSpawnerIndex;
        private int _wavesCount;
        private EnemySpawner _currentSpawner;
        private bool _canChange = false;
        private bool _isLevelComplete;

        public bool IsLevelComplete => _isLevelComplete;

        public event UnityAction WaveCompleted;
        public event UnityAction LevelCompleted;
        public event UnityAction WaveStarted;

        public EnemySpawner CurrentSpawner => _currentSpawner;
        public float KilledEnemies => _killedEnemiesPercent;

        private void Awake()
        {            
            SetSpawner(_currentSpawnerIndex);
            _wavesCount = _spawners.Length;
            GetEnemiesCount();
            _treasureBackground.SetActive(false);
        }

        private void OnEnable()
        {
            WaveCompleted += ShowBackground;
            WaveStarted += HideBackground;
        }

        private void OnDestroy()
        {
            WaveCompleted -= ShowBackground;
            WaveStarted -= HideBackground;
        }

        private void HideBackground()
            => _treasureBackground.SetActive(false);

        private void ShowBackground()
            => _treasureBackground.SetActive(true);

        private void CheckLastWave()
        {
            if (_wavesCount == 0 && _spawned == 0)
            {
                _isLevelComplete = true;
                LevelCompleted?.Invoke();
            }                
        }

        private void GetEnemiesCount()
        {
            foreach (var spawner in _spawners)
            {
                _enemiesCount += spawner.Weak + spawner.Medium + spawner.Strong + spawner.Boss;
            }
        }

        private void SetSpawner(int index)
        {
            _currentSpawner = _spawners[index];
            _spawned = _currentSpawner.Weak + _currentSpawner.Medium + _currentSpawner.Strong + _currentSpawner.Boss;
        }       

        public void OnEnemyDied(BaseEnemy enemy)
        {
            _spawned--;
            _killedEnemies++;

            if (_spawned == 0)
            {
                _wavesCount--;
                CheckLastWave();
                WaveCompleted?.Invoke();
            }

            enemy.GetComponentInChildren<EnemyHealth>().Died -= OnEnemyDied;
        }

        public void CalculatePercentage()
            => _killedEnemiesPercent = (_enemiesPercent / _enemiesCount) * _killedEnemies;

        public void NextWave(int difficult)
        {
            _currentSpawner.SetDifficult(difficult);

            WaveStarted?.Invoke();
            if (_currentSpawnerIndex != _spawners.Length)
            {
                _spawners[_currentSpawnerIndex].gameObject.SetActive(true);

                if (_canChange == true)
                {
                    SetSpawner(++_currentSpawnerIndex);
                    _spawners[_currentSpawnerIndex].gameObject.SetActive(true);
                }
                _canChange = true;
            }
        }        
    }
}