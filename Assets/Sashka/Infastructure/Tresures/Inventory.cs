using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace Assets.Sashka.Infastructure.Tresures
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private Transform _inventoryPanel;
        [SerializeField] private List<Slot> _slots = new List<Slot>();

        private void Start()
        {
            
        }

        public void AddItem(Treasure item)
        {
            foreach (Slot slot in _slots)
            {
                if (slot.IsEmpty)
                {
                    slot._item = item;
                    slot.SetIcon(item.Icon);
                }
            }
        }

        
    }
}
