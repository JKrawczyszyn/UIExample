using UnityEngine;
using Zenject;

namespace Utilities
{
    public static class ZenjectExtensions
    {
        public static void BindConfig<T>(this DiContainer container, string path) where T : ScriptableObject
        {
            var config = (T)Resources.Load(path);
            container.BindInstance(config).AsSingle();
        }
    }
}
