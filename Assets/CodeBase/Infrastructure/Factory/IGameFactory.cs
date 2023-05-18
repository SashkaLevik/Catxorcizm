﻿using CodeBase.Tower;
using UnityEngine;

namespace CodeBase.Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
        GameObject CreateHero(GameObject at);
        void CreateHud();
        GameObject CreatTower(TowerTypeID typeId, Transform parent);
    }
}