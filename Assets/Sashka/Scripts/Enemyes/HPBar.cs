using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Sashka.Scripts.Enemyes
{
    public class HPBar : MonoBehaviour
    {
        [SerializeField] private Image _hpImage;

        public void SetValue(float current, float max)
            => _hpImage.fillAmount = current / max;
    }
}