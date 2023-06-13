using CodeBase.Data;

namespace CodeBase.Infrastructure.Service.SaveLoad
{
    public interface ISavedProgress : ISavedProgressReader
    {
        public void UpdateProgress(PlayerProgress progress);
    }
}