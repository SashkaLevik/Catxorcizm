using CodeBase.Infrastructure.Factory;
using UnityEngine;

namespace CodeBase.Tower
{
    public class TowerSpawner : MonoBehaviour
    {
        [SerializeField] private Transform _closeShop;
        [SerializeField] private ShopTower _shop;

        public TowerTypeID TowerTypeID;
        private IGameFactory _factory;
    
        private string _id;
        private bool _createTower;

        private void Awake()
        {
            _id = GetComponent<UniqueId>().Id;
        }

        public void Spawner()
        {
            GameObject tower = _factory.CreatTower(TowerTypeID, transform);
        }

        private void Create()
        {
            _createTower = true;
        }
    }
}