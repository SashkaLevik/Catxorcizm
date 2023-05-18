﻿using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Service.StaticData;
using CodeBase.Infrastructure.StaticData.Windows;
using CodeBase.UI.Service.Windows;
using UnityEngine;

namespace CodeBase.UI.Service.Factory
{
    public class UIFactory : IUIFactory
    {
        private const string UIRootPath = "UI/UIRoot";
        private readonly IAssetProvider _assets;
        private readonly IStaticDataService _staticData;
        private Transform _uiRoot;

        public UIFactory(IAssetProvider assets, IStaticDataService staticData)
        {
            _assets = assets;
            _staticData = staticData;
        }
        
        public void CreateShop()
        {
            WindowConfig config = _staticData.ForWindow(WindowId.Shop);
            Object.Instantiate(config.Prefab, _uiRoot);
        }
        
        public void CreateUIRoot() => 
            _uiRoot = _assets.Instantiate(UIRootPath).transform;
    }
}