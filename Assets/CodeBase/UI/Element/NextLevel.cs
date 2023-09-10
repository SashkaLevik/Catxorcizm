﻿using System;
using CodeBase.Infrastructure.Service;
using CodeBase.Infrastructure.Service.SaveLoad;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.Element
{
    public class NextLevel : MonoBehaviour
    {
        [SerializeField] private Button _upgrade;
        
        private ISaveLoadService _saveLoadService;

        private void Awake()
            => _saveLoadService = AllServices.Container.Single<ISaveLoadService>();

        private void OnEnable()
            => _upgrade.onClick.AddListener(Next);

        private void OnDisable()
            => _upgrade.onClick.RemoveListener(Next);

        private void Next()
            => _saveLoadService.SaveProgress();
    }
}