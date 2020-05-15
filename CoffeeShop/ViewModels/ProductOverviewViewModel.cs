using System;
using System.Collections.ObjectModel;
using CoffeeShop.ViewModels.Products;
using MvvmHelpers;
using System.Linq;
using Xamarin.Forms;

namespace CoffeeShop.ViewModels
{
    public class ProductOverviewViewModel : CoffeeShopBaseViewModel
    {
        private ObservableCollection<ProductSelectViewModel> _products;
        public ObservableCollection<ProductSelectViewModel> Products
        {
            get => _products;
            set => SetProperty(ref _products, value);
        }

        private int _basketItemCount;
        public int BasketItemCount { get => _basketItemCount; set => SetProperty(ref _basketItemCount, value); }

        public ProductOverviewViewModel()
        {
            InitProductList();
            MessagingCenter.Subscribe<ProductSelectViewModel, int>(this, "AddItemToBasket", (sender, arg) =>
              {
                  BasketItemCount += arg;
              });
        }

        private async void InitProductList()
        {
            IsBusy = true;

            var allProducts = (await ProductRepository
                .GetProductsAsync())
                .Select(p => new ProductSelectViewModel(p));

            Products = new ObservableCollection<ProductSelectViewModel>(allProducts);


            IsBusy = false;
        }
    }
}
