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
                SubTitle="The name of the company is based on the movie",
                Description="Humanity runs on coffee but even a bad cup of coffee is better than no coffee at all. What goes best with an cup of coffee another cup. The most dangerous drinks game is seeing how long I can go without coffee.",
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
