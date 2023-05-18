using CodeBase.UI.Service.Windows;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace CodeBase.UI.Element
{
    public class OpenWindowButton : MonoBehaviour
    {
        public Button Button;
        public WindowId WindowId;
        public Transform _spawnPointPosition;
        //public event UnityAction<Transform> BuildButtonClick;
        
        private IWindowService _windowService;

        public void Construct(IWindowService windowService) => 
            _windowService = windowService;

        private void Awake() => 
            Button.onClick.AddListener(Open);

        // private void OnEnable()
        // {
        //     Button.onClick.AddListener(Open);
        // }
        //
        // private void OnDisable()
        // {
        //     Button.onClick.RemoveListener(Open);
        // }
        
        private void Open()
        {
            _windowService.Open(WindowId);
            //BuildButtonClick?.Invoke(_spawnPointPosition);
        }
    }
}