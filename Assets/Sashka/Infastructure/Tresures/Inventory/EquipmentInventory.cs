using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Sashka.Infastructure.Tresures
{
    [System.Serializable]
    public class EquipmentInventory
    {
        [SerializeField] private List<Slot> _slots = new List<Slot>();

        public List<Slot> Slots => _slots;
        public int InventorySize => Slots.Count;

        public UnityAction<Slot> OnSlotChanged;

        public bool AddItem(ItemData item)
        {
            if (HasFreeSlot(out Slot freeSlot))
            {
                freeSlot.UpdateSlot(item);
                OnSlotChanged?.Invoke(freeSlot);
                Debug.Log("ItemAdded");
                return true;
            }
            return false;
        }

        public bool ContainItem(ItemData item, out Slot slot)
        {
            slot = null;
            return false;
        }

        public bool HasFreeSlot(out Slot freeSlot)
        {
            freeSlot = Slots.FirstOrDefault(slot => slot.ItemData == null);
            return freeSlot == null ? false : true;
        }                
    }
}
