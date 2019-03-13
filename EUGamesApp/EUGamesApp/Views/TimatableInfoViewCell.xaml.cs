using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using EUGamesApp.Models;
using System.Collections.ObjectModel;
using EUGamesApp.ViewModels;

namespace EUGamesApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TimatableInfoViewCell : ViewCell
	{

        //public static readonly BindableProperty CountProperty =
        //BindableProperty.Create("Count", typeof(string), typeof(TimatableInfoViewCell), "");
        //public string Count
        //{
        //    get { return (string)GetValue(CountProperty); }
        //    set { SetValue(CountProperty, value); }
        //}

        //public static readonly BindableProperty DateCountProperty =
        //BindableProperty.Create("DateCount", typeof(string), typeof(TimatableInfoViewCell), "");
        //public string DateCount
        //{
        //    get { return (string)GetValue(DateCountProperty); }
        //    set { SetValue(DateCountProperty, value); }
        //}

        //public static readonly BindableProperty ItemsCountProperty =
        //BindableProperty.Create("ItemsCount", typeof(string), typeof(TimatableInfoViewCell), "");
        //public string ItemsCount
        //{
        //    get { return (string)GetValue(ItemsCountProperty); }
        //    set { SetValue(ItemsCountProperty, value); }
        //}

        public TimatableInfoViewCell ()
		{
			InitializeComponent (); //new EventsViewModel().Items[Int32.Parse(ItemsCount)].date[Int32.Parse(DateCount)].infoList[Int32.Parse(Count)].list.Count * EventsList.RowHeight;
		}
	}
}