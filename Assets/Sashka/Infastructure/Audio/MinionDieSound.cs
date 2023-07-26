using UnityEngine;

namespace Assets.Sashka.Infastructure.Audio
{
    public class MinionDieSound : MonoBehaviour
    {
        public AudioSource[] _dieSounds;

        public AudioSource GetRandomSound()
        {
            int randomSound = Random.Range(0, _dieSounds.Length);
            return _dieSounds[randomSound];
        }
    }
}
