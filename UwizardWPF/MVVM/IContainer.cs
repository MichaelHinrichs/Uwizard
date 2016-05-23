using System;
using System.Collections.Generic;

namespace UwizardWPF.MVVM
{
    public interface IContainer {
        T GetInstance<T>() where T : class;
        object GetInstance(Type type);
        IEnumerable<T> GetAllInstances<T>() where T : class;
        IEnumerable<object> GetAllInstances(Type type);
    }
}
