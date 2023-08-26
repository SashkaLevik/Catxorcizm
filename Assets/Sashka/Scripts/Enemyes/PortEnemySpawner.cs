using System.Linq;
using UnityEngine;

namespace Assets.Sashka.Scripts.Enemyes
{
    public class PortEnemySpawner : EnemySpawner
    {
        protected override void Awake()
        {
            _enemies = Resources.LoadAll<ScriptablePrefab>(PortEnemies).ToList();
        }
    }
}
