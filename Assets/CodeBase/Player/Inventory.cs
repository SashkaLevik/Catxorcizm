using System.Collections.Generic;
using CodeBase.Infrastructure.StaticData;
using CodeBase.Tower;
using UnityEngine;

namespace CodeBase.Player
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private List<TowerStaticData> _minions;
        private TowerStaticData _towerStaticData;
        private TowerSpawner _position;

        public void BuyMinions(TowerStaticData data)
        {
            _minions.Add(data);
            _towerStaticData = data;
        }

        public void SellMinions(int indexMinions)
        {
            _minions.RemoveAt(indexMinions);
        }

        public void SpawnMinions()
        {
            _position.BuyTowerSpawn(_towerStaticData);
        }

        public void SetSpawnPosition(TowerSpawner position)
        {
            _position = position;
        }
    }
}