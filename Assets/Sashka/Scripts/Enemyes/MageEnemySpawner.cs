using System.Linq;
using UnityEngine;

namespace Assets.Sashka.Scripts.Enemyes
{
    public class MageEnemySpawner : EnemySpawner
    {
        protected override void Awake()
        {
            _enemies = Resources.LoadAll<ScriptablePrefab>(MageEnemies).ToList();
        }
    }
}
