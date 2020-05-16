using System;
using CoffeeShop.Models;

namespace CoffeeShop.Services
{
    public class BasketService : IBasketService
    {
        private Basket _basket;
        private readonly IProductRepository _products;
        
        public BasketService(Basket basket, IProductRepository productRepository)
        {
            _basket = basket;
            _products = productRepository;
        }

        public Basket Basket { get => _basket; }

        public async void AddToBasket(string productId, int quantity)
        {
            var product = await _products.GetProductByIdAsync(productId) ?? throw new Exception($"No Product with Id {productId} found in sortiment");

            var productInBasket = _basket[productId];
            if (productInBasket == null)
            {
                _basket.Products.Add(product, quantity);
            }
            else
            {
                _basket.Products[product] = _basket.Products[product] + quantity;
            }
        }

        public void RemoveFromBasket(string productId, int quantity)
        {
            throw new NotImplementedException();
        }
    }
}
