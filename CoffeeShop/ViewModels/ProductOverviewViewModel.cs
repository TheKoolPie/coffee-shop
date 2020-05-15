using System;
using System.Collections.ObjectModel;
using CoffeeShop.ViewModels.Products;
using MvvmHelpers;
using System.Linq;

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

        public ProductOverviewViewModel()
        {
            InitProductList();
        }

        private async void InitProductList()
        {
            IsBusy = true;

            var allProducts = (await ProductRepository
                .GetProductsAsync())
                .Select(p=> new ProductSelectViewModel(p));

            Products = new ObservableCollection<ProductSelectViewModel>(allProducts);


            IsBusy = false;
        }
    }
}
