using UnityEngine;

namespace CodeBase.Tower
{
    public class OpenPanelTower : MonoBehaviour
    {
        [SerializeField] private Transform _shop;

        private void Start()
        {
            _shop.gameObject.SetActive(false);
        }

        public void OpenPanel()
        {
            _shop.gameObject.SetActive(true);
        }

        public void ClosePanel()
        {
            _shop.gameObject.SetActive(false);
        }
    }
}
