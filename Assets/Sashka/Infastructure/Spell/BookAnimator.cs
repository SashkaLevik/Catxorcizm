using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace Assets.Sashka.Infastructure.Spell
{
    public class BookAnimator : MonoBehaviour
    {
        private static readonly int BookAttack = Animator.StringToHash("BookAttack");

        private Animator _animator;

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        public void CastSpell()
            => _animator.SetTrigger(BookAttack);
    }
}
