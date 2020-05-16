using System;
using CoffeeShop.Models;

namespace CoffeeShop.Services
{
    public interface IBasketService
    {
        Basket Basket { get; }
        void AddToBasket(string productId, int quantity);
        void RemoveFromBasket(string productId, int quantity);
    }
}
