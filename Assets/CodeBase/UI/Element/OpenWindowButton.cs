using System;
using CodeBase.Player;
using CodeBase.Tower;
using CodeBase.UI.Service.Windows;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.Element
{
    public class OpenWindowButton : MonoBehaviour
    {
        [SerializeField] private Inventory _inventory;
        [SerializeField] private TowerSpawner _towerSpawner;
        public Button Button;
        public WindowId WindowId;

        private IWindowService _windowService;

        public void Construct(IWindowService windowService) => 
            _windowService = windowService;

        private void Update()
        {
            _towerSpawner.ObjectExists += PanelActive;
        }

        private void OnEnable()
        {
            
            Button.onClick.AddListener(Open);
        }

        private void OnDisable()
        {
            _towerSpawner.ObjectExists -= PanelActive;
            Button.onClick.RemoveListener(Open);
        }

        private void PanelActive(bool active)
        {
            gameObject.SetActive(!active);
        }

        private void Open()
        {
            _windowService.Open(WindowId);
            _inventory.SetSpawnPosition(_towerSpawner);

        }
    }
}