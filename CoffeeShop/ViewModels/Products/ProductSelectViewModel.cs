using System;
using System.Windows.Input;
using CoffeeShop.Models;
using Xamarin.Forms;

namespace CoffeeShop.ViewModels.Products
{
    public class ProductSelectViewModel : CoffeeShopBaseViewModel
    {

        Product _product;
        public Product Product { get => _product; set => SetProperty(ref _product, value); }

        int _quantity;
        public int Quantity { get => _quantity; set => SetProperty(ref _quantity, value); }

        public ICommand QuantityIncreasedCommand => new Command(IncreaseQuantity);
        public ICommand QuantityDecreaseCommand => new Command(DecreaseQuantity, CanDecreaseQuantityOrAddToBasket);
        public ICommand AddToBasketCommand => new Command(AddToBasket,CanDecreaseQuantityOrAddToBasket);

        public ProductSelectViewModel()
        {
            Quantity = 1;
        }
        public ProductSelectViewModel(Product bag) : this()
        {
            Product = bag;
        }

        private void IncreaseQuantity()
        {
            Quantity++;
            RefreshCanExecute();
        }
        private void DecreaseQuantity()
        {
            Quantity--;
            RefreshCanExecute();
        }

        private void AddToBasket()
        {
            BasketService.AddToBasket(Product.Id, Quantity);
        }

        private void RefreshCanExecute()
        {
            (QuantityDecreaseCommand as Command).ChangeCanExecute();
            (AddToBasketCommand as Command).ChangeCanExecute();
        }
        private bool CanDecreaseQuantityOrAddToBasket()
        {
            return Quantity > 0;
        }
    }
}
