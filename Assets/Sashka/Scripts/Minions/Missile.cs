using Assets.Sashka.Scripts.Enemyes;
using CodeBase.Infrastructure.StaticData;
using UnityEngine;

namespace Assets.Sashka.Scripts.Minions
{
    public class Missile : MonoBehaviour
    {
        [SerializeField] protected float _speed;
        [SerializeField] protected int _damage;
        [SerializeField] private BaseEnemy _target;
        [SerializeField] private TowerStaticData _towerData;

        private void Awake()
        {
            _speed = _towerData.MissileSpeed;
            _damage = _towerData.Damage;
        }

        private void Update()
        {
            if (_target != null)
            {
                transform.position = Vector2.MoveTowards(transform.position, _target.transform.position, _speed * Time.deltaTime);
            }
            else
                Destroy(gameObject);
        }

        public void Init(BaseEnemy target)
            => _target = target;


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out BaseEnemy enemy))
            {
                Debug.Log("Hit");
                enemy.GetComponentInChildren<EnemyHealth>().TakeDamage(_damage);
                Destroy(gameObject);
            }
        }
    }
}
