using CodeBase.Infrastructure.UI;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Sashka.Infastructure.Audio
{
    public class AudioSources : MonoBehaviour
    {
        public static AudioSources instance;

        [SerializeField] private AudioSource _mainTheme;
        [SerializeField] private AudioSource _portTheme;

        private void Start()
        {
            if (instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }

               

        private void OnPortEntered()
        {
            _mainTheme.Stop();
            _portTheme.Play();
        }
    }
}
