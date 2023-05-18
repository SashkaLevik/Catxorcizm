using CodeBase.AssetManagement;
using CodeBase.Tower;
using UnityEngine;

namespace CodeBase.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        //private GameObject HeroGameObject { get; set; }
    
        private readonly IAssetProvider _assets;
        private IStaticDataService _staticData;

        public GameFactory(IAssetProvider assets)
        {
            _assets = assets;
        }

        public GameObject CreateHero(GameObject at) =>
            _assets.Instantiate(path: AssetPath.HeroPath, at: at.transform.position);

        public void CreateHud() =>
            _assets.Instantiate(AssetPath.HudPath);

        public GameObject CreatTower(TowerTypeID typeId, Transform parent)
        {
            throw new System.NotImplementedException();
        }

        // public GameObject CreatTower(TowerTypeID typeId, Transform parent)
        // {
        //     TowerStaticData towerData = _staticData.ForTower(typeId);
        //     GameObject tower = Object.Instantiate(towerData.Prefab, parent.position, Quaternion.identity, parent);
        //
        //     var attack = tower.GetComponent<TowerAttack>();
        //     attack.Construct(HeroGameObject.transform);
        //     attack.Damage = towerData.Damage;
        //     attack.AttackRange = towerData.AttackRange;
        //     attack.Cooldown = towerData.Cooldown;
        //
        //     return tower;
        // }
    }
}