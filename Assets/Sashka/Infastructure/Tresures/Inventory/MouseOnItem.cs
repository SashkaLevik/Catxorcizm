using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
namespace Assets.Sashka.Infastructure.Tresures
{
    public class MouseOnItem : MonoBehaviour
    {
        public Image ItemSprite;
        public TMP_Text Description;

        private void Awake()
        {
            ItemSprite.color = Color.clear;
            Description.text = "";
        }
    }
}
