using UnityEngine;
using UnityEngine.Events;

namespace CodeBase.Player
{
    [RequireComponent(typeof(HeroHealth))]
    public class HeroDeath : MonoBehaviour
    {
        public HeroHealth Health;
        
        public HeroAttack Attack;
        //public HeroAnimator Animator;

        //public GameObject DeathFx;
        private bool _isDead;

        //private void Start()
        //{
        //    Health.HealthChanged += HealthChanged;
        //}

        //private void OnDestroy()
        //{
        //    Health.HealthChanged -= HealthChanged;
        //}

        //private void HealthChanged()
        //{
        //    if (!_isDead && Health.Current <= 0) 
        //        Die();
        //}

        //private void Die()
        //{
        //    _isDead = true;
        //    Happend?.Invoke();
        //    Attack.enabled = false;
        //    Destroy(gameObject);
        //    //Animator.PlayDeath();

        //    //Instantiate(DeathFx, transform.position, Quaternion.identity);
        //}
    }
}