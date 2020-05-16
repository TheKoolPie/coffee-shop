using System;
using Xamarin.Forms;

namespace CoffeeShop.Effects
{
    public class BaseCoffeeShopEffect : RoutingEffect
    {
        public BaseCoffeeShopEffect(string name) : base($"CoffeeShop.{name}")
        {
        }
    }
}
