using System;
using CoffeeShop.Services;
using MvvmHelpers;

namespace CoffeeShop.ViewModels
{
    public class CoffeeShopBaseViewModel : BaseViewModel
    {
        public readonly IBasketService BasketService;
        public readonly IProductRepository ProductRepository;

        public CoffeeShopBaseViewModel()
        {
            ProductRepository = new ProductRepository();
            BasketService = new BasketService(new Models.Basket(), ProductRepository);
        }
    }
}
