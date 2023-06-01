using System;

namespace Assets.Sashka.Infastructure
{
    public class BootstrapState : IState
    {
        private const string MyInitial = "MyInitial";
        private const string MenuScene = "MenuScene";

        private readonly GameStateMachine _stateMachine;
        private readonly ScenLoader _scenLoader;

        public BootstrapState(GameStateMachine stateMachine, ScenLoader scenLoader)
        {
            _stateMachine = stateMachine;
            _scenLoader = scenLoader;
        }

        public void Enter()
        {
            //RegisterServices();
            _scenLoader.Load(MyInitial, onLoaded: LoadMenu);
        }

        private void LoadMenu() => 
            _stateMachine.Enter<LoadMenuState, string>(MenuScene);

        private void RegisterServices()
        {
        }

        public void Exit()
        {
            
        }
    }
}
