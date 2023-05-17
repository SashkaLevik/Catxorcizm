using CodeBase.Infrastructure.StaticData;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace CodeBase.Tower
{
    public class TowerView : MonoBehaviour
    {
        [SerializeField] private Image _iconImage;
        [SerializeField] private Image _background;
        [SerializeField] private Button _sellButton;
        [SerializeField] private TMP_Text _price;

        private TowerStaticData _item;
    
        public event UnityAction<TowerStaticData, TowerView> SellButtonClick;
    
        private void OnEnable()
        {
            _sellButton.onClick.AddListener(OnButtonClick);
        }

        private void OnDisable()
        {
            _sellButton.onClick.RemoveListener(OnButtonClick);
        }
    
        public void Initialize(TowerStaticData item)
        {
            _item = item;
            _iconImage.sprite = item.UIIcon;
            _price.text = item.Price.ToString();
        
            OnEnable();
        }

        private void OnButtonClick()
        {
            SellButtonClick?.Invoke(_item, this);
        }
    }
}