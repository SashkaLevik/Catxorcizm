using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Sashka.Infastructure.Tresures
{
    public class ScriptableItem : ScriptableObject
    {
        [SerializeField] protected ItemType _itemType;
        [SerializeField] protected string _name;
        [SerializeField] protected Sprite _icon;
    }

    public enum ItemType { Shield, Wand}
}
