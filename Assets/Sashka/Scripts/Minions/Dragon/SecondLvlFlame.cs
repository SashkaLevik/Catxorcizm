using UnityEngine;

namespace Assets.Sashka.Scripts.Minions.Dragon
{
    public class SecondLvlFlame : DragonFlame
    {
        [SerializeField] private AudioSource _flameSound;

        private const string SecondFlame = "SecondFlame";
        private Animator _animator;

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _animator.Play(SecondFlame);
            _flameSound.Play();
        }
    }
}
