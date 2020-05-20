using System;
using CoffeeShop.Models;

namespace CoffeeShop.Services
{
    public class BasketService : IBasketService
    {
        private readonly IProductRepository _products;

        public BasketService(IProductRepository productRepository)
        {
            Basket = new Basket();
            _products = productRepository;
        }

        public Basket Basket { get; set; }

        public async void AddToBasket(string productId, int quantity)
        {
            var product = await _products.GetProductByIdAsync(productId) ?? throw new Exception($"No Product with Id {productId} found in sortiment");

            var productInBasket = Basket[productId];
            if (productInBasket == null)
            {
                Basket.Products.Add(product, quantity);
            }
            else
            {
                Basket.Products[product] = Basket.Products[product] + quantity;
            }
        }

        public void RemoveFromBasket(string productId, int quantity)
        {
            throw new NotImplementedException();
        }
    }
}
