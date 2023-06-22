using CodeBase.Infrastructure.State;

namespace CodeBase.Infrastructure.LevelLogic
{
    public class LoadMageState : IState
    {
        private const string MageArea = "MageArea";
        private GameStateMachine gameStateMachine;
        private SceneLoader _sceneLoader;

        public LoadMageState(GameStateMachine gameStateMachine, SceneLoader sceneLoader)
        {
            this.gameStateMachine = gameStateMachine;
            this._sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            _sceneLoader.Load(MageArea);
        }

        public void Exit()
        {
        }
    }
}