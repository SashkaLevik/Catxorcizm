﻿using UnityEngine;
using UnityEngine.UI;

namespace Assets.CodeBase.Infrastructure.UI
{
    public class DoorIcon : MonoBehaviour
    {
        [SerializeField] private Image _doorIcon;

        public void Show()
            => Invoke(nameof(AlfaOn), 0.2f);

        public void Hide()
            => Invoke(nameof(AlfaOff), 0.1f);

        private void AlfaOn()
            => _doorIcon.color = new Color(255, 255, 255, 255);
        private void AlfaOff()
            => _doorIcon.color = new Color(255, 255, 255, 0);
    }
}
