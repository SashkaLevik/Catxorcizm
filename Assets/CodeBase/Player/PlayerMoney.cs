using CodeBase.Data;
using CodeBase.Infrastructure.Service.SaveLoad;
using CodeBase.Infrastructure.StaticData;
using UnityEngine;
using UnityEngine.Events;

namespace CodeBase.Player
{
    public class PlayerMoney : MonoBehaviour, ISavedProgress
    {
        [SerializeField] private int _currentSoul;

        private int _currentMoneyLevel;
        public event UnityAction<int> CurrentSoulChanged;
        public event UnityAction<int> CurrentSoulLevelChanged;
        public int CurrentSoul => _currentSoul;
        public int CurrentMoneyLevel => _currentMoneyLevel;

        private void Start()
        {
            if (_currentSoul < _currentMoneyLevel)
            {
                _currentMoneyLevel -= _currentSoul;
            }

            CurrentSoulChanged?.Invoke(_currentSoul);
        }

        public void BuyTower(TowerStaticData data)
        {
            if (_currentSoul >= data.Price)
            {
                _currentSoul -= data.Price;
                CurrentSoulChanged?.Invoke(_currentSoul);
            }
        }

        public void BuyUpgradeHero(State heroState)
        {
            if (_currentMoneyLevel > 0)
            {
                _currentMoneyLevel -= heroState.PriceLevel * (heroState.Level + 1);
                CurrentSoulLevelChanged?.Invoke(_currentMoneyLevel);
            }
        }

        public void BuyUpgradeHeroSpell(State heroState, int stepUpgrade)
        {
            if (_currentMoneyLevel > 0)
            {
                _currentMoneyLevel -= heroState.PriceSpell * (stepUpgrade + 1);
                CurrentSoulLevelChanged?.Invoke(_currentMoneyLevel);
            }
        }

        public void BuyOpenNewMinions(State heroState, int stepUpgrade)
        {
            if (_currentMoneyLevel > 0)
            {
                _currentMoneyLevel -= heroState.PriceNewMinions * (stepUpgrade + 1);
                CurrentSoulLevelChanged?.Invoke(_currentMoneyLevel);
            }
        }

        public void SellMinions(TowerStaticData data)
        {
            _currentSoul += data.Price;
            CurrentSoulChanged?.Invoke(_currentSoul);
        }

        public void AddMoney(int reward)
        {
            _currentSoul += reward;
            CurrentSoulChanged?.Invoke(_currentSoul);
        }

        public void UpdateProgress(PlayerProgress progress)
        {
            _currentMoneyLevel += _currentSoul;
            progress.CurrentSoul = _currentMoneyLevel;
            Debug.Log("сохранение money");
        }

        public void LoadProgress(PlayerProgress progress)
        {
            _currentMoneyLevel = progress.CurrentSoul;
        }
    }
}