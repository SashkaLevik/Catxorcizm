using System;
using System.Collections.Generic;
using UnityEngine;

public class BuildTower : MonoBehaviour
{
    [SerializeField] private List<AssetItem> _items;
    [SerializeField] private List<InventoryCells> _inventoryCellsPrefabs;

    private List<InventoryCells> _inventoryCellsList = new List<InventoryCells>();


    private void Start()
    {
        Render();
    }

    private void Render()
    {
        for (int i = 0; i < _items.Count; i++)
        {
            _inventoryCellsList.Add(_inventoryCellsPrefabs[i]);
            _inventoryCellsPrefabs[i].Initialize(_items[i]);
        }
    }
}