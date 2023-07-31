using System;
using Assets.Sashka.Scripts.Enemyes;
using System.Collections;
using System.Collections.Generic;
using CodeBase.Data;
using CodeBase.Infrastructure.Service.SaveLoad;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace Assets.Sashka.Infastructure.Spell
{
    public class CastSpell : MonoBehaviour, ISavedProgressReader
    {
        [SerializeField] private Button _cast;
        [SerializeField] private Transform _castPos;
        [SerializeField] private BaseSpell _spell;
        [SerializeField] private BookAnimator _animator;
        [SerializeField] private AudioSource _bookSound;

        private int _spellAmount;

        public int SpellAmount => _spellAmount;

        public event UnityAction<int> SpellUsed;

        public void LoadProgress(PlayerProgress progress)
        {
            _spellAmount = progress.HeroState.SpellAmount;
            Debug.Log("load data Hero SpellAmount");
        }

        private void OnEnable() => 
            _cast.onClick.AddListener(Cast);

        private void OnDisable() => 
            _cast.onClick.RemoveListener(Cast);

        private void Cast()
        {
            if (_spellAmount != 0)
            {
                _bookSound.Play();
                _animator.CastSpell();
                Instantiate(_spell, _castPos.position, Quaternion.identity);
                _spellAmount--;
                SpellUsed?.Invoke(_spellAmount);
            }            
        }        
    }
}