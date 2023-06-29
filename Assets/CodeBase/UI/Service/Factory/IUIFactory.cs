using CodeBase.Infrastructure.Service;
using CodeBase.UI.Forms;
using UnityEngine;

namespace CodeBase.UI.Service.Factory
{
    public interface IUIFactory : IService 
    { 
        GameObject CreateUIRoot();
        ShopWindow Shop { get; }
        UpgradeMinions Upgrade { get; }
    }
}