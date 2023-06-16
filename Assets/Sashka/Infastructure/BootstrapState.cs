using System;
using System.Collections;
using CodeBase.Infrastructure.LevelLogic;
using Sashka.Infastructure;
using UnityEngine;

namespace Assets.Sashka.Infastructure
{
    public class BootstrapState : IState
    {
        private const string MyInitial = "MyInitial";
        private const string MenuScene = "MenuScene";

        private readonly GameStateMachine _stateMachine;
        private readonly ScenLoader _scenLoader;
        private readonly Loading _curtain;

        public BootstrapState(GameStateMachine stateMachine, ScenLoader scenLoader)//, Loading curtain)
        {
            _stateMachine = stateMachine;
            _scenLoader = scenLoader;
        }

        public void Enter()
        {
            //RegisterServices();
            //_curtain.Show();
            _scenLoader.Load(MyInitial, onLoaded: LoadMenu);
        }

        private void LoadMenu()
        {
            //_curtain.Hide();
            //_stateMachine.Enter<LoadMenuState, string>(MenuScene);
        }



        private void RegisterServices()
        {
        }
        
        public void Exit()
        {
            
        }
    }
}
