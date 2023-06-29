using System;
using System.Collections.Generic;
using CodeBase.Infrastructure.StaticData;
using CodeBase.Player;
using CodeBase.UI.Element;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace CodeBase.UI.Forms
{
    public class UpgradeMinions : BaseWindow
    {
        [SerializeField] private Button _upgradeButton;
        [SerializeField] private List<TowerStaticData> _data;
        [SerializeField] private OpenPanelMinions _panelMinions;

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

        public void MaxLevelMinions(TowerStaticData data)
        {
            _upgradeButton.interactable = data.Level != _maxLevel;
        }

        public void UpgradeData(TowerStaticData data)
        {
            foreach (TowerStaticData staticData in _data)
            {
                if (staticData.TowerTypeID == data.TowerTypeID)
                {
                    _currentData = staticData;
                }

                if (staticData.TowerTypeID == data.TowerTypeID+1)
                {
                    _nextUpgrade = staticData;
                }
            }
        }

        public void ShowMinions(TowerStaticData data)
        {
            foreach (TowerStaticData staticData in _data)
            {
                if (staticData.TowerTypeID == data.TowerTypeID)
                {
                    _panelMinions.Show(staticData);
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
        }

        private void OnDisable()
        {
            _upgradeButton.onClick.RemoveListener(UpdateBuy);
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
                _inventory.CurrentData(_currentData);
                _playerMoney.SellMinions(_currentData);
                _inventory.SellMinions(_currentData);
                _playerMoney.BuyTower(data);
                _inventory.BuyMinions(data);
                _inventory.SpawnMinions();
                data.ResetHP();
                gameObject.SetActive(false);
            }
        }

        private void TrySell(TowerStaticData data)
        {
            if (data != null)
            {
                _playerMoney.SellMinions(data);
                _inventory.SellMinions(data);
                _inventory.Sell();
                gameObject.SetActive(false);
            }
        }
    }
}