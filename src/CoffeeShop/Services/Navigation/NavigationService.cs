using CoffeeShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CoffeeShop.Services
{
    public class NavigationService : INavigationService
    {
        INavigation FormsNavigation
        {
            get
            {
                var tabController = Application.Current.MainPage as TabbedPage;
                var masterController = Application.Current.MainPage as MasterDetailPage;

                INavigation navItem = tabController?.CurrentPage?.Navigation;
                if (navItem == null)
                {
                    navItem = (masterController?.Detail as TabbedPage)?.CurrentPage?.Navigation;
                    if (navItem == null)
                    {
                        navItem = masterController?.Detail?.Navigation;
                        if (navItem == null)
                        {
                            navItem = Application.Current.MainPage.Navigation;
                        }
                    }
                }
                return navItem;
            }
        }

        public CoffeeShopBaseViewModel PreviousPageViewModel
        {
            get
            {
                var mainPage = Application.Current.MainPage as NavigationPage;
                var vm = mainPage.Navigation.NavigationStack[mainPage.Navigation.NavigationStack.Count - 2].BindingContext;
                return vm as CoffeeShopBaseViewModel;
            }
        }

        public Task InitializeAsync()
        {
            Application.Current.MainPage = new NavigationPage(CreatePage(typeof(ProductOverviewViewModel), null));

            return Task.FromResult(false);
        }

        #region Push
        public async Task PushAsync<TViewModel>() where TViewModel : CoffeeShopBaseViewModel
        {
            Page page = CreatePage(typeof(TViewModel), null);

            await FormsNavigation.PushAsync(page);
        }
        public async Task PushAsync<TViewModel>(object parameter) where TViewModel : CoffeeShopBaseViewModel
        {
            Page page = CreatePage(typeof(TViewModel), parameter);
            await (page.BindingContext as CoffeeShopBaseViewModel).InitializeAsync(parameter);

            await FormsNavigation.PushAsync(page);
        }
        public async Task PushModalAsync<TViewModel>() where TViewModel : CoffeeShopBaseViewModel
        {
            Page page = CreatePage(typeof(TViewModel), null);
            //Put in NavigationPage to use title bar
            var nv = new NavigationPage(page);

            await FormsNavigation.PushModalAsync(nv);
        }
        public async Task PushModalAsync<TViewModel>(object parameter) where TViewModel : CoffeeShopBaseViewModel
        {
            Page page = CreatePage(typeof(TViewModel), parameter);
            await (page.BindingContext as CoffeeShopBaseViewModel).InitializeAsync(parameter);
            //Put in NavigationPage to use title bar
            var nv = new NavigationPage(page);

            await FormsNavigation.PushModalAsync(nv);
        }
        #endregion

        #region Pop
        public async Task PopAsync()
        {
            await FormsNavigation.PopAsync(true);
        }
        public async Task PopModalAsync()
        {
            await FormsNavigation.PopModalAsync(true);
        }
        public async Task PopToRootAsync(bool animate)
        {
            await FormsNavigation.PopToRootAsync(animate);
        }
        public async Task PopToRootAsync()
        {
            await FormsNavigation.PopToRootAsync(true);
        }
        #endregion

        private Type GetPageTypeForViewModel(Type viewModelType)
        {
            var viewName = viewModelType.FullName.Replace("Model", string.Empty);
            var viewModelAssemblyName = viewModelType.GetTypeInfo().Assembly.FullName;
            var viewAssemblyName = string.Format(CultureInfo.InvariantCulture, "{0}, {1}", viewName, viewModelAssemblyName);
            var viewType = Type.GetType(viewAssemblyName);
            return viewType;
        }

        private Page CreatePage(Type viewModelType, object parameter)
        {
            Type pageType = GetPageTypeForViewModel(viewModelType);
            if (pageType == null)
            {
                throw new Exception($"Cannot locate page type for {viewModelType}");
            }

            Page page = Activator.CreateInstance(pageType) as Page;
            return page;
        }

        public Task RemoveLastFromBackStackAsync()
        {
            var mainPage = Application.Current.MainPage as NavigationPage;
            if (mainPage != null)
            {
                mainPage.Navigation.RemovePage(
                    mainPage.Navigation.NavigationStack[mainPage.Navigation.NavigationStack.Count - 2]);
            }
            return Task.FromResult(true);
        }

        public Task RemoveBackStackAsync()
        {
            var mainPage = Application.Current.MainPage as NavigationPage;

            if (mainPage != null)
            {
                for (int i = 0; i < mainPage.Navigation.NavigationStack.Count - 1; i++)
                {
                    var page = mainPage.Navigation.NavigationStack[i];
                    mainPage.Navigation.RemovePage(page);
                }
            }

            return Task.FromResult(true);
        }
    }
}
