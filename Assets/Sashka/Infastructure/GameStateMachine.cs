using Assets.Sashka.Infastructure.Services;
using Sashka.Infastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Sashka.Infastructure
{
    public class GameStateMachine : IGameStateMachine
    {
        private readonly Dictionary<Type, IExitableState> _states;
        private IExitableState _activeState;

        public GameStateMachine(ScenLoader scenLoader, Loading curtain, AllServices services)
        {
            _states = new Dictionary<Type, IExitableState>
            {
                [typeof(BootstrapState)] = new BootstrapState(this, scenLoader, services),
                [typeof(LoadMenuState)] = new LoadMenuState(this, scenLoader, curtain),
                //[typeof(LoadMarketState)] = new LoadMarketState(this, scenLoader),
                ////[typeof(LoadPortState)] = new LoadPortState(this, scenLoader),
                //[typeof(LoadMageState)] = new LoadMageState(this, scenLoader),
                //[typeof(LoadAcademyState)] = new LoadAcademyState(this, scenLoader),
                [typeof(GameLoopState)] = new GameLoopState(this),
            };
        }

        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TPayLoad>(TPayLoad payLoad) where TState : class, IPayLoadedState<TPayLoad>
        {
            TState state = ChangeState<TState>();
            state.Enter(payLoad);
        }

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _activeState?.Exit();
            TState state = GetState<TState>();
            _activeState = state;
            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState =>
            _states[typeof(TState)] as TState;
    }
}
