using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Sashka.Infastructure
{
    class LoadPortState : IState
    {
        private const string PortArea = "PortArea";
        private readonly GameStateMachine _gameStateMachine;
        private readonly ScenLoader _scenLoader;

        public LoadPortState(GameStateMachine gameStateMachine, ScenLoader scenLoader)
        {
            _gameStateMachine = gameStateMachine;
            _scenLoader = scenLoader;
        }

        public void Enter()
        {
            _scenLoader.Load(PortArea);
        }

        public void Exit()
        {
        }
    }
}
