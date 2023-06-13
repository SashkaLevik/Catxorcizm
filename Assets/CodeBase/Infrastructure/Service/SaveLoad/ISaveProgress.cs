using CodeBase.Data;

namespace CodeBase.Infrastructure.Service.SaveLoad
{
    public interface ISavedProgressReader
    {
        void LoadProgress(PlayerProgress progress);
    }
}