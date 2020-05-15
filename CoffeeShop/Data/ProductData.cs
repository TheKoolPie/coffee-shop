using System;
using System.Collections.Generic;
using CoffeeShop.Models;

namespace CoffeeShop.Data
{
    public static class ProductData
    {
        public static List<Product> TestProducts = new List<Product>
        {
            new Product
            {
                Id="001",
                Title="Colombia Campo",
                Price = 104,
            },
            new Product
            {
                Id="002",
                Title="Broadcast Coffee",
                Price=104
            },
            new Product
            {
                Id="003",
                Title="Crossfade Blend",
                Price=98
            }
        };
    }
}
