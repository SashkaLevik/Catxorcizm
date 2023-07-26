using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MinionView : MonoBehaviour
{
    [SerializeField] private Button _sellButton;
    [SerializeField] private Image _iconOpenImage;
    [SerializeField] private Image _iconColorImage;

    public event UnityAction<MinionView> SellButtonClick;
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
        _iconOpenImage.enabled = false;
        _iconColorImage.color = new Color(1f,1f,1f,1f);
        _sellButton.interactable = false;
    }
}
