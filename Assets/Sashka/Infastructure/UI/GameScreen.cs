using Assets.Sashka.Scripts.Enemyes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Sashka.Infastructure.UI
{
    public class GameScreen : MonoBehaviour
    {
        [SerializeField] private Button _nextWave;
        [SerializeField] private SpawnerController _spawner;

        private void Start()
        {
           // _nextWave.gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            _nextWave.onClick.AddListener(_spawner.NextWave);
        }

        public void ShowButton()
        {
            Debug.Log("Show");
            _nextWave.gameObject.SetActive(true);            
        }

        public void HideButton()
            => _nextWave.gameObject.SetActive(false);
    }
}
