using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace EUGamesApp.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "О Минске";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://ru.wikipedia.org/wiki/%D0%9C%D0%B8%D0%BD%D1%81%D0%BA")));
        }

        public ICommand OpenWebCommand { get; }
    }
}