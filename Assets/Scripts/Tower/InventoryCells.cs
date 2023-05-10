using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InventoryCells : MonoBehaviour
{
    [SerializeField] private Image _iconImage;
    [SerializeField] private Image _background;
    [SerializeField] private Button _sellButton;
    [SerializeField] private TMP_Text _price;

    private AssetItem _item;
    
    public event UnityAction<AssetItem, InventoryCells> SellButtonClick;
    
    private void OnEnable()
    {
        _sellButton.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _sellButton.onClick.RemoveListener(OnButtonClick);
    }
    
    public void Initialize(AssetItem item)
    {
        _item = item;
        _iconImage.sprite = item.UIIcon;
        _price.text = item.Price.ToString();
        
        OnEnable();
    }
    
    public void Render(ITemTower item)
    {
        _iconImage.sprite = item.UIIcon;
    }

    private void OnButtonClick()
    {
        SellButtonClick?.Invoke(_item, this);
    }
}