using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private BaseEnemy _enemy;
    [SerializeField] private List<BaseEnemy> _enemies;

    private int _enemyCount = 3;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        var delay = new WaitForSeconds(3);

        for (int i = 0; i < _enemyCount; i++)
        {
            BaseEnemy enemy = Instantiate(_enemy, _spawnPoint.position, _spawnPoint.rotation).GetComponent<BaseEnemy>();
            _enemies.Add(enemy);
            enemy.Died += OnEnemyDied;
            yield return delay;
        }       
    }

    private void OnEnemyDied(BaseEnemy enemy)
    {
        enemy.Died -= OnEnemyDied;
    }
}
