using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sashka.Infastructure
{
    public class MenuScreen : MonoBehaviour
    {
        [SerializeField] private GameObject _menuScreen;
        [SerializeField] private Button _startButton;

        public event UnityAction ButtonPressed;

        private void OnEnable()
        {
            _startButton.onClick.AddListener(OnStartButton);
        }

        private void OnStartButton()
        {
            _menuScreen.SetActive(false);
            ButtonPressed?.Invoke();
        }
    }
}
