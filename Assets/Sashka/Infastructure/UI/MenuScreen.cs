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
        [SerializeField] private Button _startButton;
        [SerializeField] private Button _howToPlay;
        [SerializeField] private GameRules _gameRules;
        [SerializeField] private AudioSource _audio;

        public event UnityAction GameStarted;
        public event UnityAction ShowRules;

        private void Start()
        {
            _audio.Play();
        }

        private void OnEnable()
        {
            _startButton.onClick.AddListener(OnStartButton);
            _howToPlay.onClick.AddListener(HowToPlay);
            _gameRules.RulesShowed += OnRulesShowed;
        }

        private void OnDisable()
        {
            _startButton.onClick.RemoveListener(OnStartButton);
            _howToPlay.onClick.RemoveListener(HowToPlay);
            _gameRules.RulesShowed -= OnRulesShowed;
        }

        private void OnRulesShowed() 
            => _menuScreen.SetActive(true);

        private void HowToPlay()
        {
            _menuScreen.SetActive(false);
            ShowRules?.Invoke();
        }

        private void OnStartButton()
        {
            _menuScreen.SetActive(false);
            GameStarted?.Invoke();
        }
    }
}
