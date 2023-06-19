using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Sashka.Scripts.Minions.Dragon
{
    public class Dragon : BaseMinion
    {
        private const string Attack = "Attack";

        [SerializeField] private DragonFlame _flame;

        private Animator _animator;
        private bool _canAttack = true;


        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out _enemy)) { StartAttack(); }
        }
        
        public void StartAttack()
            => StartCoroutine(Shoot());

        private IEnumerator Shoot()
        {
            if (_canAttack)
            {
                _canAttack = false;
                var delay = new WaitForSeconds(4f);
                _animator.SetTrigger(Attack);
                Invoke(nameof(SetFlame), 0.3f);
                yield return delay;
                _canAttack = true;
            }
        }

        private void SetFlame()
        {
            DragonFlame flame = Instantiate(_flame, _firePos.position, Quaternion.identity);
            flame.Init(_enemy);
        }
    }
}
