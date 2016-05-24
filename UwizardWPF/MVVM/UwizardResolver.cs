using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleInjector;

namespace UwizardWPF.MVVM
{
    public class UwizardResolver : IResolver
    {
        private Container _container;

        public UwizardResolver(Container container)
        {
            _container = container;
        }

        public bool IsSet => _container != null;

        public void SetContainer(Container container)
        {
            _container = container;
        }

        public T Resolve<T>() where T : class
        {
            return _container.GetInstance<T>();
        }

        public object Resolve(Type type)
        {
            return _container.GetInstance(type);
        }

        public IEnumerable<T> ResolveAll<T>() where T : class
        {
            return _container.GetAllInstances<T>();
        }

        public IEnumerable<object> ResolveAll(Type type)
        {
            return _container.GetAllInstances(type);
        }
    }
}
