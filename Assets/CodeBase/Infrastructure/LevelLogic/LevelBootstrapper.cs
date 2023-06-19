using CodeBase.Infrastructure.Service;
using CodeBase.Infrastructure.State;
using CodeBase.Infrastructure.UI;
using UnityEngine;

namespace CodeBase.Infrastructure.LevelLogic
{
    class LevelBootstrapper : MonoBehaviour
    {
        
        private const string PortArea = "PortArea";
        private const string Academy = "Academy";
        private const string MageArea = "MageArea";
        private const string MarketArea = "MarketArea";

        [SerializeField] private LevelScreen _levelScreen;

        public LoadingCurtain Curtain;
        private IGameStateMachine _stateMachine;

        private void Awake()
        {
            _stateMachine = AllServices.Container.Single<IGameStateMachine>();
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
            _stateMachine.Enter<LoadMenuState, string>(Academy);
        }

        private void OnMageLoaded()
        {
            _stateMachine.Enter<LoadMenuState, string>(MageArea);
        }

        private void OnMarketLoaded()
        {
            _stateMachine.Enter<LoadMenuState, string>(MarketArea);
        }

        private void OnPortAreaLoad()
        {
            _stateMachine.Enter<LoadMenuState, string>(PortArea);
            _stateMachine.Enter<LoadProgressState>();
        }
    }
}
