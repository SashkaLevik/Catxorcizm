using UnityEngine;

namespace Assets.Sashka.Scripts.Minions.Mouse
{
    public class ThirdLvlArrow : Missile
    {
        [SerializeField] private AudioSource _arrowSound;

        private const string ThirdArrow = "ThirdArrow";
        private Animator _animator;

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _animator.Play(ThirdArrow);
            _arrowSound.Play();
        }
    }
}
