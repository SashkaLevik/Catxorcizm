using UnityEngine;

namespace Assets.Sashka.Scripts.Enemyes
{
    public class PortBoss : BaseEnemy
    {
        [SerializeField] private AudioSource _appearSound;

        private void Start()
        {
            _appearSound.Play();
        }
    }
}
