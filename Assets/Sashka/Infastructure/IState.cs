namespace Assets.Sashka.Infastructure
{
    public interface IState : IExitableState
    {
        public void Eneter();
    }

    public interface IPayLoadedState<TPayLoad> : IExitableState
    {
        public void Eneter(TPayLoad payLoad);
    }

    public interface IExitableState
    {
        public void Exit();
    }

}