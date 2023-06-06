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
        [SerializeField] private Button _academy;

        public event UnityAction PortLoaded;
        public event UnityAction MarketLoaded;
        public event UnityAction MageLoaded;
        public event UnityAction AcademyLoaded;

        private void Start()
        {
            //_marketArea.interactable = false;
            //_mageArea.interactable = false;
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


    }    
}
