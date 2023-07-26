using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Sashka.Infastructure.Tresures
{
    public abstract class InventoryDisplay : MonoBehaviour
    {
        [SerializeField] private SlotView _slotPrefab;

        protected EquipmentInventory _inventory;
        protected Dictionary<SlotView, Slot> _slotDictionary;

        public EquipmentInventory Inventory => _inventory;
        public Dictionary<SlotView, Slot> SlotDictionary => _slotDictionary;        

        public void RefreshInventory(EquipmentInventory inventoryToDisplay)
        {
            //ClearSlots();
            _inventory = inventoryToDisplay;
            AssignSlot(inventoryToDisplay);
        }

        public void AssignSlot(EquipmentInventory inventoryToDisplay)
        {
            _slotDictionary = new Dictionary<SlotView, Slot>();

            //if (inventoryToDisplay == null) return;

            for (int i = 0; i < inventoryToDisplay.InventorySize; i++)
            {
                var uiSlot = Instantiate(_slotPrefab, transform);
                _slotDictionary.Add(uiSlot, inventoryToDisplay.Slots[i]);
                uiSlot.Init(inventoryToDisplay.Slots[i]);
                uiSlot.UpdateUISlot();
            }
        }

        protected virtual void UpdateSlot(Slot updatedSlot)
        {
            foreach (var slot in SlotDictionary)
            {
                if (slot.Value == updatedSlot)
                {
                    slot.Key.UpdateUISlot(updatedSlot);
                }
            }
        }

        private void ClearSlots()
        {
            foreach (var item in transform.Cast<Transform>())
            {
                Destroy(item.gameObject);
            }

            if (_slotDictionary != null) _slotDictionary.Clear();
        }
    }
}
