using System;
using UnityEngine;
using Object = UnityEngine.Object;

public class TowerSpawner : MonoBehaviour
{
    [SerializeField] private Transform _closeShop;
    [SerializeField] private ShopTower _shop;
    
    public string _id;
    private bool _createTower;

    private void Awake()
    {
        _id = GetComponent<UniqueId>().Id;
    }

    public GameObject CreateTower(TowerStaticData towerData, Transform parent)
    {
        GameObject tower = Object.Instantiate(towerData.Prefab, transform.position, Quaternion.identity, parent);
        _closeShop.gameObject.SetActive(false);
        _createTower = true;
        return tower;
    }
}