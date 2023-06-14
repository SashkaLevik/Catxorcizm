using Assets.Sashka.Infastructure.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sashka.Infastructure.UI
{
    public class MenuScreen : MonoBehaviour
    {
        [SerializeField] private GameObject _menuScreen;
        [SerializeField] private GameObject _settingsScreen;
        [SerializeField] private GameObject _levelScreen;
        [SerializeField] private GameObject _tutorialScreen;
        [SerializeField] private Button _startButton;
        [SerializeField] private Button _howToPlay;
        [SerializeField] private Button _settings;
        [SerializeField] private GameRules _gameRules;
        [SerializeField] private AudioSource _audio;

        public event UnityAction GameStarted;
        public event UnityAction ShowRules;

        private void Start()
        {
            _audio.Play();
            _settingsScreen.SetActive(false);
            _levelScreen.SetActive(false);
            _tutorialScreen.SetActive(false);
        }

        private void OnEnable()
        {
            _startButton.onClick.AddListener(OnStartButton);
            _howToPlay.onClick.AddListener(OnTutorialButton);
            _settings.onClick.AddListener(OnSettingsButton);
            _gameRules.RulesShowed += OnRulesShowed;
        }

        private void OnDisable()
        {
            _startButton.onClick.RemoveListener(OnStartButton);
            _howToPlay.onClick.RemoveListener(OnTutorialButton);
            _gameRules.RulesShowed -= OnRulesShowed;
        }

        private void OnRulesShowed() 
            => _menuScreen.SetActive(true);

        private void OnStartButton()
            => Invoke(nameof(OpenMap), 0.6f);

        private void OnTutorialButton()
            => Invoke(nameof(OpenTutorial), 0.6f);

        private void OnSettingsButton()
            => Invoke(nameof(OpenSettings), 0.6f);       

        private void OpenMap()
        {
            _menuScreen.SetActive(false);
            _levelScreen.SetActive(true);
            GameStarted?.Invoke();
        }

        private void OpenTutorial()
        {
            //_menuScreen.SetActive(false);
            _tutorialScreen.SetActive(true);
            ShowRules?.Invoke();
        }

        private void OpenSettings()
        {
            _settingsScreen.SetActive(true);
        }
    }
}
