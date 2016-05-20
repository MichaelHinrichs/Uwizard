using SimpleInjector;
using UwizardWPF.Server;
using UwizardWPF.ViewModel;

namespace UwizardWPF
{
    public class Setup
    {
        public void Register()
        {
            var container = new Container();
            
            DoRegistration(container);
            RegisterSchema(container.GetInstance<ISQLiteDatabase>());
        }

        protected virtual void DoRegistration(Container container)
        {
            RegisterModels(container);
            RegisterViewModels(container);
            RegisterServices(container);
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
        }
    }
}
