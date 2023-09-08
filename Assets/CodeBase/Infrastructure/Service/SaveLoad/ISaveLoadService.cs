using CodeBase.Data;

namespace CodeBase.Infrastructure.Service.SaveLoad
{
    public interface ISaveLoadService : IService
    {
        void SaveProgress();

        public void ResetProgress();

        PlayerProgress LoadProgress();
    }
}