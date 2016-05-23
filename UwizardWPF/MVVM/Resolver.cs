using System;
using System.Collections.Generic;
using SimpleInjector;

namespace UwizardWPF.MVVM
{
    /// <summary>
    /// A static class to be able to access the container from different classes and resolve diferent objects
    /// </summary>
    public class Resolver
    {
        private static IContainer _container;

        public static bool IsSet => _container != null;

        public static void SetContainer(IContainer container)
        {
            _container = container;
        }

        public static T Resolve<T>() where T : class
        {
            return _container.GetInstance<T>();
        }
        
        public static object Resolve(Type type)
        {
            return _container.GetInstance(type);
        }
        
        public static IEnumerable<T> ResolveAll<T>() where T : class
        {
            return _container.GetAllInstances<T>();
        }
        
        public static IEnumerable<object> ResolveAll(Type type)
        {
            return _container.GetAllInstances(type);
        }
    }
}
