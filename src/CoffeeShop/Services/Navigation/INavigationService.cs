using CoffeeShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Services
{
    public interface INavigationService
    {
        CoffeeShopBaseViewModel PreviousPageViewModel { get; }

        Task InitializeAsync();

        Task PushAsync<TViewModel>() where TViewModel : CoffeeShopBaseViewModel;
        Task PushAsync<TViewModel>(object parameter) where TViewModel : CoffeeShopBaseViewModel;
        Task PushModalAsync<TViewModel>() where TViewModel : CoffeeShopBaseViewModel;
        Task PushModalAsync<TViewModel>(object parameter) where TViewModel : CoffeeShopBaseViewModel;

        Task PopAsync();
        Task PopModalAsync();
        Task PopToRootAsync(bool animate);

        Task RemoveLastFromBackStackAsync();

        Task RemoveBackStackAsync();
    }
}
