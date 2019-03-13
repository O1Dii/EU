using EUGamesApp.ViewModels;
using Plugin.Toast;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EUGamesApp.Models;

namespace EUGamesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MedalsPage : ContentPage
    {
        MedalsViewModel viewModel;

        private int temp;

        public MedalsPage()
        {
            InitializeComponent();

            viewModel = new MedalsViewModel();

            viewModel.sort(Setting.sortedField);

            BindingContext = viewModel;
        }

        private void onGridPressed(object sender, EventArgs args)
        {
            //CrossToastPopUp.Current.ShowToastMessage("hui");
            if ((ContentView)sender == _0)
            {
                temp = 0;
            }
            else if ((ContentView)sender == _1)
            {
                temp = 1;
            }
            else if ((ContentView)sender == _2)
            {
                temp = 2;
            }
            else if ((ContentView)sender == _3)
            {
                temp = 3;
            }
            else
            {
                temp = 4;
            }

            if (Setting.sortedField == temp)
            {
                Setting.byDec = !Setting.byDec;
            }
            else
            {
                Setting.sortedField = temp;
                Setting.byDec = false;
            }

            viewModel.sort(temp);

            this.BindingContext = viewModel;

        }
    }
}