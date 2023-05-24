using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.Forms
{
    public abstract class BaseWindow : MonoBehaviour
    {
        public Button CloseButton;

        private void Awake()
        {
            OnAwake();
        }

        protected virtual void OnAwake()
        {
            CloseButton.onClick.AddListener(() => ClosePanel());
        }

        private void ClosePanel()
        {
            gameObject.GetComponent<ShopWindow>().Inactive();
            gameObject.SetActive(false);
        }
    }
}