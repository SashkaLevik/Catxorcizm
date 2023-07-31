using Assets.Sashka.Infastructure.Tresures;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sashka.Scripts.Enemyes
{
    public class SpawnerController : MonoBehaviour
    {
        [SerializeField] private EnemySpawner _firstWave;
        [SerializeField] private EnemySpawner _secondWave;
        [SerializeField] private EnemySpawner _thirdWave;
        [SerializeField] private EnemySpawner _fourthWave;
        [SerializeField] private EnemySpawner _fifthWave;
        [SerializeField] private EnemySpawner[] _spawners;

        public int _enemiesCount;
        private float _enemiesPercent = 100;
        private float _killedEnemiesPercent;
        private int _spawned;
        private int _killedEnemies;
        private int _currentSpawnerIndex;
        private int _wavesCount;        
        private EnemySpawner _currentSpawner;
        private bool _canChange = false;

        public event UnityAction WaveCompleted;
        public event UnityAction LevelCompleted;
        public event UnityAction WaveStarted;

        public float KilledEnemies => _killedEnemiesPercent;

        private void Awake()
        {
            _firstWave.gameObject.SetActive(false);
            _secondWave.gameObject.SetActive(false);
            _thirdWave.gameObject.SetActive(false);
            _fourthWave.gameObject.SetActive(false);
            _fifthWave.gameObject.SetActive(false);
            SetSpawner(_currentSpawnerIndex);
            _wavesCount = _spawners.Length;
            GetEnemiesCount();
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

        public void NextWave()
        {
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

        public void OnEnemyDied(BaseEnemy enemy)
        {
            _spawned--;
            _killedEnemies++;

            if (_spawned == 0)
            {
                WaveCompleted?.Invoke();
                _wavesCount--;
                Debug.Log("WaveComplete");
                CheckLastWave();
            }

            enemy.GetComponentInChildren<EnemyHealth>().Died -= OnEnemyDied;
        }

        private void CheckLastWave()
        {
            if (_wavesCount == 0 && _spawned == 0)
            {
                LevelCompleted?.Invoke();
                Debug.Log("LevelComplete");
            }                
        }

        public void CalculatePercentage()
        {
            _killedEnemiesPercent = (_enemiesPercent / _enemiesCount) * _killedEnemies;
        }
    }
}