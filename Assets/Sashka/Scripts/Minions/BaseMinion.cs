using Assets.Sashka.Infastructure.Tresures;
using Assets.Sashka.Scripts.Enemyes;
using CodeBase.Infrastructure.StaticData;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Sashka.Scripts.Minions
{
    public class BaseMinion : MonoBehaviour
    {
        protected const string Attack = "Attack";

        [SerializeField] protected BaseEnemy _enemy;
        [SerializeField] protected float _cooldown;
        [SerializeField] protected int _damage;
        [SerializeField] protected float _defence;
        [SerializeField] protected TowerStaticData _towerData;
        [SerializeField] protected InventoryHolder _inventory;
        [SerializeField] private ItemData _itemData;

        private MinionHealth _health;
        protected Animator _animator;
        protected bool _canAttack = true;
        private Sprite _itemIcon;

        public Sprite ItemIcon => _itemIcon;

        public float Defence => _defence;        

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _cooldown = _towerData.Cooldown;
            _damage = _towerData.Damage;
            _defence = _towerData.Defence;
            _health = GetComponent<MinionHealth>();
        }

        public void Init(BaseEnemy enemy)
        {
            _enemy = enemy;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Treasure treasure))
            {
                if (_itemData == null)
                {
                    _itemData = treasure.ItemData;

                    if (treasure.ItemData.ItemType == ItemType.Equipment)
                    {
                        _itemIcon = treasure.ItemData.Icon;
                        _cooldown += treasure.ItemData.Cooldown;
                        _damage += treasure.ItemData.AtkModifier;
                        _health.Defence += treasure.ItemData.DfsModifier;
                        _health.Max += treasure.ItemData.HealthModifier;
                        treasure.TreasureSpawner.RemoveTreasures();
                        Destroy(treasure.gameObject);
                    }
                    else
                        treasure.GetComponentInChildren<DragAndDrop>().SetStartPosition();
                }
                
                if (treasure.ItemData.ItemType == ItemType.Potion)
                {
                    _health.Heal(treasure.ItemData.HealthModifier);
                    treasure.TreasureSpawner.RemoveTreasures();
                    Destroy(treasure.gameObject);
                }
            }
        }        
                
        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out _enemy)) { StartAttack(); }
        }               

        public virtual void StartAttack() { }
    }
}