using UnityEngine;

namespace Assets.Sashka.Scripts.Minions.Mouse
{
    public class FirstLvlArrow : Missile
    {
        [SerializeField] private AudioSource _arrowSound;

        private const string FirstArrow = "FirstArrow";
        private Animator _animator;

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _animator.Play(FirstArrow);
            _arrowSound.Play();
        }
    }
}
