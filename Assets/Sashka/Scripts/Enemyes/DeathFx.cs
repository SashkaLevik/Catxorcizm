using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Sashka.Scripts.Enemyes
{
    public class DeathFx : MonoBehaviour
    {
        private const string DieFx = "DieFx";        

        private Animator _animator;                

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }        

        public void PlayDeath()
        {
            _animator.Play(DieFx);
        }
        
        public void DestroyFx()
        {
            Debug.Log("Die");
            Destroy(gameObject);
        }
    }
}

