using UnityEngine;

namespace Assets.Sashka.Infastructure
{
    public class Game
    {
        public GameStateMachine _stateMachine;

        public Game(ICoroutineRunner coroutineRunner, Loading curtain)
        {
            _stateMachine = new GameStateMachine(new ScenLoader(coroutineRunner), curtain);
        }        
    }
}