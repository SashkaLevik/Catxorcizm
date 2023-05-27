using System.Collections.Generic;
using UnityEngine;

namespace Assets.Sashka.Infastructure
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        private Game _game;

        private void Awake()
        {
            _game = new Game(this);
            _game._stateMachine.Eneter<BootstrapState>();

            DontDestroyOnLoad(this);
        }
    }
}