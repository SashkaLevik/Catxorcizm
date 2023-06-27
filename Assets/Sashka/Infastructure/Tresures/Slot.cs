using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Sashka.Infastructure.Tresures
{
    public class Slot : MonoBehaviour
    {
        [SerializeField] public Treasure _item;
        [SerializeField] private Image _icon;

        private bool _isEmpty = true;

        public Treasure Item => _item;
        public bool IsEmpty => _isEmpty;

        public void SetIcon(Sprite icon)
        {
            _icon.color = new Color(1, 1, 1, 1);
            _icon.GetComponent<Image>().sprite = icon;
        }
    }
}
