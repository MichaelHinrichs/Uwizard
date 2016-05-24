using System;
using System.Collections.Generic;
using SimpleInjector;

namespace UwizardWPF.MVVM
{
    public interface IResolver
    {
        void SetContainer(Container container);
        T Resolve<T>() where T : class;
        object Resolve(Type type);
        IEnumerable<T> ResolveAll<T>() where T : class;
        IEnumerable<object> ResolveAll(Type type);
    }
}