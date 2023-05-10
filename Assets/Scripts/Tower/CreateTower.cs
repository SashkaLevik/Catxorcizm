using System;
using System.Collections.Generic;
using UnityEngine;

public class CreateTower : MonoBehaviour
{
    [SerializeField] private Transform _spawn;
    [SerializeField] private List<AssetItem> _items;
    [SerializeField] private List<InventoryCells> _inventoryCellsPrefabs;

    private List<InventoryCells> _inventoryCellsList = new List<InventoryCells>();

    private void Start()
    {
        for (int i = 0; i < _items.Count; i++)
        {
            _inventoryCellsList.Add(_inventoryCellsPrefabs[i]);
        }
    }

    private void OnEnable()
    {
        foreach (var view in _inventoryCellsList)
        {
            view.SellButtonClick += Create;
        }
    }

    private void OnDisable()
    {
        foreach (var view in _inventoryCellsList)
        {
            view.SellButtonClick -= Create;
        }
    }

    private void Create(AssetItem assetItem, InventoryCells inventoryCells)
    {
        Instantiate(assetItem.UIItem, _spawn.position, Quaternion.identity);
    }
}