using System;
using System.Collections.Generic;
using CodeBase.Infrastructure.StaticData;
using CodeBase.Player;
using CodeBase.Tower;
using CodeBase.UI.Element;
using UnityEngine;

namespace CodeBase.UI.Forms
{
    public class ShopWindow : BaseWindow
    {
        [SerializeField] private List<TowerStaticData> _items;
        [SerializeField] private List<TowerView> _towerViewPrefabs;
        [SerializeField] private OpenPanelMinions _panelMinions;

        private PlayerMoney _playerMoney;
        private Inventory _inventory;
        private int _currentCostOfGold;
        private int _currentMoney;
        private readonly List<TowerView> _towerViews = new();
        
        public event Action<bool> Opened;
        private bool _isOpen;

        public void Construct(PlayerMoney playerMoney, Inventory inventory)
        {
            _playerMoney = playerMoney;
            _inventory = inventory;
        }

        public void Inactive()
        {
            _isOpen = false;
            Opened?.Invoke(_isOpen);
        }

        protected override void OnAwake()
        {
            base.OnAwake();
            
            for (int i = 0; i < _items.Count; i++)
            {
                _towerViews.Add(_towerViewPrefabs[i]);
                _towerViewPrefabs[i].Initialize(_items[i]);
            }
        }

        private void Update()
        {
            _currentMoney = _playerMoney.CurrentMoney;
        }

        private void OnEnable()
        {
            _isOpen = true;
            Opened?.Invoke(_isOpen);

            foreach (TowerView view in _towerViews)
            {
                view.SellButtonClick += TrySellBuy;
                view.Highlighted += _panelMinions.Show;
            }
        }

        private void OnDisable()
        {
            foreach (TowerView view in _towerViews)
            {
                view.SellButtonClick -= TrySellBuy;
                view.Highlighted -= _panelMinions.Show;
            }
        }

        private void TrySellBuy(TowerStaticData data, TowerView view)
        {
            _currentCostOfGold = data.Price;

            if (_currentMoney <= 0)
                return;

            if (_currentCostOfGold <= _currentMoney)
            {
                _playerMoney.BuyTower(data);
                _inventory.BuyMinions(data);
                _inventory.SpawnMinions();
                gameObject.SetActive(false);
            }
        }
    }
}