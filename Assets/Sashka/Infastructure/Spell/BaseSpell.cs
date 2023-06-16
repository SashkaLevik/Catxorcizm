using Assets.Sashka.Scripts.Enemyes;
using UnityEngine;

namespace Assets.Sashka.Infastructure.Spell
{
    public class BaseSpell : MonoBehaviour
    {
        [SerializeField] private int _speed;
        [SerializeField] private int _damage;
        //[SerializeField] private BaseMinion _baseMinion;

        //private const string Flame = "Flame";

        //private Animator _animator;


        private void Start()
        {
            //_animator = GetComponent<Animator>();
            //_animator.Play(Flame);
        }

        private void Update()
        {
            transform.position += Vector3.down  * _speed * Time.deltaTime;
        }        

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
