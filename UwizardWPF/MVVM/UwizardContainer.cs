using System;
using System.Collections.Generic;
using SimpleInjector;

namespace UwizardWPF.MVVM
{
    public class UwizardContainer : IContainer
    {
        private readonly Container _container;
        private readonly IResolver _resolver;

        public UwizardContainer(Container container)
        {
            _container = container;
            _resolver = new UwizardResolver(container);
        }

        public IResolver GetResolver()
        {
            return _resolver;
        }

        public IContainer Register<T>(T instance) where T : class
        {
            _container.RegisterSingleton(instance);
            return this;
        }

        public IContainer Register<T, TImpl>() where T : class where TImpl : class, T
        {
            _container.Register<T, TImpl>();
            return this;
        }

        public IContainer RegisterSingle<T, TImpl>() where T : class where TImpl : class, T
        {
            _container.RegisterSingleton<T, TImpl>();
            return this;
        }

        public IContainer Register<T>(Type type) where T : class
        {
            _container.Register(typeof(T), type);
            return this;
        }

        public IContainer Register(Type type, Type impl)
        {
            _container.Register(type, impl);
            return this;
        }

        public IContainer Register<T>(Func<IResolver, T> func) where T : class
        {
            _container.Register(()=>func(_resolver));
            return this;
        }
    }
}
