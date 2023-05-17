using CodeBase.Infrastructure.StaticData;
using CodeBase.Tower;
using UnityEngine;
using UnityEngine.Events;

namespace CodeBase
{
    public class PlayerMoney : MonoBehaviour
    {
        [SerializeField] private int _moneyLevels;
        [SerializeField] private int _currentMoney;
    
        private int _currentMoneyLevel;
    
        public event UnityAction<int> MoneyChanged;
        public event UnityAction<int> CurrentMoneyChanged;
    
        public int CurrentMoney => _currentMoney;

        private void Start()
        {
            CurrentMoneyChanged?.Invoke(_currentMoney);
            _currentMoneyLevel = _currentMoney;
        }
    
        public void IncreaseMoney(int value)
        {
            _moneyLevels += value;
            MoneyChanged?.Invoke(_moneyLevels);
        }
    
        public void BuyTower(TowerStaticData data)
        {
            if (_currentMoney > 0)
            {
                _currentMoney -= data.Price;
                CurrentMoneyChanged?.Invoke(_currentMoney);
            }
        }
    }
}