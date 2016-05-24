using System;
using System.Collections.Generic;

namespace UwizardWPF.MVVM
{
    /// <summary>
    /// A static class to be able to access the container from different classes and resolve diferent objects
    /// </summary>
    public static class Resolver
    {
        private static IResolver _resolver;

        public static bool IsSet => _resolver != null;

        public static void SetResolver(IResolver resolver)
        {
            _resolver = resolver;
        }

        public static T Resolve<T>() where T : class
        {
            return _resolver.Resolve<T>();
        }
        
        public static object Resolve(Type type)
        {
            return _resolver.Resolve(type);
        }
        
        public static IEnumerable<T> ResolveAll<T>() where T : class
        {
            return _resolver.ResolveAll<T>();
        }
        
        public static IEnumerable<object> ResolveAll(Type type)
        {
            return _resolver.ResolveAll(type);
        }
    }
}
