using System.Collections.Generic;
using CodeBase.Data;
using CodeBase.Infrastructure.Service.SaveLoad;
using CodeBase.UI.Element;
using UnityEngine;

namespace CodeBase.Player
{
    public class UpgradeSpell : MonoBehaviour, ISavedProgress
    {
        [SerializeField] private List<SpellView> _upgrade;
        [SerializeField] private PlayerMoney _playerMoney;

        private List<SpellView> _upgradeSpell = new();
        private State _heroStats;
        private int _currentMoney;
        private int _currentCostOfGold;
        private int _currentSoul;
        private int _spellAmount;
        private int _maxLevelUpgrade;

        public void LoadProgress(PlayerProgress progress)
        {
            _spellAmount = progress.HeroState.SpellAmount;
            Debug.Log("load data Hero SpellAmount");
        }

        public void UpdateProgress(PlayerProgress progress)
        {
            Debug.Log("save Hero SpellAmount");
            progress.HeroState.SpellAmount = _spellAmount;
        }

        private void Awake()
        {
            for (int i = 0; i < _upgrade.Count; i++)
            {
                _upgradeSpell.Add(_upgrade[i]);
                _maxLevelUpgrade = i + 1 + _spellAmount;
            }
        }

        private void Update()
        {
            _currentSoul = _playerMoney.CurrentSoul;
        }

        private void OnEnable()
        {
            foreach (SpellView upgradeSpell in _upgradeSpell)
            {
                upgradeSpell.SellButtonClick += TrySellBuy;
            }
        }

        private void OnDisable()
        {
            foreach (SpellView upgradeSpell in _upgradeSpell)
            {
                upgradeSpell.SellButtonClick -= TrySellBuy;
            }
        }

        private void TrySellBuy(State state, SpellView spellView)
        {
            if (_spellAmount <= _maxLevelUpgrade)
            {
                _currentCostOfGold = state.PriceSpell;
                
                if (_currentSoul <= 0)
                    return;

                if (_currentCostOfGold <= _currentSoul)
                {
                    _playerMoney.BuyUpgradeHeroSpell(state);
                    _spellAmount += 1;
                    spellView.BuyUpgrade();
                }
            }
        }
    }
}