using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Sashka.Infastructure
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        public Loading Curtain;
        private Game _game;

        private void Awake()
        {
            _game = new Game(this, Instantiate(Curtain));            
            _game._stateMachine.Enter<BootstrapState>();

            DontDestroyOnLoad(this);
        }        
    }
}