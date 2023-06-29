using UnityEngine;

namespace Assets.Sashka.Scripts.Minions.Dragon
{
    public class ThirdLvlFlame : Missile
    {
        [SerializeField] private AudioSource _flameSound;

        private const string ThirdFlame = "ThirdFlame";
        private Animator _animator;

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _animator.Play(ThirdFlame);
            _flameSound.Play();
        }
    }
}
