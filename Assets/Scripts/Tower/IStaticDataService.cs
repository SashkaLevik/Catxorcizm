public interface IStaticDataService
{
    void LoadTower();
    TowerStaticData ForTower(TowerTypeID typeID);
}