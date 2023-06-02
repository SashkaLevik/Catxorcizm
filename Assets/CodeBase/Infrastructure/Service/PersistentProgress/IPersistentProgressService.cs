using CodeBase.Data;

namespace CodeBase.Infrastructure.Service.PersistentProgress
{
    public interface IPersistentProgressService : IService
    {
        PlayerProgress Progress { get; set; }
    }
}