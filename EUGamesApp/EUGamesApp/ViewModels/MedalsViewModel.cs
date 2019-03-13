using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

using Xamarin.Forms;

using EUGamesApp.Models;
using EUGamesApp.Services;

namespace EUGamesApp.ViewModels
{
    public class MedalsViewModel : BaseViewModel, INotifyPropertyChanged
    {
        Medals medals;

        public ObservableCollection<Country> Items { get; set; }
        public MedalsViewModel()
        {
            medals = new Medals();
            Items = medals.Countries;
            Title = "Медальный зачёт";
        }

        public void sort(int flag)
        {
            int a = 0;
            switch (flag)
            {
                case 0:
                    if (Setting.byDec)
                        Items = new ObservableCollection<Country>(Items.OrderByDescending(x => x.name).ToList());
                    else
                        Items = new ObservableCollection<Country>(Items.OrderBy(x => x.name).ToList());
                    break;
                case 1:
                    if (Setting.byDec)
                        Items = new ObservableCollection<Country>(Items.OrderBy(x => Int32.Parse(x.gold)).ToList());
                    else
                        Items = new ObservableCollection<Country>(Items.OrderByDescending(x => Int32.Parse(x.gold)).ToList());
                    break;
                case 2:
                    if (Setting.byDec)
                        Items = new ObservableCollection<Country>(Items.OrderBy(x => Int32.Parse(x.silver)).ToList());
                    else
                        Items = new ObservableCollection<Country>(Items.OrderByDescending(x => Int32.Parse(x.silver)).ToList());
                    break;
                case 3:
                    if (Setting.byDec)
                        Items = new ObservableCollection<Country>(Items.OrderBy(x => Int32.Parse(x.bronze)).ToList());
                    else
                        Items = new ObservableCollection<Country>(Items.OrderByDescending(x => Int32.Parse(x.bronze)).ToList());
                    break;
                case 4:
                    if (Setting.byDec)
                        Items = new ObservableCollection<Country>(Items.OrderBy(x => Int32.Parse(x.total)).ToList());
                    else
                        Items = new ObservableCollection<Country>(Items.OrderByDescending(x => Int32.Parse(x.total)).ToList());
                    break;
            }
            OnPropertyChanged("Items");
        }
    }
}
