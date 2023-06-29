using UnityEngine;

namespace Assets.Sashka.Scripts.Minions.Mouse
{
    public class SecondLvlArrow : Missile
    {
        [SerializeField] private AudioSource _arrowSound;

        private const string SecondArrow = "SecondArrow";
        private Animator _animator;

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _animator.Play(SecondArrow);
            _arrowSound.Play();
        }
    }
}
