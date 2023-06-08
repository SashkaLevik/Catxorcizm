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
        [SerializeField] private TreasureSpawner _treasureSpawner;

        private int _spawned;
        private int _currentSpawnerIndex;

        public EnemySpawner _currentSpawner;

        public event UnityAction WaveCompleted;

        private void Awake()
        {
            _secondWave.gameObject.SetActive(false);
            _thirdWave.gameObject.SetActive(false);
            SetSpawner(_currentSpawnerIndex);            
        }
        
        private void OnEnable()
        {
            WaveCompleted += Reduce;
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
            SetSpawner(++_currentSpawnerIndex);
            _spawners[_currentSpawnerIndex].gameObject.SetActive(true);
            //WaveCompleted -= _treasureSpawner.SpawnTreasure;
        }

        public void Reduce()
        {
            Debug.Log("Completed");
        }

        public void OnEnemyDied(BaseEnemy enemy)
        {
            _spawned--;

            if (_spawned == 0)
            {
                WaveCompleted?.Invoke();
            }

            enemy.GetComponentInChildren<EnemyHealth>().Died -= OnEnemyDied;
        }
    }
}