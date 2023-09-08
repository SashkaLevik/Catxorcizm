﻿using Assets.Sashka.Scripts.Minions;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Service;
using CodeBase.Infrastructure.StaticData;
using CodeBase.UI.Forms;
using CodeBase.UI.Service.Factory;
using System;
using System.Collections.Generic;
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
        private bool _isTowerCreated;
        private GameObject _currentTower;
        private string _id;
        private TowerStaticData _data;


        public event UnityAction<TowerSpawner> CreateMinion;
        public bool IsTowerCreated => _isTowerCreated;
        public MinionHealth MinionHealth => _minionHealth;
        public TowerStaticData Data => _data;
        
        public void Construct(IUIFactory uiFactory)
        {
            _uIFactory = uiFactory;
            _uIFactory.Shop.Opened += ShopOnOpened;
        }        

        private void Awake()
        {
            _id = GetComponent<UniqueId>().Id;
            _factory = AllServices.Container.Single<IGameFactory>();
        }        

        private void ShopOnOpened(bool open) { }        

        private void OnDisable()
            => _uIFactory.Shop.Opened -= ShopOnOpened;

        private void Spawner(TowerTypeID towerTypeID, Transform parent)
        {
            DestroyMinions();

            GameObject tower = _factory.CreatTower(towerTypeID, parent);
            _currentTower = tower;
        }

        public void IsCreateTower()
        {
            _isTowerCreated = !_isTowerCreated;
            _sprite.enabled = !_sprite.enabled;
        }

        public void BuyTowerSpawn(TowerStaticData data)
        {
            Spawner(data.TowerTypeID, transform);
            _data = data;
            _isTowerCreated = true;
            _sprite.enabled = false;
            _minionHealth = GetComponentInChildren<MinionHealth>();
            _minionHealth.Died += OnMinionDie;
        }               

        public void OnMinionDie(BaseMinion minion)
        {
            if (_isTowerCreated)
            {
                _isTowerCreated = false;
                _sprite.enabled = true;
            }
        }        

        public void DestroyMinions()
        {
            if (_currentTower != null)
                Destroy(_currentTower);
        }

        public void ObjectOffset(TowerSpawner position)
        {
            _minionHealth.Died -= OnMinionDie;

            if (!position._isTowerCreated)
            {
                position._data = null;
                position._currentTower = null;
                position._minionHealth = null;
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