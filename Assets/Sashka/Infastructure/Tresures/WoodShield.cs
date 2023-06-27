using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace Assets.Sashka.Infastructure.Tresures
{
    [CreateAssetMenu(fileName ="Shield", menuName ="Items/New Shield")]
    public class WoodShield : ScriptableItem
    {
        [SerializeField] private int _defence;
    }
}
