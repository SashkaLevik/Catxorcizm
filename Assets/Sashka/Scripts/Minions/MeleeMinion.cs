using System.Collections;
using UnityEngine;

namespace Assets.Sashka.Scripts.Minions
{
    public class MeleeMinion : BaseMinion
    {
        [SerializeField] private AudioSource _attackSound;

        public override void StartAttack()
            => StartCoroutine(ResetAttack());        

        private IEnumerator ResetAttack()
        {
            if (_canAttack)
            {
                _animator.SetTrigger(Attack);
                _attackSound.Play();
                _canAttack = false;
                yield return new WaitForSeconds(_cooldown);
                _canAttack = true;
            }            
        }
    }
}
