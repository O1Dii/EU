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
	public partial class TimetableViewCell : ViewCell
	{
        private int currentExtended;

        public TimetableViewCell()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            expandableView.StatusChanged += OnStatusChanged;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            expandableView.StatusChanged -= OnStatusChanged;
        }

        private async void OnStatusChanged(object sender, StatusChangedEventArgs e)
        {
            var rotation = -1;
            switch (e.Status)
            {
                case ExpandStatus.Collapsing:
                    rotation = 0;
                    break;
                case ExpandStatus.Expanding:
                    rotation = 180;
                    //var cur = sender as ExpandableView;
                    //var list = cur.Parent as ListView;
                    //var curExt = list.GetChildElements(new Point(currentExtended, 0)) as ExpandableView;
                    //curExt.StatusChanged -= OnStatusChanged;
                    break;
                default:
                    return;
            }

            await arrow.RotateTo(rotation, 250, Easing.Linear);
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