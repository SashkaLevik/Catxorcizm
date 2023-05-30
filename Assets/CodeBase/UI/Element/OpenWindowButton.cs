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
        public TowerSpawner TowerSpawner => _towerSpawner;

        private IWindowService _windowService;

        public void Construct(IWindowService windowService) =>
            _windowService = windowService;

        private void OnEnable()
        {
            //_towerSpawner.ShiftTower += ShowOpenWindow;
            Button.onClick.AddListener(Open);
        }

        private void OnDisable()
        {
            //_towerSpawner.ShiftTower -= ShowOpenWindow;
            Button.onClick.RemoveListener(Open);
        }

        private void ShowOpenWindow(bool active)
        {
            this.gameObject.SetActive(!active);
        }

        private void Open()
        {
            _windowService.Open(WindowId);
            _inventory.SetSpawnPosition(_towerSpawner);
        }
    }
}