using Assets.Sashka.Scripts.Enemyes;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Sashka.Scripts.Minions
{
    public class BaseMinion : MonoBehaviour
    {
        [SerializeField] private Transform _firePos;
        [SerializeField] private DragonFlame _flame;
        [SerializeField] private BaseEnemy _enemy;
        [SerializeField] private float _speed;
        [SerializeField] private int _fireDelay;
        [SerializeField] private List<BaseEnemy> _enemies;

        public BaseEnemy Enemy => _enemy;

        private void Update()
        {
            Move();
        }

        public void Init(BaseEnemy enemy)
        {
            _enemy = enemy;
        }

        public BaseEnemy GetRandomEnemy()
        {
            int randomEnemy = Random.Range(0, _enemies.Count);
            _enemy = _enemies[randomEnemy];
            return _enemy;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out _enemy))
            {
                //_enemies.Add(_enemy);
                //Attack();
            }
        }

        private void Attack()
        {
            StartCoroutine(Shoot());
        }

        private IEnumerator Shoot()
        {
            while (_enemy != null)
            {
                var delay = new WaitForSeconds(2f);
                DragonFlame flame = Instantiate(_flame, _firePos.position, Quaternion.identity);
                flame.Init(Enemy);
                yield return delay;
            }
        }

        private void Move()
        {
            transform.position += Vector3.right * _speed * Time.deltaTime;
        }
    }
}