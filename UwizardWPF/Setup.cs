using AutoMapper;
using Microsoft.Practices.ServiceLocation;
using UwizardWPF.Entities;
using UwizardWPF.MVVM;
using UwizardWPF.Server;
using UwizardWPF.ViewModel;
using Container = SimpleInjector.Container;

namespace UwizardWPF
{
    public class Setup
    {
        public void Register()
        {
            var container = new Container();
            
            DoRegistration(container);
            RegisterSchema(container.GetInstance<ISQLiteDatabase>());
            Resolver.SetResolver(new UwizardResolver(container));
        }

        protected virtual void DoRegistration(Container container)
        {
            RegisterModels(container);
            RegisterViewModels(container);
            RegisterViews(container);
            RegisterServices(container);
        }

        private void RegisterViews(Container container)
        {
            ViewFactory;
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
