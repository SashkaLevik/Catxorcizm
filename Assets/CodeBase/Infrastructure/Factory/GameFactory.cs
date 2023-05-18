using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Service.StaticData;
using CodeBase.Infrastructure.StaticData;
using CodeBase.Tower;
using CodeBase.UI.Element;
using CodeBase.UI.Service.Windows;
using UnityEngine;

namespace CodeBase.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private GameObject _heroGameObject;
        private readonly IAssetProvider _assets;
        private readonly IStaticDataService _staticData;
        private readonly IWindowService _windowService;

        public GameFactory(IAssetProvider assets, IStaticDataService staticData, IWindowService windowService)
        {
            _assets = assets;
            _staticData = staticData;
            _windowService = windowService;
        }

        public GameObject CreateHero(GameObject at) => 
            _assets.Instantiate(path: AssetPath.HeroPath, at: at.transform.position);

        public GameObject CreateHud()
        {
            GameObject hud = _assets.Instantiate(AssetPath.HudPath);

            foreach (OpenWindowButton windowButton in hud.GetComponentsInChildren<OpenWindowButton>())
                windowButton.Construct(_windowService);

            return hud;
        }

        public GameObject CreatTower(TowerTypeID typeId, Transform parent)
        {
            TowerStaticData towerData = _staticData.ForTower(typeId);
            GameObject tower = Object.Instantiate(towerData.Prefab, parent.position, Quaternion.identity, parent);
        
            var attack = tower.GetComponent<TowerAttack>();
            attack.Construct(_heroGameObject.transform);
            attack.Damage = towerData.Damage;
            attack.AttackRange = towerData.AttackRange;
            attack.Cooldown = towerData.Cooldown;
        
            return tower;
        }
    }
}