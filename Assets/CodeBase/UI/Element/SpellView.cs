using System;
using CodeBase.Data;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace CodeBase.UI.Element
{
    public class SpellView : MonoBehaviour
    {
        [SerializeField] private Button _sellButton;
        [SerializeField] private Image _icon;
        [SerializeField] private Image _iconOpen;

        public bool BuySpell;
        
        public event UnityAction<SpellView> SellButtonClick;

        private void OnEnable()
        {
            _sellButton.onClick.AddListener(OnButtonClick);
        }

        private void OnDisable()
        {
            _sellButton.onClick.RemoveListener(OnButtonClick);
        }

        private void OnButtonClick()
        {
            SellButtonClick?.Invoke(this);
        }

        public void BuyUpgrade()
        {
            BuySpell = !BuySpell;
            _icon.gameObject.SetActive(false);
            _iconOpen.gameObject.SetActive(true);
            _sellButton.interactable = false;
        }
    }
}