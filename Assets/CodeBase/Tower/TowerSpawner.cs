using Assets.Sashka.Scripts.Minions;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Service;
using CodeBase.Infrastructure.StaticData;
using CodeBase.UI.Forms;
using CodeBase.UI.Service.Factory;
using System;
using UnityEngine;
using UnityEngine.Events;

namespace CodeBase.Tower
{
    public class TowerSpawner : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _sprite;
        [SerializeField] private MinionHealth _minionHealth;

        
        private IGameFactory _factory;
        private IUIFactory _uIFactory;
        private ShopWindow _shopWindow;
        private bool _createTower;
        private GameObject _currentTower;

        private string _id;
        private TowerStaticData _data;
        public event UnityAction<TowerSpawner> CreateMinion;
        public bool CreateTower => _createTower;
        public MinionHealth MinionHealth => _minionHealth;
        public TowerStaticData Data => _data;
        
        public void Construct(IUIFactory uiFactory)
        {
            _uIFactory = uiFactory;
            _uIFactory.Shop.Opened += ShopOnOpened;
        }

        public void IsCreateTower()
        {
            _createTower = !_createTower;
            _sprite.enabled = !_sprite.enabled;
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
            _data = data;
            _createTower = true;
            _sprite.enabled = false;
        }

        private void OnMinionDie(BaseMinion minion)
        {
            _createTower = false;
            _sprite.enabled = true;
            _data = null;
            _minionHealth.Died -= OnMinionDie;
        }        

        private void Spawner(TowerTypeID towerTypeID, Transform parent)
        {
            DestroyMinions();
            
            GameObject tower = _factory.CreatTower(towerTypeID, parent);
            _currentTower = tower;
            _minionHealth = _currentTower.gameObject.GetComponent<MinionHealth>();
            _minionHealth.Died += OnMinionDie;
        }        

        public void DestroyMinions()
        {
            if (_currentTower != null)
                Destroy(_currentTower);            
        }

        public void ObjectOffset()
        {
            if (!_createTower)
            {
                _currentTower = null;
                _data = null;
            }
        }

        public void ChildMinion(TowerSpawner position)
        {
            _currentTower = position._currentTower;
            _data = position._data;
            CreateMinion?.Invoke(this);
            _minionHealth = GetComponentInChildren<MinionHealth>();
            _minionHealth.Died += OnMinionDie;
        }
    }
}