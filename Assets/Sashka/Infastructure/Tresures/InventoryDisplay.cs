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
        protected Inventory _inventory;
        protected Dictionary<SlotView, Slot> _slotDictionary;

        public Inventory Inventory => _inventory;
        public Dictionary<SlotView, Slot> SlotDictionary => _slotDictionary;

        protected virtual void Start()
        {

        }

        public abstract void AssignSlot(Inventory inventoryToDisplay);

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
    }
}
