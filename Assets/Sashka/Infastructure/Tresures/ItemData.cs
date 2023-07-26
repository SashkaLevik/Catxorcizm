using CodeBase.Infrastructure.StaticData;
using TMPro;
using UnityEngine;

namespace Assets.Sashka.Infastructure.Tresures
{
    public enum ItemType { Potion, Equipment}

    [CreateAssetMenu(menuName = "Item/NewItem")]
    public class ItemData : ScriptableObject
    {
        public string Description;
        public Sprite Icon;
        public ItemType ItemType;

        public float AtkModifier;
        public float DfsModifier;
        public float Cooldown;
        public float HealthModifier;
        public float Price;

        //public virtual void Use(TowerStaticData data, float damage, float defence, float cooldown, float health) { }
    }
}
