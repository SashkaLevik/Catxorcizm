using Assets.Sashka.Scripts.Enemyes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace Assets.Sashka.Scripts.Minions.Eagle
{
    public class ThirdLvlTornado : Missile
    {
        [SerializeField] private AudioSource _tornadoSound;

        private float _speedReduce = 0.3f;
        private const string ThirdTornado = "ThirdTornado";
        private Animator _animator;

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _animator.Play(ThirdTornado);
            _tornadoSound.Play();
        }

        public override void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out BaseEnemy enemy))
            {
                enemy.OnTornadoEnter(_speedReduce);
                enemy.GetComponentInChildren<EnemyHealth>().TakeDamage(_damage);
                Destroy(gameObject);
            }
        }
    }
}
