using System;
using Assets.Sashka.Scripts.Enemyes;
using System.Collections;
using System.Collections.Generic;
using CodeBase.Data;
using CodeBase.Infrastructure.Service.SaveLoad;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Sashka.Infastructure.Spell
{
    public class CastSpell : MonoBehaviour, ISavedProgress
    {
        [SerializeField] private Button _cast;
        [SerializeField] private Transform _castPos;
        [SerializeField] private BaseSpell _spell;
        [SerializeField] private BookAnimator _animator;
        [SerializeField] private AudioSource _bookSound;
        //[SerializeField] private AudioSource _meleeSound;

        public int _spellAmount;

        public void LoadProgress(PlayerProgress progress)
        {
            _spellAmount = progress.HeroState.SpellAmount;
            Debug.Log("load data Hero SpellAmount");
        }

        public void UpdateProgress(PlayerProgress progress){ }

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
                Debug.Log("Spel");
            }            
        }

        private void Spell()
        {
            Debug.Log("Spel");
        }
    }
}