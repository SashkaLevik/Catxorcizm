using UnityEngine;

namespace Assets.Sashka.Scripts.Minions.Dragon
{
    public class FirstLevelFlame : Missile
    {
        [SerializeField] private AudioSource _flameSound;

        private const string FirstFlame = "FirstFlame";
        private Animator _animator;

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _animator.Play(FirstFlame);
            _flameSound.Play();
        }
    }
}
