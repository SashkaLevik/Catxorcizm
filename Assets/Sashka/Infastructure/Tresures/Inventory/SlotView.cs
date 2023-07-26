using UnityEngine;
using UnityEngine.UI;

namespace Assets.Sashka.Infastructure.Tresures
{
    public class SlotView : MonoBehaviour
    {
        [SerializeField] private Image _itemSprite;
        [SerializeField] private Slot _assignedSlot;

        public Slot AssignedSlot => _assignedSlot;

        private void Awake()
        {
            ClearSlot();            
        }
        
        public void Init(Slot slot)
        {
            _assignedSlot = slot;
            UpdateUISlot(slot);
        }

        public void UpdateUISlot(Slot slot)
        {
            if (slot.ItemData != null)
            {
                _itemSprite.sprite = slot.ItemData.Icon;
                _itemSprite.color = new Color(1, 1, 1, 1);
            }
            else
                ClearSlot();
        }

        public void UpdateUISlot()
        {
            if (_assignedSlot != null) UpdateUISlot(_assignedSlot);
        }            

        private void ClearSlot()
        {
            _assignedSlot?.ClearSlot();
            _itemSprite.sprite = null;
            _itemSprite.color = Color.clear;
        }
    }
}
