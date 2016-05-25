using AutoMapper;
using Microsoft.Practices.ServiceLocation;
using UwizardWPF.Entities;
using UwizardWPF.MVVM;
using UwizardWPF.Server;
using UwizardWPF.ViewModel;
using UwizardWPF.Views;
using Container = SimpleInjector.Container;

namespace UwizardWPF
{
    public class Setup
    {
        public void Register()
        {
            var container = new Container();
            container.RegisterSingleton<IContainer, UwizardContainer>();
            DoRegistration(container);
            Resolver.SetResolver(new UwizardResolver(container));
            RegisterViews(container);
            RegisterSchema(container.GetInstance<ISQLiteDatabase>());
        }

        protected virtual void DoRegistration(Container container)
        {
            RegisterModels(container);
            RegisterViewModels(container);
            RegisterServices(container);
        }

        private void RegisterViews(Container container)
        {
            ViewFactory.Register<MainWindow, MainViewModel>();
            ViewFactory.Register<GameManagementView, GameManagementViewModel>();
        }

        private void RegisterServices(Container container)
        {
            container.RegisterSingleton<ISQLiteDatabase, SQLiteDatabase>();
        }

        private void RegisterViewModels(Container container)
        {
            container.Register<MainViewModel>();
            container.Register<GameManagementViewModel>();
        }

        private void RegisterModels(Container container)
        {
        }

        protected void RegisterSchema(ISQLiteDatabase db)
        {
            db.Do(connection =>
            {
                connection.CreateTable(typeof(WiiUDisk));
            });
        }
    }
}
