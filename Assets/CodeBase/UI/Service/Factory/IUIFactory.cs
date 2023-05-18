using CodeBase.Infrastructure.Service;

namespace CodeBase.UI.Service.Factory
{
    public interface IUIFactory : IService 
    {
        void CreateShop();
        void CreateUIRoot();
    }
}