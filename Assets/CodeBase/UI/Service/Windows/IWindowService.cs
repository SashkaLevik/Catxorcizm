using CodeBase.Infrastructure.Service;

namespace CodeBase.UI.Service.Windows
{
    public interface IWindowService : IService
    {
        void Open(WindowID windowID);
    }
}