using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeShop.Data;
using CoffeeShop.Models;

namespace CoffeeShop.Services
{
    public class ProductRepository : IProductRepository
    {
        public ProductRepository()
        {
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await Task.FromResult(ProductData.TestProducts);
        }
        public async Task<Product> GetProductByIdAsync(string productId)
        {
            return await Task.FromResult(ProductData.TestProducts.FirstOrDefault(p => p.Id.Equals(productId)));
        }
    }
}
