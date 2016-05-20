using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using UwizardWPF.Entities;
using UwizardWPF.Server;
using UwizardWPF.ViewModel;

namespace UwizardWPF
{
    public class Setup
    {
        public void Register()
        {
            var container = SimpleIoc.Default;
            
            DoRegistration(container);
            ServiceLocator.SetLocatorProvider(() => container);
            
            RegisterSchema(container.GetInstance<ISQLiteDatabase>());
        }

        protected virtual void DoRegistration(SimpleIoc container)
        {
            RegisterModels(container);
            RegisterViewModels(container);
            RegisterServices(container);
        }

        private void RegisterServices(SimpleIoc container)
        {
            throw new System.NotImplementedException();
        }

        private void RegisterViewModels(SimpleIoc container)
        {
            throw new System.NotImplementedException();
        }

        private void RegisterModels(SimpleIoc container)
        {
        }

        protected void RegisterSchema(ISQLiteDatabase db)
        {
        }
    }
}
