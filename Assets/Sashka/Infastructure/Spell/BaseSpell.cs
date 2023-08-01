using Assets.Sashka.Scripts.Enemyes;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Sashka.Infastructure.Spell
{
    public class BaseSpell : MonoBehaviour
    {
        private const string Explode = "Explode";

        [SerializeField] private int _speed;
        [SerializeField] private int _damage;
        [SerializeField] private AudioSource _fly;
        [SerializeField] private AudioSource _explode;

        private List<BaseEnemy> _enemies;        
        private Animator _animator;

        private void Start()
        {
            _enemies = new List<BaseEnemy>();
            _animator = GetComponent<Animator>();
            _fly.Play();
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
            }

            if (collision.TryGetComponent(out Ground ground))
            {
                _speed = 0;
                _explode.Play();
                _animator.SetTrigger(Explode);

                foreach (var enemy in _enemies)
                {
                    enemy.GetComponentInChildren<EnemyHealth>().TakeDamage(_damage);
                }
            }
        }               

        public void DestroyObject()
            => Destroy(gameObject);
    }
}
