using CodeBase.Data;
using CodeBase.Infrastructure.StaticData;
using UnityEngine;
using UnityEngine.Events;

namespace CodeBase.Player
{
    public class PlayerMoney : MonoBehaviour
    {
        [SerializeField] private int _currentMoney;
        [SerializeField] private int _currentSoul;

        private int _currentMoneyLevel;
        public event UnityAction<int> CurrentMoneyChanged;
        public event UnityAction<int> CurrentSoulChanged;

        public int CurrentMoney => _currentMoney;
        public int CurrentSoul => _currentSoul;

        private void Start()
        {
            CurrentMoneyChanged?.Invoke(_currentMoney);
        }

        public void BuyTower(TowerStaticData data)
        {
            if (_currentMoney > 0)
            {
                _currentMoney -= data.Price;
                CurrentMoneyChanged?.Invoke(_currentMoney);
            }
        }

        public void BuyUpgradeHero(State heroState)
        {
            if (_currentSoul > 0)
            {
                _currentSoul -= heroState.PriceLevel * (heroState.Level + 1);
                CurrentSoulChanged?.Invoke(_currentSoul);
            }
        }

        public void BuyUpgradeHeroSpell(State heroState, int stepUpgrade)
        {
            if (_currentSoul > 0)
            {
                _currentSoul -= heroState.PriceSpell * (stepUpgrade + 1);
                CurrentSoulChanged?.Invoke(_currentSoul);
            }
        }

        public void BuyOpenNewMinions(State heroState, int stepUpgrade)
        {
            if (_currentSoul > 0)
            {
                _currentSoul -= heroState.PriceNewMinions * (stepUpgrade + 1);
                CurrentSoulChanged?.Invoke(_currentSoul);
            }
        }

        public void SellMinions(TowerStaticData data)
        {
            _currentMoney += data.Price;
            CurrentMoneyChanged?.Invoke(_currentMoney);
        }
    }
}