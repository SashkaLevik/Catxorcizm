using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace Assets.Sashka.Scripts.Enemyes
{
    class EnemyAnimator : MonoBehaviour
    {
        private static readonly int Attack = Animator.StringToHash("Attack");
        private static readonly int Die = Animator.StringToHash("Die");

        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void PlayAttack()
            => _animator.SetTrigger(Attack);

        public void PlayDeath()
            => _animator.SetTrigger(Die);
    }
}
