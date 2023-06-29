using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Service.StaticData;
using CodeBase.UI.Forms;
using UnityEngine;

namespace CodeBase.UI.Service.Factory
{
    public class UIFactory : IUIFactory
    {
        private const string UIRootPath = "UI/UIRoot";
        private readonly IAssetProvider _assets;
        private readonly IStaticDataService _staticData;
        private Transform _uiRoot;
        private ShopWindow _shop;
        private UpgradeMinions _upgrade;

        public UIFactory(IAssetProvider assets, IStaticDataService staticData)
        {
            _assets = assets;
            _staticData = staticData;
        }

        public ShopWindow Shop => _shop;
        public UpgradeMinions Upgrade => _upgrade;

        public GameObject CreateUIRoot()
        {
            _uiRoot = _assets.Instantiate(UIRootPath).transform;
            _shop = GetShop();
            _upgrade = GetUpgrade();

            return _uiRoot.gameObject;
        }

        private ShopWindow GetShop()
        {
            ShopWindow shop = _uiRoot.gameObject.GetComponentInChildren<ShopWindow>();
            shop.gameObject.SetActive(false);
            return shop;
        }
        
        private UpgradeMinions GetUpgrade()
        {
            UpgradeMinions upgrade = _uiRoot.gameObject.GetComponentInChildren<UpgradeMinions>();
            upgrade.gameObject.SetActive(false);
            return upgrade;
        }
    }
}