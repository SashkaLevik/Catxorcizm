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

        public void SellMinions(TowerStaticData data)
        {
            _towerStaticData = data;
            _minions.Remove(_towerStaticData);
        }

        public void Sell()
        {
            _position.DestroyMinions();
            _position.IsCreateTower();
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