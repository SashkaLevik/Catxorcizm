using Assets.Sashka.Scripts.Enemyes;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Sashka.Infastructure.Spell
{
    public class BaseSpell : MonoBehaviour
    {
        [SerializeField] private int _speed;
        [SerializeField] private int _damage;

        private List<BaseEnemy> _enemies;
        //[SerializeField] private BaseMinion _baseMinion;

        //private const string Flame = "Flame";

        //private Animator _animator;


        private void Start()
        {
            _enemies = new List<BaseEnemy>();
            //_animator = GetComponent<Animator>();
            //_animator.Play(Flame);
        }

        private void Update()
        {
            transform.position += Vector3.down  * _speed * Time.deltaTime;
        }        

        private void OnTriggerEnter2D(Collider2D collision)
        {
            
            if (collision.TryGetComponent(out BaseEnemy baseEnemy))
            {
                _enemies.Add(baseEnemy);
                foreach (var enemy in _enemies)
                {
                    enemy.GetComponentInChildren<EnemyHealth>().TakeDamage(_damage);
                    Invoke(nameof(DestroyObject), 6);
                }

            }
        }

        private void DestroyObject()
        {
            Destroy(gameObject);
        }
    }
}
