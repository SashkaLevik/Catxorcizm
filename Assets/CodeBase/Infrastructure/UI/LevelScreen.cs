using CodeBase.Data;
using CodeBase.Infrastructure.Service;
using CodeBase.Infrastructure.Service.PersistentProgress;
using CodeBase.Infrastructure.Service.SaveLoad;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace CodeBase.Infrastructure.UI
{
    class LevelScreen : MonoBehaviour
    {
        [SerializeField] private Button _portArea;
        [SerializeField] private Button _marketArea;
        [SerializeField] private Button _mageArea;
        [SerializeField] private Button _academy;        
        [SerializeField] private List<Button> _buttons;
        [SerializeField] private List<Image> _images;

        private int _gameLevel;
        private IPersistentProgressService _loadService;
        public event UnityAction PortLoaded;
        public event UnityAction MarketLoaded;
        public event UnityAction MageLoaded;
        public event UnityAction AcademyLoaded;

        private void Awake()
        {
            _loadService = AllServices.Container.Single<IPersistentProgressService>();
            _gameLevel = _loadService.Progress.HeroState.GameLevel;
        }

        private void Start()
        {
            _marketArea.interactable = false;
            _mageArea.interactable = false;
            OpenLevels();
        }                

        private void OnEnable()
        {
            _portArea.onClick.AddListener(LoadPort);
            _marketArea.onClick.AddListener(LoadMarket);
            _mageArea.onClick.AddListener(LoadMage);
            _academy.onClick.AddListener(LoadAcademy);
        }

        private void OnDisable()
        {
            _portArea.onClick.RemoveListener(LoadPort);
            _marketArea.onClick.RemoveListener(LoadMarket);
            _mageArea.onClick.RemoveListener(LoadMage);
            _academy.onClick.RemoveListener(LoadAcademy);
        }

        private void LoadAcademy()
        {
            AcademyLoaded?.Invoke();
        }

        private void LoadMage()
        {
            MageLoaded?.Invoke();
        }

        private void LoadMarket()
        {
            MarketLoaded?.Invoke();
        }

        private void LoadPort()
        {
            PortLoaded?.Invoke();
        }        

        public void OpenLevels()
        {
            if (_gameLevel > 0)
            {
                for (int i = 0; i < _gameLevel - 1; i++)
                {
                    _buttons[i].interactable = false;
                    _images[i].gameObject.SetActive(false);
                    _buttons[_gameLevel].interactable = true;
                }
            }
                                    
        }        
    }    
}
