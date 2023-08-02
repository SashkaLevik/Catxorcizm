using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Sashka.Scripts.Enemyes
{
    public class EnemySpawner : MonoBehaviour
    {
        private const string Enemies = "Enemies";

        [SerializeField] private Transform[] _spawnPoints;
        [SerializeField] private Transform _bossSpawnPoint;
        [SerializeField] private BaseEnemy _spawnedEnemy;
        [SerializeField] private float _timeBetweenSpawn;
        [SerializeField] private int _weakCount;
        [SerializeField] private int _mediumCount;
        [SerializeField] private int _strongCount;
        [SerializeField] private int _bossCount;
        [SerializeField] private SpawnerController _controller;

        public List<ScriptablePrefab> _enemies;

        public int Weak => _weakCount;
        public int Medium => _mediumCount;
        public int Strong => _strongCount;
        public int Boss => _bossCount;

        private void Awake()
        {
            _enemies = Resources.LoadAll<ScriptablePrefab>(Enemies).ToList();
        }

        private void Start()
        {
            Invoke(nameof(Spawn), 2f);
        }

        private void Spawn()
        {
            StartCoroutine(SpawnEnemies(_weakCount, _mediumCount, _strongCount, _bossCount));
        }

        private IEnumerator SpawnEnemies(int weakCount, int mediumCount, int strongCount, int bossCount)
        {
            var delay = new WaitForSeconds(_timeBetweenSpawn);

            for (int i = 0; i < weakCount; i++)
            {
                var randomEnemy = GetRandomEnemy<BaseEnemy>(EnemyTypeID.Weak);
                _spawnedEnemy = Instantiate(randomEnemy, GetRandomPoint());
                _spawnedEnemy.GetComponentInChildren<EnemyHealth>().Died += _controller.OnEnemyDied;                
                yield return delay;
            }
            for (int i = 0; i < mediumCount; i++)
            {
                var randomEnemy = GetRandomEnemy<BaseEnemy>(EnemyTypeID.Medium);
                _spawnedEnemy = Instantiate(randomEnemy, GetRandomPoint());
                _spawnedEnemy.GetComponentInChildren<EnemyHealth>().Died += _controller.OnEnemyDied;
                yield return delay;
            }
            for (int i = 0; i < strongCount; i++)
            {
                var randomEnemy = GetRandomEnemy<BaseEnemy>(EnemyTypeID.Strong);
                _spawnedEnemy = Instantiate(randomEnemy, GetRandomPoint());
                _spawnedEnemy.GetComponentInChildren<EnemyHealth>().Died += _controller.OnEnemyDied;
                yield return delay;
            }
            for (int i = 0; i < bossCount; i++)
            {
                var randomEnemy = GetRandomEnemy<BaseEnemy>(EnemyTypeID.Boss);
                _spawnedEnemy = Instantiate(randomEnemy, _bossSpawnPoint);
                _spawnedEnemy.GetComponentInChildren<EnemyHealth>().Died += _controller.OnEnemyDied;
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

