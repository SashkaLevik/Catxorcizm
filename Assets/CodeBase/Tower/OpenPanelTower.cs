using UnityEngine;

namespace CodeBase.Tower
{
    public class OpenPanelTower : MonoBehaviour
    {
        [SerializeField] private Transform _panel;
        [SerializeField] private Transform _buttonClose;

        private void Start()
        {
            _panel.gameObject.SetActive(false);
            _buttonClose.gameObject.SetActive(false);
        }

        public void OpenPanel()
        {
            _panel.gameObject.SetActive(true);
            _buttonClose.gameObject.SetActive(true);
        }

        public void ClosePanel()
        {
            _panel.gameObject.SetActive(false);
            _buttonClose.gameObject.SetActive(false);
        }
    }
}
