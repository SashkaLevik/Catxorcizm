using System;
using System.Collections.Generic;
using CodeBase.Data;
using CodeBase.Infrastructure.Service.SaveLoad;
using CodeBase.UI.Element;
using UnityEngine;
using TMPro;

namespace CodeBase.Player
{
    public class UpgradeSpell : MonoBehaviour, ISavedProgress
    {
        [SerializeField] private List<SpellView> _upgradeSpellViews;
        [SerializeField] private PlayerMoney _playerMoney;
        [SerializeField] private int _defaultSpellCount = 2;
        [SerializeField] private TMP_Text _price;

        private State _heroStats;
        private int _currentCostOfGold;
        private int _maxLevelUpgrade;
        private int _currentSoul;
        private int _spellAmount;

        public void LoadProgress(PlayerProgress progress)
        {
            _heroStats = progress.HeroState;
            _spellAmount = _heroStats.SpellAmount;
        }

        public void UpdateProgress(PlayerProgress progress)
        {
            progress.HeroState.SpellAmount = _spellAmount;
        }

        private void Start()
        {
            OpenSpellView();

            _maxLevelUpgrade = _upgradeSpellViews.Count + _defaultSpellCount;
        }

        private void Update()
        {
            _currentSoul = _playerMoney.EarnedSouls;
            _currentCostOfGold = _heroStats.PriceSpell * (_spellAmount);
            _price.text = _currentCostOfGold.ToString();
        }

        private void OnEnable()
        {
            foreach (SpellView upgradeSpell in _upgradeSpellViews)
            {
                upgradeSpell.SellButtonClick += TrySellBuy;
            }
        }

        private void OnDisable()
        {
            foreach (SpellView upgradeSpell in _upgradeSpellViews)
            {
                upgradeSpell.SellButtonClick -= TrySellBuy;
            }
        }

        private void OpenSpellView()
        {
            for (int i = 0; i < _spellAmount - _defaultSpellCount; i++)
            {
                _upgradeSpellViews[i].BuyUpgrade();
            }
        }

        private void TrySellBuy(SpellView spellView)
        {
            if (_spellAmount <= _maxLevelUpgrade)
            {
                if (_currentSoul <= 0)
                    return;

                if (_currentCostOfGold <= _currentSoul)
                {
                    _playerMoney.BuyUpgradeHeroSpell(_heroStats, _spellAmount);
                    _spellAmount += 1;
                    spellView.BuyUpgrade();
                }
            }
        }
    }
}