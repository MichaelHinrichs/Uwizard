using System;
using System.Collections.Generic;
using System.Windows.Controls;
using GalaSoft.MvvmLight;

namespace UwizardWPF.MVVM
{
    public class ViewFactory
    {
        private static readonly Dictionary<Type, Type> TypeDictionary = new Dictionary<Type, Type>();

        public static void Register<TView, TViewModel>(Func<IResolver, TViewModel> func = null)
            where TView : class
            where TViewModel : ViewModelBase
        {
            TypeDictionary[typeof(TViewModel)] = typeof(TView);

            //var container = Resolver.Resolve<IContainer>();
            //// check if we have DI container
            //if (container == null) return;
            //// register viewmodel with DI to enable non default vm constructors / service locator
            //if (func == null)
            //    container.Register<TViewModel, TViewModel>();
            //else
            //    container.Register(func(container.GetResolver()));
        }

        /// <summary>
        /// Creates the page.
        /// </summary>
        /// <param name="viewModelType">Type of the view model.</param>
        /// <param name="initialiser">The initialiser.</param>
        /// <param name="args">The arguments.</param>
        /// <returns>System.Object.</returns>
        /// <exception cref="System.InvalidOperationException">Unknown View for ViewModel</exception>
        public static object CreatePage(Type viewModelType, Action<object, object> initialiser = null, params object[] args)
        {
            Type viewType;

            if (TypeDictionary.ContainsKey(viewModelType))
            {
                viewType = TypeDictionary[viewModelType];
            }
            else
            {
                throw new InvalidOperationException("Unknown View for ViewModel");
            }
            

            var viewModel = (Resolver.Resolve(viewModelType) ?? Activator.CreateInstance(viewModelType)) as ViewModelBase;
            var page = Activator.CreateInstance(viewType, args);

            initialiser?.Invoke(viewModel, page);

            var pageBindable = page as Page;
            if (pageBindable != null)
            {
                // forcing break reference on viewmodel in order to allow initializer to do its work
                pageBindable.DataContext = null;
                pageBindable.DataContext = viewModel;
            }

            return page;
        }

        /// <summary>
        /// Creates the page.
        /// </summary>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        /// <typeparam name="TPage">The type of the t page.</typeparam>
        /// <param name="initialiser">The create action.</param>
        /// <param name="args">The arguments.</param>
        /// <returns>Page for the ViewModel.</returns>
        /// <exception cref="System.InvalidOperationException">Unknown View for ViewModel.</exception>
        public static object CreatePage<TViewModel, TPage>(Action<TViewModel, TPage> initialiser = null, params object[] args)
            where TViewModel : ViewModelBase
        {
            Action<object, object> i = (o1, o2) =>
            {
                initialiser?.Invoke((TViewModel)o1, (TPage)o2);
            };

            return CreatePage(typeof(TViewModel), i, args);
        }
    }
}
