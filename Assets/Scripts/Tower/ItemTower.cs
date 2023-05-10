using UnityEngine;

public interface ITemTower
{
    string Name { get; }

    Sprite UIIcon { get; }
    
    int Price { get; }

    GameObject UIItem { get; }
}