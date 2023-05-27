namespace Assets.Sashka.Infastructure
{
    public class Game
    {
        public GameStateMachine _stateMachine;

        public Game(ICoroutineRunner coroutineRunner)
        {
            _stateMachine = new GameStateMachine(new ScenLoader(coroutineRunner));
        }
    }
}