using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Sashka
{
    public class BaseEnemy : MonoBehaviour
    {
        [SerializeField] private EnemyStaticData _staticData;            
        [SerializeField] private Transform _attackPoint;
        [SerializeField] private BaseMinion _baseMinion;
        [SerializeField] private LayerMask _player;

        private float _health;
        private float _speed;
        private int _damage;
        private float _attackRange;
        private float _attackRate;
        private float _currentSpeed;

        public event UnityAction<BaseEnemy> Died;

        private void Start()
        {
            _currentSpeed = _speed;
        }

        private void OnEnable()
        {
            _health = _staticData.Health;
            _speed = _staticData.Speed;
            _damage = _staticData.Damage;
            _attackRange = _staticData.AttackRange;
            _attackRate = _staticData.AttackRate;
        }

        private void Update()
        {
            Move();
        }

        public void TakeDamage(int damage)
        {
            _health -= damage;

            if (_health <= 0)
            {
                //Die();
                Died?.Invoke(this);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<BaseMinion>(out _baseMinion))
            {
                _currentSpeed = 0;

                StartCoroutine(Attack());
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            _baseMinion = null;
            Invoke(nameof(SetDefaultSpeed), 1f);
            StopCoroutine(Attack());
        }

        private void SetDefaultSpeed() =>
            _currentSpeed = _speed;

        private IEnumerator Attack()
        {

            while (_baseMinion != null)
            {
                Collider2D hitPlayer = Physics2D.OverlapCircle(_attackPoint.position, _attackRange, _player);

                hitPlayer.GetComponent<BaseMinion>().TakeDamage(_damage);

                Debug.Log("Attack");
                yield return new WaitForSeconds(_attackRate);
            }
        }

        //private void Die()
        //{
        //    Destroy(gameObject);
        //}

        private void Move()=>
            transform.position += Vector3.left * _currentSpeed * Time.deltaTime;
    }

}
