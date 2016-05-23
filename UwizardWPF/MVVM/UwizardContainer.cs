using System;
using System.Collections.Generic;
using SimpleInjector;

namespace UwizardWPF.MVVM
{
    public class UwizardContainer : IContainer
    {
        private Container _container;

        public UwizardContainer(Container container)
        {
            _container = container;
        }

        public T GetInstance<T>() where T : class
        {
            return _container.GetInstance<T>();
        }

        public object GetInstance(Type type)
        {
            return _container.GetInstance(type);
        }

        public IEnumerable<T> GetAllInstances<T>() where T : class
        {
            return _container.GetAllInstances<T>();
        }

        public IEnumerable<object> GetAllInstances(Type type)
        {
            return _container.GetAllInstances(type);
        }
    }
}
