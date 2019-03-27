using EUGamesApp.Models;
using Expandable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EUGamesApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TimetableNonExpandableViewCell : ViewCell
    {
        public TimetableNonExpandableViewCell()
        {
            InitializeComponent();
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var image = sender as Image;
            string xy = image.ClassId;
            var timetablePage = image.Parent.Parent.Parent.Parent.Parent.Parent.Parent as TimetablePage;
            var mainPage = App.getMainPage() as MainPage;
            string[] words = xy.Split(' ');
            double[] coords = { Double.Parse(words[0]), Double.Parse(words[1]) };
            mainPage.ChangeTab(1, coords[0], coords[1]);
            await Application.Current.MainPage.Navigation.PopModalAsync();
        }
    }
}