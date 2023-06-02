using Assets.Sashka.Scripts.Minions;
using Assets.Sashka.Scripts.StaticData;
using System.Collections;
using CodeBase.Tower;
using UnityEngine;

namespace Assets.Sashka.Scripts.Enemyes
{
    public class BaseEnemy : MonoBehaviour
    {
        [SerializeField] private EnemyStaticData _staticData;
        [SerializeField] private Transform _attackPoint;
        [SerializeField] private LayerMask _player;

        private float _speed;
        private int _damage;
        private float _attackRange;
        private float _attackRate;
        private float _currentSpeed;
        private Coroutine _coroutine;
        private BaseMinion _minion;

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
            if (collision.TryGetComponent(out IHealth health))
            {
                _currentSpeed = 0;
                _attackRate -= Time.deltaTime;

                if (_attackRate <= 0)
                {
                    _attackRate = 4;
                    health.TakeDamage(_damage);
                }
                _coroutine = StartCoroutine(Attack(health));
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out IHealth health))
            {
                Invoke(nameof(SetDefaultSpeed), 1f);
                StopCoroutine(_coroutine);
            }
            
            health = null;
            Invoke(nameof(SetDefaultSpeed), 1f);
        }

        private void SetDefaultSpeed() =>
            _currentSpeed = _speed;

        private IEnumerator Attack(IHealth health)
        {
            while (health != null)
            {
                health.TakeDamage(_damage);
                
                Debug.Log("Attack");
                yield return new WaitForSeconds(_attackRate);
            }
        }

        private void Move() =>
            transform.position += Vector3.left * _currentSpeed * Time.deltaTime;
    }
}
