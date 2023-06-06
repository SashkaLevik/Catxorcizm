using System;
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
        public EnemyHealth Health;
        public EnemyAnimator Animator;

        public GameObject DeathFx;

        private void Start()
        {
            Health.HealthChanged += OnHealthChanged;
        }

        private void OnDestroy()
        {
            Health.HealthChanged -= OnHealthChanged;
        }

        private void OnHealthChanged()
        {
            if (Health.Current <= 0)
                Die();
        }

        private void Die()
        {
            Health.HealthChanged -= OnHealthChanged;
            Animator.PlayDeath();
            GameObject fx = Instantiate(DeathFx, transform.position, Quaternion.identity);
            StartCoroutine(DestroyTimer());
            //Destroy(fx.gameObject);
        }

        private IEnumerator DestroyTimer()
        {
            yield return new WaitForSeconds(0.8f);
            Destroy(gameObject);
        }
    }
}
