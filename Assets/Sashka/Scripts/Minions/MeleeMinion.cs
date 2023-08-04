using Assets.Sashka.Scripts.Enemyes;
using System.Collections;
using UnityEngine;

namespace Assets.Sashka.Scripts.Minions
{
    public class MeleeMinion : BaseMinion
    {
        [SerializeField] private AudioSource _attackSound;

        public override void StartAttack()
            => StartCoroutine(AttackEnemy(_enemy));        

        private IEnumerator AttackEnemy(BaseEnemy enemy)
        {
            if (_canAttack)
            {
                _canAttack = false;
                _animator.SetTrigger(Attack);
                _attackSound.Play();
                enemy.GetComponentInChildren<EnemyHealth>().TakeDamage(_damage);
                yield return new WaitForSeconds(_cooldown);
                _canAttack = true;
            }            
        }
    }
}
