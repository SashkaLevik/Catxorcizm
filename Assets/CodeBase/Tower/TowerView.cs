using CodeBase.Infrastructure.StaticData;
using CodeBase.UI.Element;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;

namespace CodeBase.Tower
{
    public class TowerView : MonoBehaviour
    {
        [SerializeField] private Image _iconImage;
        [SerializeField] private Image _background;
        [SerializeField] private Button _sellButton;
        [SerializeField] private TMP_Text _price;

        private TowerStaticData _item;
        private OpenPanelMinions _panelMinions;
    
        public event UnityAction<TowerStaticData, TowerView> SellButtonClick;
        public event UnityAction<TowerStaticData> Highlighted;
        
    
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
        }

        public void OnMouseDetected()
        {
            Highlighted?.Invoke(_item);
        }

        private void OnButtonClick()
        {
            SellButtonClick?.Invoke(_item, this);
        }
    }
}