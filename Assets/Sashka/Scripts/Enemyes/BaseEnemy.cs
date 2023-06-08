using Assets.Sashka.Scripts.Minions;
using Assets.Sashka.Scripts.StaticData;
using System.Collections;
using CodeBase.Tower;
using UnityEngine;
<<<<<<< HEAD
using UnityEngine.Events;
=======

>>>>>>> remotes/origin/HeroStats
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
        private float _attackRange;
        private float _attackRate;
        private float _currentSpeed;
<<<<<<< HEAD
        private float _cooldown;
=======
        private Coroutine _coroutine;
        private BaseMinion _minion;
>>>>>>> remotes/origin/HeroStats

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

        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.TryGetComponent(out IHealth health))
            {
                _currentSpeed = 0;
                _attackRate -= Time.deltaTime;

                if (_attackRate <= 0)
                {
<<<<<<< HEAD
                    _animator.PlayAttack();
                    _baseMinion.TakeDamage(_damage);
                    _attackRate = _staticData.AttackRate;
=======
                    _attackRate = 4;
                    health.TakeDamage(_damage);
>>>>>>> remotes/origin/HeroStats
                }
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out IHealth health))
            {
                Invoke(nameof(SetDefaultSpeed), 1f);
            }
        }

        private void SetDefaultSpeed() =>
            _currentSpeed = _speed;

<<<<<<< HEAD

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

=======
>>>>>>> remotes/origin/HeroStats
        private void Move() =>
            transform.position += Vector3.left * _currentSpeed * Time.deltaTime;
    }
}
