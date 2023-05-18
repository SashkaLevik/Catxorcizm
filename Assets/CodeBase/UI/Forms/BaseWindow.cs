﻿using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.Forms
{
    public abstract class BaseWindow : MonoBehaviour
    {
        public Button CloseButton;

        private void Awake()
        {
            OnAwake();
        }

        protected virtual void OnAwake()
        {
            CloseButton.onClick.AddListener(() => Destroy(gameObject));
        }
    }
}