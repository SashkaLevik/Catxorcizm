﻿namespace Assets.Sashka.Infastructure
{
    public interface IState : IExitableState
    {
        public void Enter();
    }

    public interface IPayLoadedState<TPayLoad> : IExitableState
    {
        public void Enter(TPayLoad payLoad);
    }

    public interface IExitableState
    {
        public void Exit();
    }

}