namespace Assets.Sashka.Infastructure
{
    public class LoadMarketState : IState
    {
        private const string MarketArea = "MarketArea";
        private GameStateMachine gameStateMachine;
        private ScenLoader _scenLoader;

        public LoadMarketState(GameStateMachine gameStateMachine, ScenLoader scenLoader)
        {
            this.gameStateMachine = gameStateMachine;
            this._scenLoader = scenLoader;
        }

        public void Enter()
        {
            _scenLoader.Load(MarketArea);
        }

        public void Exit()
        {
        }
    }
}