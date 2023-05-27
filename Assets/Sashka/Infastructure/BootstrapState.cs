using System;

namespace Assets.Sashka.Infastructure
{
    public class BootstrapState : IState
    {
        private const string MyInitial = "MyInitial";
        private readonly GameStateMachine _stateMachine;
        private readonly ScenLoader _scenLoader;

        public BootstrapState(GameStateMachine stateMachine, ScenLoader scenLoader)
        {
            _stateMachine = stateMachine;
            _scenLoader = scenLoader;
        }

        public void Eneter()
        {
            //RegisterServices();
            _scenLoader.Load(MyInitial, onLoaded: LoadMenu);
        }

        private void LoadMenu() => 
            _stateMachine.Eneter<LoadMenuState, string>("SampleScene");

        private void RegisterServices()
        {
            throw new NotImplementedException();
        }

        public void Exit()
        {
            
        }
    }
}
