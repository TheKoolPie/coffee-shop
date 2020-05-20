using System;
using System.Threading.Tasks;
using CoffeeShop.Models;
using CoffeeShop.Services;
using CoffeeShop.ViewModels.Base;
using MvvmHelpers;

namespace CoffeeShop.ViewModels
{
    public class CoffeeShopBaseViewModel : BaseViewModel
    {
        protected IBasketService BasketService { get; private set; }
        protected IProductRepository ProductRepository { get; private set; }
        protected INavigationService NavigationService { get; private set; }
        protected IDisplayAlertService DisplayAlertService { get; private set; }

        public CoffeeShopBaseViewModel()
        {
            BasketService = ViewModelLocator.Resolve<IBasketService>();
            ProductRepository = ViewModelLocator.Resolve<IProductRepository>();
            NavigationService = ViewModelLocator.Resolve<INavigationService>();
            DisplayAlertService = ViewModelLocator.Resolve<IDisplayAlertService>();

        }

        public virtual Task InitializeAsync(object navigationData)
        {
            return Task.FromResult(false);
        }
    }
}
