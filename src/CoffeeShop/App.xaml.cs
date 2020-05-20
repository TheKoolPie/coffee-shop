using CoffeeShop.Services;
using CoffeeShop.ViewModels;
using CoffeeShop.ViewModels.Base;
using CoffeeShop.Views;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CoffeeShop
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            InitNavigation();
        }

        private Task InitNavigation()
        {
            var navigationService = ViewModelLocator.Resolve<INavigationService>();
            return navigationService.InitializeAsync();
        }

        protected override void OnStart()
        {

        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
