using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Service;
using CodeBase.Infrastructure.StaticData;
using UnityEngine;

namespace CodeBase.Tower
{
    public class TowerSpawner : MonoBehaviour
    {
        private IGameFactory _factory;
        private ShopTower _turretShopTower;
    
        private string _id;
        private bool _createTower;

        public void Construct(ShopTower turretShopTower)
        {
            _turretShopTower = turretShopTower;
            _turretShopTower.Happened += BuyTower;
        }
        
        private void Awake()
        {
            _id = GetComponent<UniqueId>().Id;
            _factory = AllServices.Container.Single<IGameFactory>();
        }

        private void OnDestroy()
        {
            _turretShopTower.Happened -= BuyTower;
        }

        private void BuyTower(TowerStaticData data)
        {
            Spawner(data.TowerTypeID, transform);
            _createTower = true;
        }

        private void Spawner(TowerTypeID towerTypeID, Transform parent)
        {
            GameObject tower = _factory.CreatTower(towerTypeID, parent);
        }

        // private void Create()
        // {
        //     _createTower = true;
        // }
    }
}