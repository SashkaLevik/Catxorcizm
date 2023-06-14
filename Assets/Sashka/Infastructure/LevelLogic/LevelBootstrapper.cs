using Assets.Sashka.Infastructure.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Sashka.Infastructure
{
    class LevelBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        public Loading Curtain;

        [SerializeField] private LevelScreen _levelScreen;
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
            _game._stateMachine.Enter<LoadAcademyState>();
        }

        private void OnMageLoaded()
        {
            _game._stateMachine.Enter<LoadMageState>();
        }

        private void OnMarketLoaded()
        {
            _game._stateMachine.Enter<LoadMarketState>();
        }

        private void OnPortAreaLoad()
        {
            _game._stateMachine.Enter<LoadPortState>();
        }
    }
}
