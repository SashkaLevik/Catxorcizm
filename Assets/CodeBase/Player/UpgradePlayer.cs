using System;
using CodeBase.Data;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Player
{
    public class UpgradePlayer : MonoBehaviour
    {
        [SerializeField] private Button _upgrade;
        [SerializeField] private State _heroStats;
        [SerializeField] private int _stepMeleeDamage;
        [SerializeField] private int _stepHealth;
        [SerializeField] private int _levelSpellAmount;
        [SerializeField] private PlayerMoney _playerMoney;
        
        private int _currentSoul;
        private int _currentCostOfSoul;
        private int _levelHero;
        public State HeroState => _heroStats;
        public void Construct(PlayerMoney playerMoney)
        {
            _playerMoney = playerMoney;
            _levelHero = _heroStats.Level;
        }

        private void OnEnable()
        {
            _upgrade.onClick.AddListener(TrySellBuy);
        }

        private void OnDisable()
        {
            _upgrade.onClick.RemoveListener(TrySellBuy);
        }

        private void Update()
        {
            _currentSoul = _playerMoney.CurrentSoul;
        }

        private void TrySellBuy()
        {
            _currentCostOfSoul = _heroStats.Price;

            if (_currentSoul <= 0)
                return;

            if (_currentCostOfSoul <= _currentSoul)
            {
                _playerMoney.BuyUpgradeHero(_heroStats);
                UpgradeLevel();
            }
        }

        private void UpgradeLevel()
        {
            if (_levelHero % _levelSpellAmount == 0)
            {
                _levelHero += 1;
                _heroStats.MeleeAttack += _stepMeleeDamage * (_levelHero - 1);
                _heroStats.MaxHP += _stepHealth * (_levelHero - 1);
                _heroStats.SpellAmount += 1;
                _heroStats.ResetHP();
            }
            else
            {
                _levelHero += 1;
                _heroStats.MeleeAttack += _stepMeleeDamage * (_levelHero - 1);
                _heroStats.MaxHP += _stepHealth * (_levelHero - 1);
                _heroStats.ResetHP();
            }
        }
    }
}