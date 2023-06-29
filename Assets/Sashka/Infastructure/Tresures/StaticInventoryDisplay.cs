using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace Assets.Sashka.Infastructure.Tresures
{   
    public class StaticInventoryDisplay : InventoryDisplay
    {
        [SerializeField] private InventoryHolder _inventoryHolder;
        [SerializeField] private SlotView[] _slots;

        protected override void Start()
        {
            base.Start();

            if (_inventoryHolder != null)
            {
                _inventory = _inventoryHolder.Inventory;
                _inventory.OnSlotChanged += UpdateSlot;
            }

            AssignSlot(_inventory);
        }
        public override void AssignSlot(Inventory inventoryToDisplay)
        {
            _slotDictionary = new Dictionary<SlotView, Slot>();

            for (int i = 0; i < _inventory.InventorySize; i++)
            {
                _slotDictionary.Add(_slots[i], _inventory.Slots[i]);
                _slots[i].Init(_inventory.Slots[i]);
            }
        }
    }
}
