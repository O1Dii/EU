namespace EUGamesApp.Views
{
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    using EUGamesApp.Services;
    using System;
    using Xamarin.Forms.Maps;
    using System.Collections.Generic;
    using EUGamesApp.Models;
    using Plugin.Toast;
    using EUGamesApp.ViewModels;
    using System.ComponentModel;

    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NearPlaces : ContentPage
    {
        private StackLayout _panel;
        private StackLayout _panel_temp;
        private ScrollView _scroll;
        private static int _radius;

        public NearPlaces ()
		{
			InitializeComponent ();

            //_panel_temp = new StackLayout
            //{
            //    BackgroundColor = Color.FromHex("#F3E5F5")
            //};
            //CreatePanel();

            //this.Content = _panel_temp;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = new NearPlacesViewModel();
        }

        //private void CreatePanel()
        //{
        //    if (_panel == null)
        //    {
        //        _panel = new StackLayout
        //        {
        //            Children = {
        //                //new Label {
        //                //    Text = "Достопримечательности",
        //                //    HorizontalOptions = LayoutOptions.Start,
        //                //    VerticalOptions = LayoutOptions.Start,
        //                //    XAlign = TextAlignment.Center,
        //                //    FontSize = 20
        //                //},
        //                new AnimatedButton ("памятник Франциску Скорине", "monument.png", "100", "3", callback: () => {

        //                    //ChangeBackgroundColor();
        //                }),
        //                new AnimatedButton ("памятник Ефросинье Полоцкой", "monument.png", "100", "3", callback: () => {

        //                })
        //            },
        //            Padding = 15,
        //            VerticalOptions = LayoutOptions.FillAndExpand,
        //            HorizontalOptions = LayoutOptions.EndAndExpand
        //        };

        //        _scroll = new ScrollView()
        //        {
        //            Orientation = ScrollOrientation.Vertical,
        //            Content = _panel,
        //        };

        //        _panel_temp.Children.Add(_scroll);
        //    }
        //}


        //public void update()
        //{
        //    if (_radius != Setting.radius)
        //    {
        //        _radius = Setting.radius;
        //        _panel.Children.Clear();
        //        if (_radius >= 0)
        //        {
        //            _panel.Children.Add(
        //                new AnimatedButton("Памятник Франциску Скорине", "monument.png", "100", "3", callback: () =>
        //                {

        //                })
        //            );
        //            _panel.Children.Add(
        //                new AnimatedButton("Памятник Ефросинье Полоцкой", "monument.png", "100", "3", callback: () =>
        //                {

        //                })
        //            );
        //        }
        //        if (_radius >= 300)
        //        {
        //            _panel.Children.Add(
        //                new AnimatedButton("Михайловский сквер", "park.png", "300", "7", callback: () =>
        //                {

        //                })
        //            );
        //            _panel.Children.Add(
        //                new AnimatedButton("Бобруйский сквер", "park.png", "300", "7", callback: () =>
        //                {

        //                })
        //            );
        //        }
        //        if (_radius >= 500)
        //        {
        //            _panel.Children.Add(
        //                new AnimatedButton("Памятный камень Мясникову", "monument.png", "500", "10", callback: () =>
        //                {

        //                })
        //            );
        //            _panel.Children.Add(
        //                new AnimatedButton("Костёл Святых Симеона и Святой Елены", "culture.png", "500", "10", callback: () =>
        //                {

        //                })
        //            );
        //        }
        //        OnPropertyChanged("_scroll");
        //    }
        //}

        //protected override void OnAppearing()
        //{
        //    update();
        //}
    }
}