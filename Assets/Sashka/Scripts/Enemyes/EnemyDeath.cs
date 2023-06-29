//using System;
using Assets.Sashka.Infastructure.Audio;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Sashka.Scripts.Enemyes
{
    class EnemyDeath : MonoBehaviour
    {
        //[SerializeField] private AudioSource[] _dieSounds;
        [SerializeField] private EnemyDieSound _audioController;
        [SerializeField] private EnemyHealth _health;
        [SerializeField] private EnemyAnimator _animator;

        public GameObject DeathFx;

        private void Start()
        {
            _health.HealthChanged += OnHealthChanged;
        }

        private void OnDestroy()
        {
            _health.HealthChanged -= OnHealthChanged;
        }

        private void OnHealthChanged()
        {
            if (_health.Current <= 0)
                Die();
        }

        private void Die()
        {
            AudioSource dieSound;
            _health.HealthChanged -= OnHealthChanged;
            _animator.PlayDeath();
            dieSound = _audioController.GetRandomSound();
            dieSound.Play();
            GameObject fx = Instantiate(DeathFx, transform.position, Quaternion.identity);
            StartCoroutine(DestroyTimer());
        }

        private IEnumerator DestroyTimer()
        {
            yield return new WaitForSeconds(0.8f);
            Destroy(gameObject);
        }

        //private AudioSource GetRandomSound()
        //{
        //    int randomSound = Random.Range(0, _dieSounds.Length);
        //    return _dieSounds[randomSound];
        //}
    }
}
