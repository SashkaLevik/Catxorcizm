using Agava.YandexGames;
using CodeBase.Data;
using CodeBase.Infrastructure.Service.SaveLoad;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Player
{
    public class ExtraLives : MonoBehaviour, ISavedProgress
    {
        [SerializeField] private HeroHealth _heroHealth;
        [SerializeField] private TMP_Text _extraLiveText;
        [SerializeField] private Image _diedImage;
        [SerializeField] private Button _revivalButton;
                
        private int _live;

        public int Live => _live;

        private void Start()
        {
            _diedImage.gameObject.SetActive(false);
            _extraLiveText.text = _live.ToString();
        }

        private void OnEnable()
            => _revivalButton.onClick.AddListener(ShowRewardAdd);

        private void OnDisable()
            => _revivalButton.onClick.RemoveListener(ShowRewardAdd);

        public void Construct(HeroHealth heroHealth)
        {
            _heroHealth = heroHealth;
            _heroHealth.Died += HeroHealthOnDied;
        }

        private void OnDestroy()
            => _heroHealth.Died -= HeroHealthOnDied;

        public void LoadProgress(PlayerProgress progress)
            => _live = progress.HeroState.Lives;

        public void UpdateProgress(PlayerProgress progress)
            => progress.HeroState.Lives = _live;

        public void ShowRewardAdd()
        {
            VideoAd.Show(OnAddOpen, OnAddClosed, null, OnAddError);
        }        

        private void HeroHealthOnDied()
        {
            _live -= 1;
            _extraLiveText.text = _live.ToString();

            if (_live <= 0) _diedImage.gameObject.SetActive(true);
        }        

        private void OnAddOpen()
        {
            AudioListener.volume = 0;
            _live += 9;
            _extraLiveText.text = _live.ToString();
            _diedImage.gameObject.SetActive(false);
        }

        private void OnAddError(string obj)
        {
            _live += 1;
            _extraLiveText.text = _live.ToString();
            _diedImage.gameObject.SetActive(false);
            AudioListener.volume = 1;
        }

        private void OnAddClosed()
        {
            AudioListener.volume = 1;            
        }        
    }
}