using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Sashka.Infastructure.Audio
{
    class AudioController : MonoBehaviour
    {
        [SerializeField] private AudioSource _mainTheme;
        [SerializeField] private AudioSource _marketThem;
        [SerializeField] private AudioSource _portTheme;
        [SerializeField] private AudioSource _mageTheme;
        [SerializeField] private AudioSource _playerDie;

        public AudioSource MainTheme => _mainTheme;
        public AudioSource MarketTheme => _marketThem;
        public AudioSource PortTheme => _portTheme;
        public AudioSource MageTheme => _mageTheme;
        public AudioSource PlayerDie => _playerDie;
    }
}
