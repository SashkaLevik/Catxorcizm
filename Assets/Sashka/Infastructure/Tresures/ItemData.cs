using TMPro;
using UnityEngine;

namespace Assets.Sashka.Infastructure.Tresures
{
    public enum ItemType { Potion, Equipment}

    [CreateAssetMenu(menuName = "Inventory/Item")]
    public class ItemData : ScriptableObject
    {
        public string Description;
        public Sprite Icon;
        public ItemType ItemType;

        public virtual void Use() { }
    }
}
