using System;
using System.Collections.Generic;
using CodeBase.Infrastructure.StaticData;
using CodeBase.Player;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace CodeBase.UI.Forms
{
    public class UpgradeWindow : BaseWindow
    {
        [SerializeField] private Button _upgradeButton;
        [SerializeField] private Button _sellButton;
        [SerializeField] private List<TowerStaticData> _data;

        private TowerStaticData _currentData;
        private TowerStaticData _nextUpgrade;
        private PlayerMoney _playerMoney;
        private Inventory _inventory;
        private int _currentCostOfGold;
        private int _currentMoney;
        private int _maxLevel = 3;

        public void Construct(PlayerMoney playerMoney, Inventory inventory)
        {
            _playerMoney = playerMoney;
            _inventory = inventory;
        }

        public void MaxLevelMinions()
        {
            if (_currentData.Level == _maxLevel)
            {
                _upgradeButton.interactable = false;
            }
        }

        public void UpgradeData(TowerTypeID typeID)
        {
            foreach (TowerStaticData staticData in _data)
            {
                if (staticData.TowerTypeID == typeID)
                {
                    _currentData = staticData;
                }

                if (staticData.TowerTypeID == typeID+1)
                {
                    _nextUpgrade = staticData;
                }
            }
        }

        private void Update()
        {
            _currentMoney = _playerMoney.CurrentMoney;
        }

        private void OnEnable()
        {
            _upgradeButton.onClick.AddListener(UpdateBuy);
            _sellButton.onClick.AddListener(SellMinions);
        }

        private void OnDisable()
        {
            _upgradeButton.onClick.RemoveListener(UpdateBuy);
            _sellButton.onClick.RemoveListener(SellMinions);
        }

        private void UpdateBuy()
        {
            TryBuy(_nextUpgrade);
        }

        private void TryBuy(TowerStaticData data)
        {
            _currentCostOfGold = data.Price;

            if (_currentMoney <= 0)
                return;

            if (_currentCostOfGold <= _currentMoney)
            {
                _playerMoney.SellMinions(_currentData);
                _inventory.SellMinions(_currentData);
                //удалить оюъект
                _playerMoney.BuyTower(data);
                _inventory.BuyMinions(data);
                _inventory.SpawnMinions();
                data.ResetHP();
                gameObject.SetActive(false);
            }
        }

        private void SellMinions()
        {
            TrySell(_currentData);
        }

        private void TrySell(TowerStaticData data)
        {
            if (data != null)
            {
                _playerMoney.SellMinions(data);
                _inventory.SellMinions(data);
                Destroy(data.GameObject());
            }
            else
            {
                return;
            }
        }
    }
}