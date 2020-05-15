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
        public int Quantity 
        { 
            get => _quantity; 
            set 
            {
                SetProperty(ref _quantity, value);
            } 
        }

        public ICommand QuantityIncreaseCommand { private set; get; }
        public ICommand QuantityDecreaseCommand { private set; get; }
        public ICommand AddToBasketCommand { private set; get; }

        public ProductSelectViewModel()
        {
            Quantity = 1;
            QuantityDecreaseCommand = new Command(() =>
            {
                DecreaseQuantity();
                RefreshCanExecute();
            },
            () =>
            {
               return CanOperate();
            });
            QuantityIncreaseCommand = new Command(()=>
            {
                IncreaseQuantity();
                RefreshCanExecute();
            });
            AddToBasketCommand = new Command(() =>
            {
                AddToBasket();
                RefreshCanExecute();
            }, () =>
            {
                return CanOperate();
            });
        }
        public ProductSelectViewModel(Product bag) : this()
        {
            Product = bag;
        }

        private void IncreaseQuantity()
        {
            Quantity++;
        }
        private void DecreaseQuantity()
        {
            Quantity--;
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
        private void RefreshCanExecute()
        {
            ((Command)QuantityDecreaseCommand).ChangeCanExecute();
            ((Command)AddToBasketCommand).ChangeCanExecute();
        }
    }
}
