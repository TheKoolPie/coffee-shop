using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Services
{
    public interface IDisplayAlertService
    {
        Task DisplayAlert(string title, string message, string cancel);
        Task<bool> DisplayAlert(string title, string message, string accept, string cancel);
        Task<string> DisplayActionSheet(string title, string cancel, string destruction, params string[] buttons);
    }
}
