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
        private const string Attack = "Attack";

        [SerializeField] private Missile _missile;
        [SerializeField] protected Transform _firePos;
        [SerializeField] protected BaseEnemy _enemy;
        [SerializeField] protected int _fireDelay;
        [SerializeField] protected float _damage;
        //[SerializeField] protected TowerStaticData _towerData;

        private Animator _animator;
        private bool _canAttack = true;

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        public void Init(BaseEnemy enemy)
            => _enemy = enemy;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Treasure treasure))
            {
                treasure.ItemData.Use();
                //var equipment = GetComponentInChildren<Equipment>();
                //_towerData.Cooldown -= equipment.AtkSpdModifier;
            }
        }        
                
        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out BaseEnemy enemy)) { StartAttack(); }
        }
            
        public void StartAttack()
            => StartCoroutine(Shoot());

        private IEnumerator Shoot()
        {
            if (_canAttack)
            {
                _canAttack = false;
                var delay = new WaitForSeconds(4f);
                _animator.SetTrigger(Attack);
                Invoke(nameof(SetFlame), 0.3f);
                yield return delay;
                _canAttack = true;
            }
        }

        private void SetFlame()
        {
            Debug.Log("Missile");
            Missile missile = Instantiate(_missile, _firePos.position, Quaternion.identity);
            missile.Init(_enemy);
        }
    }
}