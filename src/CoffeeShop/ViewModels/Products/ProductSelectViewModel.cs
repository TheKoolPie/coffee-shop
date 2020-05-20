using System;
using System.Windows.Input;
using CoffeeShop.Models;
using CoffeeShop.ViewModels.TransferData;
using Xamarin.Forms;

namespace CoffeeShop.ViewModels
{
    public class ProductSelectViewModel : CoffeeShopBaseViewModel
    {

        Product _product;
        public Product Product 
        { 
            get => _product; 
            set => SetProperty(ref _product, value); 
        }

        int _quantity;
        public int Quantity 
        { 
            get => _quantity; 
            set => SetProperty(ref _quantity, value);
        }

        public ICommand SelectProductCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var navData = new ProductDetailNavData
                    {
                        Product = this.Product,
                        Quantity = this.Quantity
                    };
                    await NavigationService.PushAsync<ProductDetailViewModel>(navData);
                });
            }
        }
        public ICommand AddToBasketCommand 
        {
            get
            {
                return new Command(() =>
                {
                    AddToBasket();
                }, () =>
                {
                    return CanOperate();
                });
            }
        }

        public ProductSelectViewModel()
        {
            Quantity = 1;
        }
        public ProductSelectViewModel(Product bag) : this()
        {
            Product = bag;
        }

        private void AddToBasket()
        {
            BasketService.AddToBasket(Product.Id, Quantity);
            MessagingCenter.Send<ProductSelectViewModel, int>(this, "AddItemToBasket", Quantity);
        }
        private bool CanOperate()
        {
            return Quantity > 0;
        }
    }
}
