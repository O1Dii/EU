﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EUGamesApp.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace EUGamesApp
{
    public partial class App : Application
    {
        public static Page mainPage {
            get;
            set;
        }
        public App()
        {
            InitializeComponent();

            mainPage = MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        public static Page getMainPage()
        {
            return mainPage;
        }
    }
}