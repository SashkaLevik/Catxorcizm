using Assets.Sashka.Infastructure.Tresures;
using Assets.Sashka.Infastructure.UI;
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
        [SerializeField] private EnemySpawner[] _spawners;
        //[SerializeField] private TreasureSpawner _treasureSpawner;

        public int _spawned;
        public int _currentSpawnerIndex;
        public int _wavesCount;        
        public EnemySpawner _currentSpawner;

        public event UnityAction WaveCompleted;
        public event UnityAction LevelCompleted;

        private void Awake()
        {
            _secondWave.gameObject.SetActive(false);
            _thirdWave.gameObject.SetActive(false);
            SetSpawner(_currentSpawnerIndex);
            _wavesCount = _spawners.Length;
        }

        private void OnEnable()
        {
        }

        private void OnDisable()
        {
        }

        private void SetSpawner(int index)
        {
            _currentSpawner = _spawners[index];
            _spawned = _currentSpawner.Weak + _currentSpawner.Medium;
        }

        public void NextWave()
        {
            if (_currentSpawnerIndex != _spawners.Length)
            {
                SetSpawner(++_currentSpawnerIndex);
                _spawners[_currentSpawnerIndex].gameObject.SetActive(true);
                //WaveCompleted -= _treasureSpawner.SpawnTreasure;
            }
        }

        public void OnEnemyDied(BaseEnemy enemy)
        {
            _spawned--;

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
    }
}