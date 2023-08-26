using System.Linq;
using UnityEngine;

namespace Assets.Sashka.Scripts.Enemyes
{
    public class MarketEnemySpawner : EnemySpawner
    {
        protected override void Awake()
        {
            _enemies = Resources.LoadAll<ScriptablePrefab>(MarketEnemies).ToList();
        }
    }
}
