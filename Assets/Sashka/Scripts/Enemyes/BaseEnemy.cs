using Assets.Sashka.Scripts.Minions;
using Assets.Sashka.Scripts.StaticData;
using System.Collections;
using CodeBase.Tower;
using UnityEngine;
//using UnityEngine.Events;
namespace Assets.Sashka.Scripts.Enemyes
{
    public class BaseEnemy : MonoBehaviour
    {
        [SerializeField] private EnemyStaticData _staticData;
        [SerializeField] private Transform _attackPoint;
        [SerializeField] private LayerMask _player;
        [SerializeField] private EnemyAnimator _animator;

        private float _speed;
        private int _damage;
        public float _attackTime;
        private float _attackRange;
        private float _attackRate;
        private float _currentSpeed;
        private float _cooldown;
        public bool _canAttack = true;

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
            //ResetAttack();
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            
            if (other.TryGetComponent(out IHealth health) && _canAttack)
            {
                _currentSpeed = 0;

                _animator.PlayAttack();
                health.TakeDamage(_damage);
                StartCoroutine(ResetAttack());
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out IHealth health))
            {
                Invoke(nameof(SetDefaultSpeed), 1f);
            }
        }

        private IEnumerator ResetAttack()
        {
            _canAttack = false;
            yield return new WaitForSeconds(_attackRate);
            _canAttack = true;
        }

        private void SetDefaultSpeed() =>
            _currentSpeed = _speed;

        private void Move() =>
            transform.position += Vector3.left * _currentSpeed * Time.deltaTime;
    }
}
