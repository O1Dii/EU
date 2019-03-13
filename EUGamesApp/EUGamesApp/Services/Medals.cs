using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using EUGamesApp.Models;

namespace EUGamesApp.Services
{
    public class Medals
    {
        public ObservableCollection<Country> Countries;

        public Medals()
        {
            Countries = new ObservableCollection<Country>();
            var mockItems = new ObservableCollection<Country>
            {
                new Country { name = "Япония", gold = "5", silver = "6", bronze = "0", total = "11" },
                new Country { name = "Россия", gold = "0", silver = "3", bronze = "6", total = "9" },
                new Country { name = "Беларусь", gold = "3", silver = "2", bronze = "1", total = "6" },
                new Country { name = "Китай", gold = "0", silver = "0", bronze = "3", total = "3" },
                new Country { name = "Германия", gold = "0", silver = "1", bronze = "1", total = "2" }
            };

            foreach (var item in mockItems)
            {
                Countries.Add(item);
            }
        }


    }
}