using System.Collections.Generic;
using CodeBase.Infrastructure.StaticData;
using CodeBase.Player;
using UnityEngine;
using UnityEngine.Events;

namespace CodeBase.Tower
{
    public class ShopTower : MonoBehaviour
    {
        [SerializeField] private PlayerMoney _playerMoney;
        [SerializeField] private OpenPanelTower _closePanel;
        [SerializeField] private List<TowerStaticData> _items;
        [SerializeField] private List<TowerView> _towerViewPrefabs;

        private int _currentCostOfGold;
        private int _currentMoney;
        private readonly List<TowerView> _towerViews = new List<TowerView>();
        public event UnityAction<TowerStaticData> Happened;

        private void Start()
        {
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
            foreach (var view in _towerViews)
            {
                view.SellButtonClick += TrySellBuy;
            }
        }

        private void OnDisable()
        {
            foreach (var view in _towerViews)
            {
                view.SellButtonClick -= TrySellBuy;
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
                Happened?.Invoke(data);
                _closePanel.ClosePanel();
            }
        }
    }
}