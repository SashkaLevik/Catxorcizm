using Assets.Sashka.Scripts.Minions;
using Assets.Sashka.Scripts.StaticData;
using System.Collections;
using CodeBase.Tower;
using UnityEngine;
using CodeBase.UI.Element;
using CodeBase.Player;
using Assets.Sashka.Scripts.Minions.Eagle;
//using UnityEngine.Events;
namespace Assets.Sashka.Scripts.Enemyes
{
    public class BaseEnemy : MonoBehaviour
    {
        [SerializeField] protected EnemyStaticData _staticData;
        [SerializeField] private Transform _attackPoint;
        [SerializeField] private LayerMask _player;
        [SerializeField] private EnemyAnimator _animator;
        [SerializeField] protected AudioSource _attackSound;

        private IHealth _health;
        protected float _speed;
        private int _damage;
        private int _reward;
        protected float _currentSpeed;
        private float _cooldown;
        private bool _canAttack = true;

        public int Reward => _reward;

        private void Start()
        {
            _currentSpeed = _speed;
        }

        private void OnEnable()
        {
            _speed = _staticData.Speed;
            _damage = _staticData.Damage;
            _reward = _staticData.Reward;
            _cooldown = _staticData.Cooldown;
        }

        private void Update()
            => Move();

        private void OnTriggerStay2D(Collider2D other)
        {            
            if (other.TryGetComponent(out _health) && _canAttack)
            {
                _currentSpeed = 0;
                _attackSound.Play();
                _animator.PlayAttack();
                _health.TakeDamage(_damage);
                StartCoroutine(ResetAttack());
                Debug.Log("EnemyAttack");
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out IHealth health))
            {
                Invoke(nameof(SetDefaultSpeed), 1f);
            }
        }

        protected IEnumerator ResetAttack()
        {
            _canAttack = false;
            yield return new WaitForSeconds(_cooldown);
            _canAttack = true;
        }

        private IEnumerator ReduceSpeed(float modifier)
        {
            _currentSpeed -= modifier;
            yield return new WaitForSeconds(1.2f);
            SetDefaultSpeed();
        }

        private void SetDefaultSpeed() =>
            _currentSpeed = _speed;

        private void Move() =>
            transform.position += Vector3.left * _currentSpeed * Time.deltaTime;        

        public void OnTornadoEnter(float modifier)
            => StartCoroutine(ReduceSpeed(modifier));
    }
}
