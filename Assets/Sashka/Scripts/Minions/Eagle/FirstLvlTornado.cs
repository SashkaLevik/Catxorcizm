using Assets.Sashka.Scripts.Enemyes;
using UnityEngine;

namespace Assets.Sashka.Scripts.Minions.Eagle
{
    public class FirstLvlTornado : Missile
    {
        [SerializeField] private AudioSource _tornadoSound;

        private float _speedReduce = 0.1f;
        private const string FirstTornado = "FirstTornado";
        private Animator _animator;

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _animator.Play(FirstTornado);
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
