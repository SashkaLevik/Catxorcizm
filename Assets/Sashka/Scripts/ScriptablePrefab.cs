using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Sashka
{
    [CreateAssetMenu(fileName = "EnemyType", menuName = "EnemyType")]
    public class ScriptablePrefab : ScriptableObject
    {
        [SerializeField] private BaseEnemy _enemyPrefab;
        [SerializeField] private BaseEnemy[] _prefabs;
        [SerializeField] private EnemyTypeID _enemyType;

        public EnemyTypeID EnemyType => _enemyType;

        public BaseEnemy GetRandomPrefab()
        {
            int randomPrefab = Random.Range(0, _prefabs.Length);
            _enemyPrefab = _prefabs[randomPrefab];
            return _enemyPrefab;
        }
    }   
}

