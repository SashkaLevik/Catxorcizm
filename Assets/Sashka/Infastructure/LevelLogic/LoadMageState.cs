namespace Assets.Sashka.Infastructure
{
    public class LoadMageState : IState
    {
        private const string MageArea = "MageArea";
        private GameStateMachine gameStateMachine;
        private ScenLoader _scenLoader;

        public LoadMageState(GameStateMachine gameStateMachine, ScenLoader scenLoader)
        {
            this.gameStateMachine = gameStateMachine;
            this._scenLoader = scenLoader;
        }

        public void Enter()
        {
            _scenLoader.Load(MageArea);
        }

        public void Exit()
        {
        }
    }
}