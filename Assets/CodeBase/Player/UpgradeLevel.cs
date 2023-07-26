using System;
using System.Collections.Generic;
using CodeBase.Data;
using CodeBase.Infrastructure.Service.SaveLoad;
using CodeBase.UI.Element;
using UnityEngine;

namespace CodeBase.Player
{
    public class UpgradeLevel : MonoBehaviour, ISavedProgress
    {
        [SerializeField] private List<LevelView> _upgradeLevels;
        [SerializeField] private PlayerMoney _playerMoney;
        [SerializeField] private int _stepMeleeDamage;
        [SerializeField] private int _stepHealth;

        private State _heroStats;
        private int _currentCostOfGold;
        private int _currentSoul;
        private int _levelAmount;
        private int _maxLevelUpgrade;
        private float _health;
        private int _damage;

        public void LoadProgress(PlayerProgress progress)
        {
            _heroStats = progress.HeroState;
            _levelAmount = progress.HeroState.Level;
            _health = progress.HeroState.MaxHP;
            _damage = progress.HeroState.MeleeAttack;
        }

        public void UpdateProgress(PlayerProgress progress)
        {
            progress.HeroState.Level = _levelAmount;
            progress.HeroState.MaxHP = _health;
            progress.HeroState.MeleeAttack = _damage;
        }

        private void Start()
        {
            OpenLevels();
            _maxLevelUpgrade += _upgradeLevels.Count + _levelAmount;
        }

        private void Update()
        {
            _currentSoul = _playerMoney.CurrentSoul;
        }

        private void OnEnable()
        {
            foreach (LevelView upgradeLevel in _upgradeLevels)
            {
                upgradeLevel.SellButtonClick += TrySellBuy;
            }
        }

        private void OnDisable()
        {
            foreach (LevelView upgradeLevel in _upgradeLevels)
            {
                upgradeLevel.SellButtonClick -= TrySellBuy;
            }
        }

        private void OpenLevels()
        {
            for (int i = 0; i < _levelAmount - 1; i++)
            {
                _upgradeLevels[i].enabled = true;
                _upgradeLevels[i].BuyUpgrade();
            }
        }

        private void TrySellBuy(LevelView levelView)
        {
            if (_levelAmount <= _maxLevelUpgrade)
            {
                _currentCostOfGold = _heroStats.PriceLevel * (_heroStats.Level + 1);

                if (_currentSoul <= 0)
                    return;

                if (_currentCostOfGold <= _currentSoul)
                {
                    _playerMoney.BuyUpgradeHero(_heroStats);
                    _levelAmount += 1;
                    _health += _stepHealth;
                    _damage += _stepMeleeDamage;
                    levelView.BuyUpgrade();
                }
            }
        }
    }
}