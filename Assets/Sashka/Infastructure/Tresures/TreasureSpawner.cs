using Assets.Sashka.Scripts.Enemyes;
using CodeBase.Infrastructure.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Sashka.Infastructure.Tresures
{
    public class TreasureSpawner : MonoBehaviour
    {
        private const string Loot = "Loot";

        [SerializeField] private Transform[] _spawnPoints;
        [SerializeField] private GameObject _appearEffect;
        [SerializeField] private SpawnerController _spawnerController;

        public List<Treasure> _treasures;
        public List<Treasure> _spawnedTreasures;

        private void Awake()
        {
            _treasures = Resources.LoadAll<Treasure>(Loot).ToList();
        }        

        private void OnEnable()
        {
            _spawnerController.WaveCompleted += SpawnTreasure;
        }

        public void SpawnTreasure()
            => StartCoroutine(SpawnLoot());

        public void RemoveTreasures()
        {
            _spawnedTreasures.Clear();

            for (int i = 0; i < _spawnPoints.Length; i++)
            {
                var treasure = _spawnPoints[i].GetComponentInChildren<Treasure>();

                if (treasure != null)
                {
                    Destroy(treasure.gameObject);
                }
            }
        }

        private IEnumerator SpawnLoot()
        {
            for (int i = 0; i < _spawnPoints.Length; i++)
            {
                var randomTreasure = GetRandomTresure<Treasure>();
                var effect = Instantiate(_appearEffect, _spawnPoints[i]);
                yield return new WaitForSeconds(0.4f);
                Destroy(effect);
                Instantiate(randomTreasure, _spawnPoints[i]);
                _spawnedTreasures.Add(randomTreasure);
            }
        }       

        private T GetRandomTresure<T>() where T : Treasure 
            => (T)_treasures.OrderBy(o => Random.value).First();                       
    }
}
