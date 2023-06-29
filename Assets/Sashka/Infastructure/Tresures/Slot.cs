using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Sashka.Infastructure.Tresures
{
    [System.Serializable]
    public class Slot 
    {
        [SerializeField] private ItemData _itemData;
        //[SerializeField] private Image _icon;

        private bool _isEmpty = true;

        public ItemData ItemData => _itemData;
        public bool IsEmpty => _isEmpty;

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

        //public void SetIcon(Sprite icon)
        //{
        //    _icon.color = new Color(1, 1, 1, 1);
        //    _icon.GetComponent<Image>().sprite = icon;
        //}
    }
}
