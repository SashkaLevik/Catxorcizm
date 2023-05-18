using CodeBase.Infrastructure.AssetManagement;
using UnityEditor;
using UnityEngine;

namespace CodeBase.UI.Service.Factory
{
    public class UIFactory : IUIFactory
    {
        private const string UIRootPath = "UI/UIRoot";
        private readonly IAssetProvider _assets;
        private Transform _uiRoot;

        public UIFactory(IAssetProvider assets)
        {
            _assets = assets;
        }
        
        public void CreateShop()
        {
            
        }
        
        public void CreateUIRoot() => 
            _uiRoot = _assets.Instantiate(UIRootPath).transform;
    }
}