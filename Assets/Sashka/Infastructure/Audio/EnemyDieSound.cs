using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Sashka.Infastructure.Audio
{
    class EnemyDieSound : MonoBehaviour
    {
        public AudioSource[] _dieSounds;

        public AudioSource GetRandomSound()
        {
            int randomSound = Random.Range(0, _dieSounds.Length);
            return _dieSounds[randomSound];
        }
    }
}
