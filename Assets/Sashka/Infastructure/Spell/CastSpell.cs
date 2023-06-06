using Assets.Sashka.Scripts.Enemyes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Sashka.Infastructure.Spell
{
    public class CastSpell : MonoBehaviour
    {
        [SerializeField] private Button _cast;
        [SerializeField] private Transform _castPos;
        [SerializeField] private BaseSpell _spell;
        [SerializeField] private BaseEnemy _target;
        [SerializeField] private BookAnimator _animator;

        private int _spellAmount = 5;

        private void OnEnable()
        {
            _cast.onClick.AddListener(Cast);
        }

        private void OnDisable()
        {
            _cast.onClick.RemoveListener(Cast);
        }

        private void Cast()
        {
            if (_spellAmount != 0)
            {
                _animator.CastSpell();
                Instantiate(_spell, _castPos.position, Quaternion.identity);
                _spellAmount--;
            }            
        }
    }
}