using CodeBase.Infrastructure.State;
using GameLoopState = CodeBase.Infrastructure.State.GameLoopState;
using GameStateMachine = CodeBase.Infrastructure.State.GameStateMachine;

namespace CodeBase.Infrastructure.LevelLogic
{
    public class LoadMenuState : IPayloadedState<string>
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _curtain;

        public LoadMenuState(GameStateMachine  gameStateMachine, SceneLoader sceneLoader, LoadingCurtain curtain)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _curtain = curtain;
        }

        public void Enter(string sceneName)
        {
            _curtain.Show();
            _sceneLoader.Load(sceneName, OnLoaded);
        }


        private void OnLoaded()
        {
            _gameStateMachine.Enter<GameLoopState>();
        }

        public void Exit()
        {
            _curtain.Hide();
        }

        public void Enter()
        {
            //_curtain.Show();
            //_scenLoader.Load(MenuScene);
        }
    }
}