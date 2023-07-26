using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Sashka.Infastructure.Tresures.Inventory
{
    public class InventoryController : MonoBehaviour
    {
        //[SerializeField] private InventoryDisplay _inventoryPanel;

        private void OnEnable()
        {
            InventoryHolder.OnInventoryDisplayRequested += DisplayInventory;
        }

        private void OnDisable()
        {
            InventoryHolder.OnInventoryDisplayRequested -= DisplayInventory;
        }

        private void DisplayInventory(EquipmentInventory inventoryToDisplay)
        {
            Debug.Log("Display");
            //_inventoryPanel.gameObject.SetActive(true);
            //_inventoryPanel.RefreshInventory(inventoryToDisplay);
        }
    }
}
