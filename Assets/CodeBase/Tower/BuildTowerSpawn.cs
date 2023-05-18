using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace CodeBase.Tower
{
    public class BuildTowerSpawn : MonoBehaviour
    {
        [SerializeField] private Transform _spawner;
        [SerializeField] private Button _button;
        [SerializeField] private OpenPanelTower _panel;

        public Transform _spawnPointPosition;
    
        public event UnityAction<Transform> BuildButtonClick;

        private void OnEnable()
        {
            _button.onClick.AddListener(OnButtonClick);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnButtonClick);
        }

        private void Start()
        {
            _spawnPointPosition = _spawner;
        }

        private void OnButtonClick()
        {
            _panel.OpenPanel();
            BuildButtonClick?.Invoke(_spawner);
        }
    }
}