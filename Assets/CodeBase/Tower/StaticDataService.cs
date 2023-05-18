using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CodeBase.Tower
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