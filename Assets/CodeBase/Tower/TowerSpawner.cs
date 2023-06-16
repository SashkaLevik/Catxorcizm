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
        [SerializeField] private SpriteRenderer _sprite;
        
        private IGameFactory _factory;
        private IUIFactory _uIFactory;
        private ShopWindow _shopWindow;
        private bool _createTower;
        private GameObject _currentTower;

        private string _id;
        public bool CreateTower => _createTower;
        public event UnityAction<bool> ShiftTower;

        public void Construct(IUIFactory uiFactory)
        {
            _uIFactory = uiFactory;
            _uIFactory.Shop.Opened += ShopOnOpened;
        }

        public void IsCreateTower()
        {
            _createTower = !_createTower;
            _sprite.enabled = !_sprite.enabled;
            ShiftTower?.Invoke(_createTower);
        }

        private void Awake()
        {
            _id = GetComponent<UniqueId>().Id;
            _factory = AllServices.Container.Single<IGameFactory>();
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
            _sprite.enabled = false;
            ShiftTower?.Invoke(_createTower);
        }

        private void Spawner(TowerTypeID towerTypeID, Transform parent)
        {
            DestroyMinions();
            
            GameObject tower = _factory.CreatTower(towerTypeID, parent);
            tower.GetComponent<PositionShift>().Construct(_uIFactory.Upgrade, towerTypeID);
            _currentTower = tower;
        }

        public void DestroyMinions()
        {
            if (_currentTower != null)
                Destroy(_currentTower);
        }
    }
}