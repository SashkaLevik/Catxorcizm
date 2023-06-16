using System;
using System.Collections.Generic;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.LevelLogic;
using CodeBase.Infrastructure.Service;
using CodeBase.Infrastructure.Service.PersistentProgress;
using CodeBase.Infrastructure.Service.SaveLoad;
using CodeBase.UI.Service.Factory;
using UnityEngine;

namespace CodeBase.Infrastructure.State
{
    public class GameStateMachine
    {
        private Dictionary<Type, IExitableState> _states;
        private IExitableState _activeState;

        public GameStateMachine(SceneLoader sceneLoader, LoadingCurtain loadingCurtain, AllServices services)
        {
            _states = new Dictionary<Type, IExitableState>
            {
                [typeof(BootstrapState)] = new BootstrapState(this, sceneLoader, services),
                [typeof(LoadMenuState)] = new LoadMenuState(this, sceneLoader, loadingCurtain),

                [typeof(LoadProgressState)] = new LoadProgressState(this, 
                    services.Single<IPersistentProgressService>(),services.Single<ISaveLoadService>()),
                
                [typeof(LoadPortState)] = new LoadPortState(this, sceneLoader, loadingCurtain, services.Single<IGameFactory>(), 
                    services.Single<IUIFactory>(), services.Single<IPersistentProgressService>()),
                
                
                [typeof(LoadMarketState)] = new LoadMarketState(this, sceneLoader),
                [typeof(LoadMageState)] = new LoadMageState(this, sceneLoader),
                [typeof(LoadAcademyState)] = new LoadAcademyState(this, sceneLoader),

                [typeof(GameLoopState)] = new GameLoopState(this),
            };
        }

        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>
        {
            TState state = ChangeState<TState>();
            state.Enter(payload);
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