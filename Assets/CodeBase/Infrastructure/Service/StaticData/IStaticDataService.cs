using CodeBase.Infrastructure.StaticData;
using CodeBase.Infrastructure.StaticData.Windows;
using CodeBase.UI.Service.Windows;

namespace CodeBase.Infrastructure.Service.StaticData
{
    public interface IStaticDataService : IService
    {
        void LoadTower();
        TowerStaticData ForTower(TowerTypeID typeID);
        WindowConfig ForWindow(WindowId windowID);  
    }
}