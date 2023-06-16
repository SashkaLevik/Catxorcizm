namespace Assets.Sashka.Infastructure
{
    public class LoadAcademyState : IState
    {
        private const string Academy = "Academy";
        private GameStateMachine gameStateMachine;
        private ScenLoader _scenLoader;

        public LoadAcademyState(GameStateMachine gameStateMachine, ScenLoader scenLoader)
        {
            this.gameStateMachine = gameStateMachine;
            this._scenLoader = scenLoader;
        }

        public void Enter()
        {
            _scenLoader.Load(Academy);
        }

        public void Exit()
        {
            
        }
    }
}