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

        public EnemySpawner _currentSpawner;
        private int _currentSpawnerIndex;


        public EnemySpawner CurrentSpawner => _currentSpawner;

        private void Awake()
        {
            _secondWave.gameObject.SetActive(false);
            _thirdWave.gameObject.SetActive(false);
            SetSpawner(_currentSpawnerIndex);
        }        

        private void OnEnable()
        {
            _currentSpawner.WaveCompleted += _treasureSpawner.SpawnTreasure;
        }

        private void OnDisable()
        {
            _currentSpawner.WaveCompleted -= _treasureSpawner.SpawnTreasure;
        }

        private void SetSpawner(int index)
        {
            _currentSpawner = _spawners[index];
        }

        public void NextWave()
        {
            SetSpawner(++_currentSpawnerIndex);
            _spawners[_currentSpawnerIndex].gameObject.SetActive(true);            
        }       
    }
}