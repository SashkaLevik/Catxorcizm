using System;

namespace Assets.Sashka.Infastructure
{
    public class LoadMenuState : IPayLoadedState<string>
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly ScenLoader _scenLoader;

        public LoadMenuState(GameStateMachine gameStateMachine, ScenLoader scenLoader)
        {
            _gameStateMachine = gameStateMachine;
            _scenLoader = scenLoader;
        }

        public void Eneter(string sceneName) => 
            _scenLoader.Load(sceneName);

        public void Exit()
        {
            
        }
    }
}
