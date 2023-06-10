using System;

namespace Assets.Sashka.Infastructure
{
    public class LoadMenuState : IPayLoadedState<string>, IState
    {
        private const string MenuScene = "MenuScene";
        private readonly GameStateMachine _gameStateMachine;
        private readonly ScenLoader _scenLoader;

        public LoadMenuState(GameStateMachine gameStateMachine, ScenLoader scenLoader)
        {
            _gameStateMachine = gameStateMachine;
            _scenLoader = scenLoader;
        }

        public void Enter(string sceneName) => 
            _scenLoader.Load(sceneName);        

        private void OnLoaded()
        {
        }

        public void Exit()
        {
            
        }

        public void Enter()
        {
            _scenLoader.Load(MenuScene);
        }
    }
}
