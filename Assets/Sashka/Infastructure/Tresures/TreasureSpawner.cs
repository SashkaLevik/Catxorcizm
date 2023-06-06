using Assets.Sashka.Scripts.Enemyes;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Sashka.Infastructure.Tresures
{
    class TreasureSpawner : MonoBehaviour
    {
        private const string Loot = "Loot";

        [SerializeField] private Transform[] _spawnPoints;

        public List<Treasure> _treasures;

        private void Awake()
        {
            _treasures = Resources.LoadAll<Treasure>(Loot).ToList();
        }

        public void SpawnTreasure()
        {
            for (int i = 0; i < _spawnPoints.Length; i++)
            {
                var randomTreasure = GetRandomTresure<Treasure>();
                Instantiate(randomTreasure, _spawnPoints[i]);
            }            
            Debug.Log("Treasure");
        }

        private T GetRandomTresure<T>() where T : Treasure 
            => (T)_treasures.OrderBy(o => Random.value).First();
    }
}
