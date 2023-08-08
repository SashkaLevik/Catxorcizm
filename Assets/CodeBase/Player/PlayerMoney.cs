using Agava.YandexGames;
using CodeBase.Data;
using CodeBase.Infrastructure.Service.SaveLoad;
using CodeBase.Infrastructure.StaticData;
using CodeBase.UI.Element;
using UnityEngine;
using UnityEngine.Events;

namespace CodeBase.Player
{
    public class PlayerMoney : MonoBehaviour, ISavedProgress
    {
        [SerializeField] private int _currentSoul;
        [SerializeField] private int _startSoulIncreaseAmount;
        [SerializeField] private int _rewardRete;
        [SerializeField] private GameObject _advMoney;

        private int _earnedSouls;
        public event UnityAction<int> CurrentSoulChanged;

        public int CurrentSoul => _currentSoul;
        public int EarnedSouls => _earnedSouls;        

        private void Start()
        {
            //if (_currentSoul < _currentMoneyLevel)
            //{
            //    _currentMoneyLevel -= _currentSoul;
            //}
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

        public void BuyUpgradeHero(State heroState, int stepUpgrade)
        {
            if (_earnedSouls > 0)
            {
                _earnedSouls -= heroState.PriceLevel * (stepUpgrade);
                CurrentSoulChanged?.Invoke(_earnedSouls);
            }
        }

        public void BuyUpgradeHeroSpell(State heroState, int stepUpgrade)
        {
            if (_earnedSouls > 0)
            {
                _earnedSouls -= heroState.PriceSpell * (stepUpgrade);
                CurrentSoulChanged?.Invoke(_earnedSouls);
            }
        }

        public void BuyOpenNewMinions(State heroState, int stepUpgrade)
        {
            if (_earnedSouls > 0)
            {
                _earnedSouls -= heroState.PriceNewMinions * (stepUpgrade);
                CurrentSoulChanged?.Invoke(_earnedSouls);
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
            _earnedSouls += _currentSoul;
            progress.CurrentSoul = _earnedSouls;
            Debug.Log("сохранение money");
        }

        public void LoadProgress(PlayerProgress progress)
        {
            _earnedSouls = progress.CurrentSoul;
        }
        
        public void AddAdMoney()
        {
            VideoAd.Show(null, ADVMoney);
        }

        private void ADVMoney()
        {
            _earnedSouls += _rewardRete;
            _advMoney.SetActive(false);
        }
    }
}