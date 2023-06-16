using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Infrastructure.StaticData.Windows
{
    [CreateAssetMenu(fileName = "WindowStaticData", menuName = "StaticData/Window static data")]
    public class WindowStaticData : ScriptableObject
    {
        public List<WindowConfig> Configs;
    }
}