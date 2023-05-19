using System;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Service;
using CodeBase.Infrastructure.StaticData;
using CodeBase.UI.Forms;
using UnityEngine;

namespace CodeBase.Tower
{
    public class TowerSpawner : MonoBehaviour
    {
        private IGameFactory _factory;
        private ShopWindow _shopWindow;

        private string _id;
        private bool _createTower;

        public void Construct(ShopWindow shopWindow)
        {
            _shopWindow = shopWindow;
        }
        
        private void Awake()
        {
            _id = GetComponent<UniqueId>().Id;
            _factory = AllServices.Container.Single<IGameFactory>();
        }

        private void OnEnable()
        {
            _shopWindow.Happened += BuyTower;
        }

        private void OnDestroy()
        {
            _shopWindow.Happened -= BuyTower;
        }

        private void BuyTower(TowerStaticData data)
        {
            Spawner(data.TowerTypeID, transform);
            _createTower = true;
        }

        private void Spawner(TowerTypeID towerTypeID, Transform parent)
        {
            GameObject tower = _factory.CreatTower(towerTypeID, parent);
        }
    }
}