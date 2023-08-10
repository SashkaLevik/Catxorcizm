﻿using CodeBase.Infrastructure.UI;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Sashka.Infastructure.Audio
{
    public class AudioSources : MonoBehaviour
    {
        public static AudioSources instance;

        [SerializeField] private AudioSource _mainTheme;

        private void Start()
        {
            if (instance != null)
            {
                Destroy(gameObject);
            }
            else if(SceneManager.GetActiveScene().name == "Academy")
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
           // _mainTheme.Play();
        }                      
    }
}
