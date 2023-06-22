using Assets.Sashka.Infastructure.Services;
using CodeBase.Infrastructure.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Sashka.Infastructure
{
    class LevelBootstrapper : MonoBehaviour
    {
        private const string PortArea = "PortArea";
        private const string MarketArea = "MarketArea";
        private const string MageArea = "MageArea";
        private const string Academy = "Academy";

        public Loading Curtain;

        [SerializeField] private LevelScreen _levelScreen;

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
        }
    }
}
