using System;

namespace UwizardWPF.MVVM
{
    public interface IContainer {
        IResolver GetResolver();
        IContainer Register<T>(T instance) where T : class;
        IContainer Register<T, TImpl>() where T : class where TImpl : class, T;
        IContainer RegisterSingle<T, TImpl>() where T : class where TImpl : class, T;
        IContainer Register<T>(Type type) where T : class;
        IContainer Register(Type type, Type impl);
        IContainer Register<T>(Func<IResolver, T> func) where T : class;
    }
}
