using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Tower
{
    public class ShopTower : MonoBehaviour
    {
        [SerializeField] private PlayerMoney _playerMoney;
        [SerializeField] private OpenPanelTower _closePanel;
        [SerializeField] private List<TowerStaticData> _items;
        [SerializeField] private List<TowerView> _towerViewPrefabs;
        //[SerializeField] private BuildTowerSpawn[] _buildTower;

        private Transform _selectedSpawnPoint;
        private int _currentCostOfGold;
        private int _currentMoney;
        private readonly List<TowerView> _towerViews = new List<TowerView>();

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

            // foreach (BuildTowerSpawn buildTowerSpawn in _buildTower)
            // {
            //     buildTowerSpawn.BuildButtonClick += TargetSpawn;
            // }
        }

        private void OnDisable()
        {
            foreach (var view in _towerViews)
            {
                view.SellButtonClick -= TrySellBuy;
            }
        
            // foreach (BuildTowerSpawn buildTowerSpawn in _buildTower)
            // {
            //     buildTowerSpawn.BuildButtonClick -= TargetSpawn;
            // }
        }

        private void TargetSpawn(Transform spawn)
        {
            _selectedSpawnPoint = spawn;
        }

        private void TrySellBuy(TowerStaticData data, TowerView view)
        {
            _currentCostOfGold = data.Price;
        
        
            if (_currentMoney <= 0)
                return;

            if (_currentCostOfGold <= _currentMoney)
            {
                _playerMoney.BuyTower(data);
                _closePanel.ClosePanel();
            }
        }
    }
}