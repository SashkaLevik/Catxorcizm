using Assets.Sashka.Scripts.Enemyes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sashka.Infastructure.UI
{
    public class GameScreen : MonoBehaviour
    {
        [SerializeField] private Button _nextWave;
        [SerializeField] private Button _levelComplete;
        [SerializeField] private SpawnerController _spawner;

        public event UnityAction WaveStarted;
        public event UnityAction MenuLoaded;

        private void Start()
        {
            _nextWave.gameObject.SetActive(false);
            _levelComplete.gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            _nextWave.onClick.AddListener(_spawner.NextWave);
            _nextWave.onClick.AddListener(HideButton);
            _spawner.WaveCompleted += ShowButton;
            _spawner.LevelCompleted += CompleteLevel;
            _levelComplete.onClick.AddListener(LoadMenu);
        }

        private void OnDisable()
        {
            _nextWave.onClick.RemoveListener(_spawner.NextWave);
            _nextWave.onClick.RemoveListener(HideButton);
            _spawner.LevelCompleted -= CompleteLevel;
        }

        public void ShowButton()
            => _nextWave.gameObject.SetActive(true);

        public void HideButton()
        {
            WaveStarted?.Invoke();
            _nextWave.gameObject.SetActive(false);
        }

        private void CompleteLevel()
        {
            HideButton();
            _levelComplete.gameObject.SetActive(true);
            _spawner.WaveCompleted -= ShowButton;
        }

        private void LoadMenu()
            => MenuLoaded?.Invoke();        
    }
}
