using CoffeeShop.Models;
using CoffeeShop.ViewModels.TransferData;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CoffeeShop.ViewModels
{
    public class ProductDetailViewModel : CoffeeShopBaseViewModel
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

        public override Task InitializeAsync(object navigationData)
        {
            if (navigationData != null)
            {
                var data = (ProductDetailNavData)navigationData;
                Product = data.Product;
                Quantity = data.Quantity;
            }
            return Task.FromResult(false);
        }

        private void AddToBasket()
        {
            BasketService.AddToBasket(Product.Id, Quantity);
            MessagingCenter.Send<ProductDetailViewModel, int>(this, "AddItemToBasket", Quantity);
        }
        private bool CanOperate()
        {
            return Quantity > 0;
        }
    }
}
