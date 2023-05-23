using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Sashka
{
    public class EnemySpawner : MonoBehaviour
    {
        private const string Enemies = "Enemies";

        [SerializeField] private Transform[] _spawnPoints;
        [SerializeField] private BaseEnemy _spawnedEnemy;
        [SerializeField] private float _timeBetweenSpawn;
        [SerializeField] private int _weakEnemyCount;
        [SerializeField] private int _mediumEnemyCount;

        public List<ScriptablePrefab> _enemies;

        private void Awake()
        {
            _enemies = Resources.LoadAll<ScriptablePrefab>(Enemies).ToList();
        }

        private void Start()
        {
            Spawn();
        }

        private void Spawn()
        {
            StartCoroutine(SpawnEnemies(_weakEnemyCount, _mediumEnemyCount));
        }            

        private void OnEnemyDied(BaseEnemy enemy)
        {
            enemy.Died -= OnEnemyDied;
        }

        private IEnumerator SpawnEnemies(int weakCount, int mediumCount)
        {
            var delay = new WaitForSeconds(_timeBetweenSpawn);

            for (int i = 0; i < weakCount; i++)
            {
                var randomEnemy = GetRandomEnemy<BaseEnemy>(EnemyTypeID.Weak);
                _spawnedEnemy = Instantiate(randomEnemy, GetRandomPoint());
                _spawnedEnemy.Died += OnEnemyDied;
                yield return delay;
            }
            for (int i = 0; i < mediumCount; i++)
            {
                var randomEnemy = GetRandomEnemy<BaseEnemy>(EnemyTypeID.Medium);
                _spawnedEnemy = Instantiate(randomEnemy, GetRandomPoint());
                _spawnedEnemy.Died += OnEnemyDied;
                yield return delay;
            }
        }

        private T GetRandomEnemy<T>(EnemyTypeID type) where T : BaseEnemy
        {
            return (T)_enemies.Where(e => e.EnemyType == type).OrderBy(o => Random.value).First().GetRandomPrefab();
        }

        private Transform GetRandomPoint()
        {
            int randomPoint = Random.Range(0, _spawnPoints.Length);
            return _spawnPoints[randomPoint];
        }
    }
}

