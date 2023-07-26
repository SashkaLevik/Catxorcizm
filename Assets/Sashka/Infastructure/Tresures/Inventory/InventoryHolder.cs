
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Sashka.Infastructure.Tresures
{
    public class InventoryHolder : MonoBehaviour
    {
        [SerializeField] protected EquipmentInventory _inventory;

        public EquipmentInventory Inventory => _inventory;

        public static UnityAction<EquipmentInventory> OnInventoryDisplayRequested;

        private void Awake()
        {
            //_inventory = new Inventory(_inventorySize);
        }
    }
}
