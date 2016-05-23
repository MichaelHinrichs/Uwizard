using System;
using System.Collections.Generic;
using System.Windows.Controls;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using SimpleInjector;

namespace UwizardWPF.MVVM
{
    public class ViewFactory
    {
        private static readonly Dictionary<Type, Type> TypeDictionary = new Dictionary<Type, Type>();

        public static void Register<TView, TViewModel>(Func<IContainer, TViewModel> func = null)
            where TView : class
            where TViewModel : ViewModelBase
        {
            TypeDictionary[typeof(TViewModel)] = typeof(TView);

            var container = Resolver.Resolve<UwizardContainer>();
            // check if we have DI container
            if (container != null)
            {
                // register viewmodel with DI to enable non default vm constructors / service locator
                if (func == null)
                    container.Register<TViewModel, TViewModel>();
                else
                    container.Register(() => func(container));
            }
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

            object page;
            IViewModel viewModel;
            var pageCacheKey = string.Format("{0}:{1}", viewModelType.Name, viewType.Name);

            if (EnableCache && PageCache.ContainsKey(pageCacheKey))
            {
                var cache = PageCache[pageCacheKey];
                viewModel = cache.Item1;
                page = cache.Item2;
            }
            else
            {
                viewModel = (Resolver.Resolve(viewModelType) ?? Activator.CreateInstance(viewModelType)) as IViewModel;

                page = Activator.CreateInstance(viewType, args);

                if (EnableCache)
                {
                    PageCache[pageCacheKey] = new Tuple<IViewModel, object>(viewModel, page);
                }
            }

            viewModel.NavigationService = Resolver.Resolve<INavigationService>();

            if (initialiser != null)
            {
                initialiser(viewModel, page);
            }

            var pageBindable = page as BindableObject;
            if (pageBindable != null)
            {
                // forcing break reference on viewmodel in order to allow initializer to do its work
                pageBindable.BindingContext = null;
                pageBindable.BindingContext = viewModel;
            }
            var formsPage = page as Page;
            if (formsPage != null)
            {
                viewModel.Navigation = new ViewModelNavigation(formsPage.Navigation);
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
            where TViewModel : class, IViewModel
        {
            Action<object, object> i = (o1, o2) =>
            {
                if (initialiser != null)
                {
                    initialiser((TViewModel)o1, (TPage)o2);
                }
            };

            return CreatePage(typeof(TViewModel), i, args);
        }
    }
}
