using System;
using System.Collections.Generic;
using CodeBase.Player;
using CodeBase.Data;
using CodeBase.Infrastructure.Service.SaveLoad;
using CodeBase.Infrastructure.StaticData;
using UnityEngine;

namespace CodeBase.UI.Element
{
    public class OpenNewMinions : MonoBehaviour, ISavedProgress
    {
        [SerializeField] private List<MinionView> _upgradeMinionViews;
        [SerializeField] private PlayerMoney _playerMoney;
        [SerializeField] private int _defaultMinionsCount = 1;
        
        private State _heroStats;
        private int _maxMinions;
        private int _countMinions;
        private int _currentCostOfGold;
        private int _currentSoul;

        public void LoadProgress(PlayerProgress progress)
        {
            _heroStats = progress.HeroState;
            _countMinions = progress.NumberOfMinions;
        }

        public void UpdateProgress(PlayerProgress progress)
        {
            progress.NumberOfMinions = _countMinions;
        }

        private void Start()
        {
            OpenMinions();
            _maxMinions = _upgradeMinionViews.Count + 1;
        }

        private void Update()
        {
            _currentSoul = _playerMoney.CurrentMoneyLevel;
        }
        
        private void OnEnable()
        {
            foreach (MinionView minionView in _upgradeMinionViews)
            {
                minionView.SellButtonClick += TrySellBuy;
            }
        }

        private void OnDisable()
        {
            foreach (MinionView minionView in _upgradeMinionViews)
            {
                minionView.SellButtonClick -= TrySellBuy;
            }
        }
        
        private void TrySellBuy(MinionView minionView)
        {
            if (_countMinions <= _maxMinions)
            {
                _currentCostOfGold = _heroStats.PriceSpell * (_countMinions + 1);

                if (_currentSoul <= 0)
                    return;

                if (_currentCostOfGold <= _currentSoul)
                {
                    _playerMoney.BuyOpenNewMinions(_heroStats, _countMinions);
                    _countMinions += 1;
                    minionView.BuyUpgrade();
                }
            }
        }
        
        private void OpenMinions()
        {
            for (int i = 0; i < _countMinions - _defaultMinionsCount; i++)
            {
                _upgradeMinionViews[i].BuyUpgrade();
            }
        }
    }
}