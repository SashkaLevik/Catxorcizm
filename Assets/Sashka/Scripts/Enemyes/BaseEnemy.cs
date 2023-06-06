using Assets.Sashka.Scripts.Minions;
using Assets.Sashka.Scripts.StaticData;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Sashka.Scripts.Enemyes
{
    public class BaseEnemy : MonoBehaviour
    {
        [SerializeField] private EnemyStaticData _staticData;
        [SerializeField] private Transform _attackPoint;
        [SerializeField] private BaseMinion _baseMinion;
        [SerializeField] private LayerMask _player;
        [SerializeField] private EnemyAnimator _animator;

        private float _speed;
        private int _damage;
        private float _attackRange;
        private float _attackRate;
        private float _currentSpeed;
        private float _cooldown;

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
            _cooldown = _staticData.AttackRate;
        }

        private void Update()
        {
            Move();
        }        

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out _baseMinion))
            {
                _currentSpeed = 0;
                _attackRate -= Time.deltaTime;

                if (_attackRate <= 0)
                {
                    _animator.PlayAttack();
                    _baseMinion.TakeDamage(_damage);
                    _attackRate = _staticData.AttackRate;
                }
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            _baseMinion = null;
            Invoke(nameof(SetDefaultSpeed), 1f);
        }

        private void SetDefaultSpeed() =>
            _currentSpeed = _speed;


        //private IEnumerator Attack()
        //{
        //    while (_baseMinion != null)
        //    {
        //        Collider2D hitPlayer = Physics2D.OverlapCircle(_attackPoint.position, _attackRange, _player);

        //        hitPlayer.GetComponent<BaseMinion>().TakeDamage(_damage);
        //        _animator.PlayAttack();
        //        yield return new WaitForSeconds(_attackRate);
        //        Debug.Log("Attack");
        //    }
        //}

        private void Move() =>
            transform.position += Vector3.left * _currentSpeed * Time.deltaTime;
    }
}
