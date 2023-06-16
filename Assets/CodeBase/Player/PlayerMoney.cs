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
                _currentSoul -= heroState.Price;
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