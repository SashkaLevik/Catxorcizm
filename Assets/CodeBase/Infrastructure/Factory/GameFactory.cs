using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Service.StaticData;
using CodeBase.Infrastructure.StaticData;
using CodeBase.Tower;
using UnityEngine;

namespace CodeBase.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private GameObject _heroGameObject;
        private readonly IAssetProvider _assets;
        private readonly IStaticDataService _staticData;

        public GameFactory(IAssetProvider assets, IStaticDataService staticData)
        {
            _assets = assets;
            _staticData = staticData;
        }

        public GameObject CreateHero(GameObject at) => 
            _assets.Instantiate(path: AssetPath.HeroPath, at: at.transform.position);

        public GameObject CreateHud() =>
            _assets.Instantiate(AssetPath.HudPath);

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