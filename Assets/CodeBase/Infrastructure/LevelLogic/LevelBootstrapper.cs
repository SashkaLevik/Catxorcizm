using CodeBase.Infrastructure.Service;
using CodeBase.Infrastructure.Service.PersistentProgress;
using CodeBase.Infrastructure.Service.SaveLoad;
using CodeBase.Infrastructure.State;
using CodeBase.Infrastructure.UI;
using CodeBase.UI;
using UnityEngine;

namespace CodeBase.Infrastructure.LevelLogic
{
    class LevelBootstrapper : MonoBehaviour
    {
        [SerializeField] private LevelScreen _levelScreen;
        [SerializeField] private ButtonLevel buttonLevel;

        public LoadingCurtain Curtain;

        private const string PortArea = "PortArea";
        private const string MarketArea = "MarketArea";
        private const string MageArea = "MageArea";
        private const string Academy = "Academy";
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
            _stateMachine.Enter<LoadAcademyState, string>(Academy);
        }

        private void OnMageLoaded()
        {
            _stateMachine.Enter<LoadLevelState, string>(MageArea);
        }

        private void OnMarketLoaded()
        {
            _stateMachine.Enter<LoadLevelState, string>(MarketArea);
        }

        private void OnPortAreaLoad()
        {
            _stateMachine.Enter<LoadLevelState, string>(PortArea);
        }
    }
}