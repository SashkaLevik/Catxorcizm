using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Sashka.Infastructure.Tresures
{
    public class InventoryHolder : MonoBehaviour
    {
        [SerializeField] private int _inventorySize;
        [SerializeField] protected Inventory _inventory;

        public Inventory Inventory => _inventory;

        public static UnityAction<Inventory> OnInventoryDisplayRequested;

        private void Awake()
        {
            //_inventory = new Inventory(_inventorySize);
        }
    }
}
