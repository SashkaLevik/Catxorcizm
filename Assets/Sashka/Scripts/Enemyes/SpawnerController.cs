using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Sashka.Scripts.Enemyes
{
    public class SpawnerController : MonoBehaviour
    {
        [SerializeField] private EnemySpawner _firstWave;
        [SerializeField] private EnemySpawner _secondWave;
        [SerializeField] private EnemySpawner[] _spawners;

        private EnemySpawner _currentSpawner;
        private int _currentSpawnerIndex;

        private void Awake()
        {
            _secondWave.gameObject.SetActive(false);
            SetSpawner(_currentSpawnerIndex);
        }

        private void Update()
        {
            NextWave();
        }

        private void SetSpawner(int index)
        {
            _currentSpawner = _spawners[index];
        }

        private void NextWave()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SetSpawner(++_currentSpawnerIndex);
                _spawners[_currentSpawnerIndex].gameObject.SetActive(true);
            }
        }

    }
}