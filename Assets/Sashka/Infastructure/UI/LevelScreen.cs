using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

namespace Assets.Sashka.Infastructure.UI
{
    class LevelScreen : MonoBehaviour
    {
        [SerializeField] private Button _portArea;
        [SerializeField] private Button _marketArea;
        [SerializeField] private Button _mageArea;

        public event UnityAction PortLoaded;
        public event UnityAction MarketLoaded;
        public event UnityAction MageLoaded;

        private void Start()
        {
            _marketArea.interactable = false;
            _mageArea.interactable = false;
        }                

        private void OnEnable()
        {
            _portArea.onClick.AddListener(LoadPort);
            _marketArea.onClick.AddListener(LoadMarket);
            _mageArea.onClick.AddListener(LoadMage);
        }

        private void OnDisable()
        {
            _portArea.onClick.RemoveListener(LoadPort);
            _marketArea.onClick.RemoveListener(LoadMarket);
            _mageArea.onClick.RemoveListener(LoadMage);
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
    }    
}
