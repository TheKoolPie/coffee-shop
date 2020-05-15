using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoffeeShop.Models;

namespace CoffeeShop.Services
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetProductByIdAsync(string productId);
    }
}
