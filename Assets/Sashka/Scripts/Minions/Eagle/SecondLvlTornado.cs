﻿using Assets.Sashka.Scripts.Enemyes;
using UnityEngine;

namespace Assets.Sashka.Scripts.Minions.Eagle
{
    public class SecondLvlTornado : Missile
    {
        private const string SoundVolume = "SoundVolume";

        [SerializeField] private AudioSource _tornadoSound;

        private float _speedReduce = 0.2f;
        private const string SecondTornado = "SecondTornado";
        private Animator _animator;

        private void Start()
        {
            if (!PlayerPrefs.HasKey(SoundVolume))
            {
                _tornadoSound.volume = 1;
            }
            else
                _tornadoSound.volume = PlayerPrefs.GetFloat(SoundVolume);

            _animator = GetComponent<Animator>();
            _animator.Play(SecondTornado);
            _tornadoSound.Play();
        }

        public override void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out BaseEnemy enemy))
            {
                enemy.OnTornadoEnter(_speedReduce);
                enemy.GetComponentInChildren<EnemyHealth>().TakeDamage(_damage);
                Destroy(gameObject);
            }
        }
    }
}
