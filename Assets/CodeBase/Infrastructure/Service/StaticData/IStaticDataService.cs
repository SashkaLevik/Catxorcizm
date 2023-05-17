using CodeBase.Infrastructure.StaticData;
using CodeBase.Tower;

namespace CodeBase.Infrastructure.Service.StaticData
{
    public interface IStaticDataService : IService
    {
        void LoadTower();
        TowerStaticData ForTower(TowerTypeID typeID);
    }
}