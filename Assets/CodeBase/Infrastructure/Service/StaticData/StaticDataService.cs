using System.Collections.Generic;
using System.Linq;
using CodeBase.Infrastructure.StaticData;
using CodeBase.Tower;
using UnityEngine;

namespace CodeBase.Infrastructure.Service.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private Dictionary<TowerTypeID, TowerStaticData> _tower;

        public void LoadTower()
        {
            _tower = Resources.LoadAll<TowerStaticData>("StaticData/Tower")
                .ToDictionary(x => x.TowerTypeID, x => x);
        }

        public TowerStaticData ForTower(TowerTypeID typeID) =>
            _tower.TryGetValue(typeID, out TowerStaticData staticData) 
                ? staticData 
                : null;
    }
}