using CodeBase.Infrastructure.State;
using CodeBase.Infrastructure.UI;
using UnityEngine;

namespace CodeBase.Infrastructure.LevelLogic
{
    class LevelBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        public LoadingCurtain Curtain;

        [SerializeField] private LevelScreen _levelScreen;
        
        private const string PortArea = "PortArea";
        private Game _game;

        private void Awake()
        {
            _game = new Game(this, Curtain);

            DontDestroyOnLoad(this);
        }

        private void OnEnable()
        {
            _levelScreen.MarketLoaded += OnMarketLoaded;
            _levelScreen.PortLoaded += OnPortAreaLoad;
            _levelScreen.MageLoaded += OnMageLoaded;
            _levelScreen.AcademyLoaded += OnAcademyLoaded;
        }


        private void OnDisable()
        {
            _levelScreen.MarketLoaded -= OnMarketLoaded;
            _levelScreen.PortLoaded -= OnPortAreaLoad;
            _levelScreen.MageLoaded -= OnMageLoaded;
            _levelScreen.AcademyLoaded -= OnAcademyLoaded;
        }        

        private void OnAcademyLoaded()
        {
            _game.StateMachine.Enter<LoadAcademyState>();
        }

        private void OnMageLoaded()
        {
            _game.StateMachine.Enter<LoadMageState>();
        }

        private void OnMarketLoaded()
        {
            _game.StateMachine.Enter<LoadMarketState>();
        }

        private void OnPortAreaLoad()
        {
            _game.StateMachine.Enter<LoadPortState, string>(PortArea);
            _game.StateMachine.Enter<LoadProgressState>();
        }
    }
}
