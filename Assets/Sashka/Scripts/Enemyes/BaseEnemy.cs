using Assets.Sashka.Scripts.Minions;
using Assets.Sashka.Scripts.StaticData;
using System.Collections;
using System.Collections.Generic;
using CodeBase.Player;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Sashka.Scripts.Enemyes
{
    public class BaseEnemy : MonoBehaviour
    {
        [SerializeField] private EnemyStaticData _staticData;
        [SerializeField] private Transform _attackPoint;
        [SerializeField] private BaseMinion _baseMinion;
        [SerializeField] private HeroHealth _heroHealth;
        [SerializeField] private LayerMask _player;

        private float _speed;
        private int _damage;
        private float _attackRange;
        private float _attackRate;
        private float _currentSpeed;

        private void Start()
        {
            _currentSpeed = _speed;
        }

        private void OnEnable()
        {
            _speed = _staticData.Speed;
            _damage = _staticData.Damage;
            _attackRange = _staticData.AttackRange;
            _attackRate = _staticData.AttackRate;
        }

        private void Update()
        {
            Move();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out _baseMinion))
            {
                _currentSpeed = 0;

                StartCoroutine(Attack());
            }
            else if (collision.TryGetComponent(out _heroHealth))
            {
                _currentSpeed = 0;

                StartCoroutine(AttackPlayer());
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            _baseMinion = null;
            Invoke(nameof(SetDefaultSpeed), 1f);
            StopCoroutine(Attack());
            
            _heroHealth = null;
            Invoke(nameof(SetDefaultSpeed), 1f);
            StopCoroutine(AttackPlayer());
            
        }

        private void SetDefaultSpeed() =>
            _currentSpeed = _speed;

        private IEnumerator Attack()
        {
            while (_baseMinion != null)
            {
                Collider2D hitMinion = Physics2D.OverlapCircle(_attackPoint.position, _attackRange, _player);
                hitMinion.GetComponent<BaseMinion>().TakeDamage(_damage);
                
                Debug.Log("Attack");
                yield return new WaitForSeconds(_attackRate);
            }
        }
        
        private IEnumerator AttackPlayer()
        {
            while (_heroHealth != null)
            {
                Collider2D hitPlayer = Physics2D.OverlapCircle(_attackPoint.position, _attackRange, _player);
                hitPlayer.GetComponent<HeroHealth>().TakeDamage(_damage);
                
                Debug.Log("AttackHero");
                yield return new WaitForSeconds(_attackRate);
            }
        }
        
        // private IEnumerator Attack<T>()
        // {
        //     while (_baseMinion != null)
        //     {
        //         Collider2D hitPlayer = Physics2D.OverlapCircle(_attackPoint.position, _attackRange, _player);
        //         hitPlayer.GetComponent<T>().TakeDamage(_damage);
        //
        //         Debug.Log("Attack");
        //         yield return new WaitForSeconds(_attackRate);
        //     }
        // }

        private void Move() =>
            transform.position += Vector3.left * _currentSpeed * Time.deltaTime;
    }
}