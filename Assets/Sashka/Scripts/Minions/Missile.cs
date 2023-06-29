using Assets.Sashka.Scripts.Enemyes;
using UnityEngine;

namespace Assets.Sashka.Scripts.Minions
{
    public class Missile : MonoBehaviour
    {
        [SerializeField] protected int _speed;
        [SerializeField] protected int _damage;
        [SerializeField] private BaseEnemy _target;

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
