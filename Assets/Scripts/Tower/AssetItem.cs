using UnityEngine;

[CreateAssetMenu(menuName = "Item")]
public class AssetItem : ScriptableObject, ITemTower
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite _icon;
    [SerializeField] private int _price;
    [SerializeField] private GameObject _tower;
    
    public string Name => _name;
    public Sprite UIIcon => _icon;
    public int Price => _price;
    public GameObject UIItem => _tower;
}