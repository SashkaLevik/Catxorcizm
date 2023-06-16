using Assets.Sashka.Infastructure.Services;
using System;
using System.Collections;
using UnityEngine;

namespace Assets.Sashka.Infastructure
{
    public class BootstrapState : IState
    {
        private const string MyInitial = "MyInitial";
        private const string MenuScene = "MenuScene";

        private readonly GameStateMachine _stateMachine;
        private readonly ScenLoader _scenLoader;
        private readonly AllServices _services;

        public BootstrapState(GameStateMachine stateMachine, ScenLoader scenLoader, AllServices services)//, Loading curtain)
        {
            _stateMachine = stateMachine;
            _scenLoader = scenLoader;
            _services = services;
            RegisterServices();
        }

        public void Enter()
        {
            _scenLoader.Load(MyInitial, onLoaded: LoadMenu);
        }

        private void LoadMenu()
        {
            _stateMachine.Enter<LoadMenuState, string>(MenuScene);
        }



        private void RegisterServices()
        {
            _services.RgisterSingle<IGameStateMachine>(_stateMachine);
        }
        
        public void Exit()
        {
            
        }
    }
}
