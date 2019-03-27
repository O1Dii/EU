using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EUGamesApp.ViewModels;

namespace EUGamesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Tabs : TabbedPage
    {
        public void Change() { CurrentPage = Children[1]; }

        public Tabs()
        {
            InitializeComponent();
            
            BarBackgroundColor = Color.FromHex("#50f0c169");
            BarTextColor = Color.FromHex("#390f5c");
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            AnimatedButton.counter = 0;
        }


    }
}