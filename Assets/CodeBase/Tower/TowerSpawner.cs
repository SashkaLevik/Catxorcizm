using System;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Service;
using CodeBase.Infrastructure.StaticData;
using CodeBase.UI.Forms;
using CodeBase.UI.Service.Factory;
using UnityEngine;
using UnityEngine.Events;

namespace CodeBase.Tower
{
    public class TowerSpawner : MonoBehaviour
    {
        private IGameFactory _factory;
        private IUIFactory _uIFactory;
        private ShopWindow _shopWindow;
        private bool _createTower;

        private string _id;
        public bool CreateTower => _createTower;
        public event UnityAction<bool> ObjectExists;

        public void Construct(IUIFactory uiFactory)
        {
            _uIFactory = uiFactory;
            _uIFactory.Shop.Opened += ShopOnOpened;
        }

        private void Awake()
        {
            _id = GetComponent<UniqueId>().Id;
            _factory = AllServices.Container.Single<IGameFactory>();
            ObjectExists?.Invoke(_createTower);
        }

        private void Update()
        {
            _createTower = gameObject.GetComponentInChildren<TowerAttack>();
        }

        private void ShopOnOpened(bool open)
        {
        }

        private void OnDisable()
        {
            _uIFactory.Shop.Opened -= ShopOnOpened;
        }

        public void BuyTowerSpawn(TowerStaticData data)
        {
            Spawner(data.TowerTypeID, transform);
            _createTower = true;
            ObjectExists?.Invoke(_createTower);
        }

        private void Spawner(TowerTypeID towerTypeID, Transform parent)
        {
            GameObject tower = _factory.CreatTower(towerTypeID, parent);
        }
    }
}