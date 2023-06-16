using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Sashka.Scripts
{
    public class CustomButton : MonoBehaviour
    {
        [Range(0f, 1f)]
        [SerializeField] private float _alfa;

        private void Start()
        {
            GetComponent<Image>().alphaHitTestMinimumThreshold = _alfa;
        }
    }
}