using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace CoffeeShop.Models
{
    public class Basket
    {
        public Dictionary<Product, int> Products;
        public Basket()
        {
            Products = new Dictionary<Product, int>();
        }

        public Product this[string ProductId]
        {
            get
            {
                return Products.Keys.FirstOrDefault(p => p.Id.Equals(ProductId));
            }
        }
    }
}
