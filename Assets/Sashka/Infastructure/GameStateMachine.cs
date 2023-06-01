using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Sashka.Infastructure
{
    public class GameStateMachine
    {
        private readonly Dictionary<Type, IExitableState> _states;
        private IExitableState _activeState;

        public GameStateMachine(ScenLoader scenLoader)
        {
            _states = new Dictionary<Type, IExitableState>
            {
                [typeof(BootstrapState)] = new BootstrapState(this, scenLoader),
                [typeof(LoadMenuState)] = new LoadMenuState(this, scenLoader),
                [typeof(LoadPortState)] = new LoadPortState(this, scenLoader),
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
