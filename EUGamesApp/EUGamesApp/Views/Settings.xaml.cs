using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EUGamesApp.Models;
using Xamarin.Forms.GoogleMaps;
using EUGamesApp.ViewModels;
using Plugin.Geolocator;
using Xamarin.Essentials;

namespace EUGamesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Settings : ContentPage
    {
        public Settings()
        {   
            InitializeComponent();
            mySlider.Value = Setting.radius;
            if (mySlider.Value == 0)
            {
                lblText.Text = "Ничего";
            }
            else if (mySlider.Value == 40)
            {
                lblText.Text = "Все";
            }
            else
            {
                lblText.Text = mySlider.Value.ToString();
            }

            lblText.TranslateTo((mySlider.Value) * ((mySlider.Width) / (mySlider.Maximum + 5)), 0, 10);
        }

        void Slider_ValueChanged(object sender, Xamarin.Forms.ValueChangedEventArgs e)
        {
            var newStep = Math.Round(e.NewValue / 10);
            mySlider.Value = newStep * 10;
            if (mySlider.Value == 0)
            {
                lblText.Text = "Ничего";
            }
            else if(mySlider.Value == 40)
            {
                lblText.Text = "Все";
            }
            else {
                lblText.Text = mySlider.Value.ToString();
            }
            
            //var parent = Parent.Parent as MainPage;
            //parent._2.reCalculatePins();
            lblText.TranslateTo((mySlider.Value) * ((mySlider.Width) / (mySlider.Maximum + 5)), 0, 10);
            Setting.radius = (int)newStep * 10;
        }


        protected override bool OnBackButtonPressed()
        {
            var mainPage = App.getMainPage() as MainPage;
            mainPage.reCalculatePins();
            AnimatedButton.tempList = (new NearPlacesViewModel()).Items;
            return base.OnBackButtonPressed();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            checkBox.Checked = MapPage.isMainPlacesTurnedOn;
        }

        private void CheckBox_CheckedChanged(object sender, XLabs.EventArgs<bool> e)
        {
            MapPage.isMainPlacesTurnedOn = e.Value;
        }
    }
}