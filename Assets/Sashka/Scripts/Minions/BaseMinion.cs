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

        [SerializeField] protected Transform _firePos;
        [SerializeField] protected BaseEnemy _enemy;
        [SerializeField] protected float _cooldown;
        [SerializeField] protected float _damage;
        [SerializeField] protected float _defence;
        [SerializeField] protected TowerStaticData _towerData;

        protected Animator _animator;
        protected bool _canAttack = true;

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _cooldown = _towerData.Cooldown;
        }

        public void Init(BaseEnemy enemy)
            => _enemy = enemy;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Treasure treasure))
            {
                treasure.ItemData.Use();
                //var equipment = GetComponentInChildren<Equipment>();
                //_cooldown -= equipment.AtkSpdModifier;
                //_damage += equipment.AtkModifier;
                //_defence += equipment.DfsModifier;
            }
        }        
                
        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out _enemy)) { StartAttack(); }
        }
            
        public virtual void StartAttack() { }        
    }
}