using Assets.Sashka.Scripts.Enemyes;
using System.Collections;
using UnityEngine;

namespace Assets.Sashka.Scripts.Minions
{
    public class MeleeMinion : BaseMinion
    {
        private const string SoundVolume = "SoundVolume";

        [SerializeField] private AudioSource _attackSound;

        private void Update()
        {
            if (!PlayerPrefs.HasKey(SoundVolume))
            {
                _attackSound.volume = 1;
            }
            else
                _attackSound.volume = PlayerPrefs.GetFloat(SoundVolume);
        }

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
