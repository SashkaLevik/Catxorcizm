using CodeBase.Infrastructure.State;

namespace CodeBase.Infrastructure.LevelLogic
{
    public class LoadAcademyState : IState
    {
        private const string Academy = "Academy";
        private GameStateMachine _gameStateMachine;
        private SceneLoader _sceneLoader;

        public LoadAcademyState(GameStateMachine gameStateMachine, SceneLoader sceneLoader)
        {
            this._gameStateMachine = gameStateMachine;
            this._sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            _sceneLoader.Load(Academy);
        }

        public void Exit()
        {
        }
    }
}