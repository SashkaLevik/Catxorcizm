using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

namespace Assets.Sashka.Infastructure
{
    class LevelScreen : MonoBehaviour
    {
        [SerializeField] private Button _portArea;
        [SerializeField] private Button _marketArea;
        private readonly ScenLoader _scenLoader;

        public LevelScreen(ScenLoader scenLoader)
        {
            _scenLoader = scenLoader;
        }        

        private void OnEnable()
        {
            _portArea.onClick.AddListener(LoadPort);
        }

        private void LoadPort()
        {
            SceneManager.LoadScene("SampleScene");
        }        
    }

    //public enum LevelID
    //{
    //    Market = 0,
    //    Port = 1,
    //}
}
