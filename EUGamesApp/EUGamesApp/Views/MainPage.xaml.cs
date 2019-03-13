using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using EUGamesApp.Models;
using EUGamesApp.Services;
using System.Collections.Generic;
using EUGamesApp.ViewModels;

namespace EUGamesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : Xamarin.Forms.TabbedPage
    {
        public Tabs _1;
        public MapPage _2;
        public MenuPage _3;

        private Stack<int> prev;
        private int temp;
        private bool back;

        public void ChangeTab(int num, double x = 0, double y = 0)
        {
            CurrentPage = Children[num];
            if (num == 0)
            {
                _1.Change();
            }
            else if(num == 1)
            {
                _2.ZoomToPoint(x, y);
            }
        }

        public void reCalculatePins()
        {
            _2.reCalculatePins();
        }

        protected override bool OnBackButtonPressed()
        {
            if (prev.Count != 0)
            {
                temp = prev.Pop();
                back = true;
                CurrentPage = Children[temp];
                return true;
            }
            else
            {
                base.OnBackButtonPressed();
                return true;
            }
        }




        private void timer()
        {
            Device.StartTimer(TimeSpan.FromSeconds(20), () =>
            {
                _2.reCalculatePins();
                return true;
            });
        }


        public MainPage()
        {
            InitializeComponent();
            prev = new Stack<int>();
            temp = 1;
            _1 = new Tabs() { Icon = "Places.png" };
            _1.Appearing += ColorChange_1;
            Screen.TabSizePixels = _1.getTabbarSize();
            Screen.TabSize = (int)(Screen.TabSizePixels / Screen.Density);
            _3 = new MenuPage() { Icon = "Menu.png" };
            _3.Appearing += ColorChange_3;
            _2 = new MapPage() { Icon = "Map.png" };

            _2.Appearing += ColorChange_2;
            Tabs.Children.Add(_1);
            Tabs.Children.Add(_2);
            Tabs.Children.Add(_3);
            CurrentPage = Children[0];
            CurrentPage = Children[1];
            Tabs.Opacity = 0;
            Tabs.FadeTo(1, 2500);
            this.On<Android>().SetIsSwipePagingEnabled(false);
        }

        private void ColorChange_1(object sender, EventArgs e)
        { 
            Tabs.BarBackgroundColor = Color.FromHex("#e6b685"); //#7f4aa5
            Tabs.BarTextColor = Color.FromHex("#6e29b3");
            On<Android>().SetBarSelectedItemColor(Color.FromHex("#964fa8"));
            On<Android>().SetBarItemColor(Color.FromHex("#6e29b3"));
            Timer_Elapsed(1);
            if (!back)
            {
                prev.Push(temp);
                temp = 0;
            }
            else
            {
                back = false;
            }
        }
        private void ColorChange_2(object sender, EventArgs e)
        {
            Tabs.BarBackgroundColor = Color.FromHex("#e8c690"); //#66bb6a
            Tabs.BarTextColor = Color.FromHex("#372e70");
            On<Android>().SetBarSelectedItemColor(Color.FromHex("#6d5eab"));
            On<Android>().SetBarItemColor(Color.FromHex("#372e70"));
            Timer_Elapsed(2);
            if (!back)
            {
                prev.Push(temp);
                temp = 1;
            }
            else
            {
                back = false;
            }
        }
        private void ColorChange_3(object sender, EventArgs e)
        {
            Tabs.BarBackgroundColor = Color.FromHex("#6cb5f5"); //#2196f3
            Tabs.BarTextColor = Color.FromHex("#6b3825");
            On<Android>().SetBarSelectedItemColor(Color.FromHex("#a37764"));
            On<Android>().SetBarItemColor(Color.FromHex("#6b3825"));
            Timer_Elapsed(3);
            if (!back)
            {
                prev.Push(temp);
                temp = 2;
            }
            else
            {
                back = false;
            }
}

        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();
        //}


        void Timer_Elapsed(int color)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                var currentNavPage = (Xamarin.Forms.Application.Current.MainPage as NavigationPage);
                var statusBarStyleManager = DependencyService.Get<IStatusBarStyleManager>();
                if (color == 1)
                {
                    statusBarStyleManager.SetLightTheme();
                }
                else if(color == 2)
                {
                    statusBarStyleManager.SetMiddleTheme();
                }
                else
                {
                    statusBarStyleManager.SetDarkTheme();
                }
            });
        }
    }
}