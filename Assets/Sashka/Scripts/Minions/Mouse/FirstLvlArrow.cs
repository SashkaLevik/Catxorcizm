using UnityEngine;

namespace Assets.Sashka.Scripts.Minions.Mouse
{
    public class FirstLvlArrow : Missile
    {
        [SerializeField] private AudioSource _arrowSound;

        private void Start()
            => _arrowSound.Play();
    }
}
