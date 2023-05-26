using CodeBase.Infrastructure.Service;
using CodeBase.Infrastructure.StaticData;
using UnityEngine;

namespace CodeBase.Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
        GameObject CreateHero(GameObject at);
        GameObject CreateHud();
        GameObject CreatTower(TowerTypeID typeId, Transform parent);
    }
}