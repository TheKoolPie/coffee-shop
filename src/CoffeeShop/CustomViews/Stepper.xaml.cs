using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace CoffeeShop.CustomViews
{
    public partial class Stepper : ContentView
    {
        public static readonly BindableProperty QuantityProperty =
            BindableProperty.Create("Quantity", typeof(int), typeof(Stepper), null, BindingMode.TwoWay, null, HandleQuantityPropertyChanged);

        private static void HandleQuantityPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            Console.Write(bindable);
        }

        public int Quantity
        {
            get { return (int)GetValue(QuantityProperty); }
            set
            {
                int newValue = value;
                BtnDecrease.IsEnabled = newValue > 0;
                SetValue(QuantityProperty, newValue);
            }
        }

        public Stepper()
        {
            InitializeComponent();
        }

        private void IncreaseQuantity(object sender, EventArgs e)
        {
            Quantity++;
        }
        private void DecreaseQuantity(object sender, EventArgs e)
        {
            Quantity--;
        }


    }
}
