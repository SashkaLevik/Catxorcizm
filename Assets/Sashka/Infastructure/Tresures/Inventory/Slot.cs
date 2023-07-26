using UnityEngine;
using UnityEngine.UI;

namespace Assets.Sashka.Infastructure.Tresures
{
    [System.Serializable]
    public class Slot 
    {
        [SerializeField] private ItemData _itemData;        

        public ItemData ItemData => _itemData;

        public Slot(ItemData itemData)
        {
            _itemData = itemData;
        }

        public Slot() => ClearSlot();

        public void ClearSlot() => _itemData = null;

        public void UpdateSlot(ItemData itemData)
        {
            _itemData = itemData;
        }        
    }
}
