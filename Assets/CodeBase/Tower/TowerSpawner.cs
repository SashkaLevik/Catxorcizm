using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Service;
using CodeBase.Infrastructure.StaticData;
using CodeBase.UI.Forms;
using CodeBase.UI.Service.Factory;
using UnityEngine;

namespace CodeBase.Tower
{
    public class TowerSpawner : MonoBehaviour
    {
        private IGameFactory _factory;
        private IUIFactory _uIFactory;
        private ShopWindow _shopWindow;
        private bool _createTower;

        private string _id;
        public bool CreateTower => _createTower;

        public void Construct(IUIFactory uiFactory)
        {
            _uIFactory = uiFactory;
            _uIFactory.Shop.Opened += ShopOnOpened;
        }

        private void Awake()
        {
            _id = GetComponent<UniqueId>().Id;
            _factory = AllServices.Container.Single<IGameFactory>();
        }

        private void ShopOnOpened(bool open)
        {
        }

        private void OnDisable()
        {
            _uIFactory.Shop.Opened -= ShopOnOpened;
        }

        public void BuyTowerSpawn(TowerStaticData data)
        {
            Spawner(data.TowerTypeID, transform);
            _createTower = true;
        }

        private void Spawner(TowerTypeID towerTypeID, Transform parent)
        {
            GameObject tower = _factory.CreatTower(towerTypeID, parent);
        }
    }
}