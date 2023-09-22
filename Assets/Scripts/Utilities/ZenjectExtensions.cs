using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ModestTree;
using Zenject;

namespace Utilities
{
    public static class ZenjectExtensions
    {
        public static void BindAllDerivedInterfacesAndSelf<T>(this DiContainer container, Action<FromBinder> scope)
        {
            Assembly assembly = Assembly.GetAssembly(typeof(T));

            IEnumerable<Type> types = assembly.GetTypes()
                .Where(t => t.DerivesFrom<T>() && !t.IsAbstract && t.IsClass);

            foreach (Type type in types)
                scope(container.BindInterfacesAndSelfTo(type));
        }
    }
}
