using CodeBase.Data;
using CodeBase.Infrastructure.Service.SaveLoad;
using TMPro;
using UnityEngine;

namespace CodeBase.Player
{
    public class ExtraLives : MonoBehaviour, ISavedProgress
    {
        [SerializeField] private HeroHealth _heroHealth;
        [SerializeField] private TMP_Text _extraLiveText;
        
        
        private int _live;

        public int Live => _live;

        private void Start()
        {
            _extraLiveText.text = _live.ToString();
        }

        public void Construct(HeroHealth heroHealth)
        {
            _heroHealth = heroHealth;
            _heroHealth.Died += HeroHealthOnDied;
        }

        private void OnDestroy()
        {
            _heroHealth.Died -= HeroHealthOnDied;
        }

        private void HeroHealthOnDied()
        {
            _live -= 1;
            _extraLiveText.text = _live.ToString();
        }

        public void LoadProgress(PlayerProgress progress)
        {
            _live = progress.HeroState.Lives;
        }

        public void UpdateProgress(PlayerProgress progress)
        {
            progress.HeroState.Lives = _live;
        }
    }
}