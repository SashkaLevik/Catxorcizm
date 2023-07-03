using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Sashka.Infastructure.Tresures
{
    [CreateAssetMenu(menuName = "Item/Equipment")]
    public class Equipment : ItemData
    {
        public int AtkModifier;
        public float DfsModifier;
        public float AtkSpdModifier;

        public override void Use()
        {
            base.Use();
            Debug.Log("EquipItem");
        }
    }
}
