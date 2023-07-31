using System;
using CodeBase.Data;
using CodeBase.Infrastructure.Service.SaveLoad;
using UnityEngine;

namespace CodeBase.Player
{
    public class UpgradePlayer : MonoBehaviour, ISavedProgress
    {
        [SerializeField] private int _stepMeleeDamage;
        [SerializeField] private int _stepHealth;
        [SerializeField] private int _levelSpellAmount;
        [SerializeField] private PlayerMoney _playerMoney;

        private State _heroStats;
        private int _currentSoul;
        private int _currentCostOfSoul;
        private int _levelHero = 1;
        private int _attackDamage = 3;
        private float _maxHp = 4;
        private int _spellAmount = 2;

        public void LoadProgress(PlayerProgress progress)
        {
            _heroStats = progress.HeroState;
            _levelHero = progress.HeroState.Level;
            _attackDamage = progress.HeroState.MeleeAttack;
            _maxHp = progress.HeroState.MaxHP;
            _spellAmount = progress.HeroState.SpellAmount;
            _heroStats.ResetHP();
            Debug.Log("load data Hero");
        }

        public void UpdateProgress(PlayerProgress progress)
        {
            Debug.Log("save Hero");
            progress.HeroState.Level = _levelHero;
            progress.HeroState.MeleeAttack = _attackDamage;
            progress.HeroState.MaxHP = _maxHp;
            progress.HeroState.SpellAmount = _spellAmount;
        }

        private void Update()
        {
            _currentSoul = _playerMoney.CurrentSoul;
        }

        public void TrySellBuy()
        {
            _currentCostOfSoul = _heroStats.PriceLevel;

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
                _levelHero ++;
                _attackDamage += _stepMeleeDamage * (_levelHero - 1);
                _maxHp += _stepHealth * (_levelHero - 1);
                _spellAmount ++;
            }
            else
            {
                _levelHero += 1;
                _attackDamage += _stepMeleeDamage * (_levelHero - 1);
                _maxHp += _stepHealth * (_levelHero - 1);
            }
        }
    }
}