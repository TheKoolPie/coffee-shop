using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace CoffeeShop.CustomViews
{
    public partial class Stepper : ContentView
    {
        public static readonly BindableProperty QuantityDecreaseCommandProperty =
            BindableProperty.Create("QuantityDecreaseCommand", typeof(ICommand),typeof(Stepper), null);

        public ICommand QuantityDecreaseCommand
        {
            get { return (ICommand)GetValue(QuantityDecreaseCommandProperty); }
            set { SetValue(QuantityDecreaseCommandProperty, value); }
        }

        public static readonly BindableProperty QuantityIncreaseCommandProperty =
            BindableProperty.Create("QuantityIncreaseCommand", typeof(ICommand), typeof(Stepper), null);

        public ICommand QuantityIncreaseCommand
        {
            get { return (ICommand)GetValue(QuantityIncreaseCommandProperty); }
            set { SetValue(QuantityIncreaseCommandProperty, value); }
        }

        public static readonly BindableProperty QuantityProperty =
            BindableProperty.Create("Quantity", typeof(int),typeof(Stepper), null);

        public int Quantity
        {
            get { return (int)GetValue(QuantityProperty);}
            set { SetValue(QuantityProperty, value); }
        }

        public Stepper()
        {
            InitializeComponent();
        }
    }
}
