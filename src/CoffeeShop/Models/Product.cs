﻿using System;
namespace CoffeeShop.Models
{
    public class Product
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }

        public Product()
        {
        }
    }
}
