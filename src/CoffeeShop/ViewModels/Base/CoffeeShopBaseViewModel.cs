using System;
using CoffeeShop.Models;
using CoffeeShop.Services;
using MvvmHelpers;

namespace CoffeeShop.ViewModels
{
    public class CoffeeShopBaseViewModel : BaseViewModel
    {
        private Basket _basket;
        public readonly IBasketService BasketService;
        public readonly IProductRepository ProductRepository;
        public CoffeeShopBaseViewModel()
        {
            _basket = new Basket();
            ProductRepository = new ProductRepository();
            BasketService = new BasketService(_basket, ProductRepository);
        }
    }
}
