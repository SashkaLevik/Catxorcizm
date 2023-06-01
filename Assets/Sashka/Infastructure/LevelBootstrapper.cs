using Assets.Sashka.Infastructure.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Sashka.Infastructure
{
    class LevelBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        [SerializeField] private LevelScreen _levelScreen;
        private Game _game;

        private void Awake()
        {
            _game = new Game(this);

            DontDestroyOnLoad(this);
        }

        private void OnEnable()
        {
            _levelScreen.PortLoaded += OnPortAreaLoad;
        }

        private void OnPortAreaLoad()
        {
            _game._stateMachine.Enter<LoadPortState>();
        }
    }
}
