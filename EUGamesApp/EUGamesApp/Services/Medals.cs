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
                new Country { name = AppResources.Austria, gold = "5", silver = "6", bronze = "0", total = "11" },
                new Country { name = AppResources.Azerbaijan, gold = "0", silver = "3", bronze = "6", total = "9" },
                new Country { name = AppResources.Albania, gold = "3", silver = "2", bronze = "1", total = "6" },
                new Country { name = AppResources.Andorra, gold = "0", silver = "0", bronze = "3", total = "3" },
                new Country { name = AppResources.Armenia, gold = "0", silver = "1", bronze = "1", total = "2" },
                new Country { name = AppResources.Belarus, gold = "0", silver = "0", bronze = "0", total = "0" },
                new Country { name = AppResources.Belgium, gold = "0", silver = "0", bronze = "0", total = "0" },
                new Country { name = AppResources.Bulgaria, gold = "0", silver = "0", bronze = "0", total = "0" },
                new Country { name = AppResources.BosniaAndHerzegovina, gold = "0", silver = "0", bronze = "0", total = "0" },
                new Country { name = AppResources.UnitedKingdom, gold = "0", silver = "0", bronze = "0", total = "0" },
                new Country { name = AppResources.Hungary, gold = "0", silver = "0", bronze = "0", total = "0" },
                new Country { name = AppResources.Germany, gold = "0", silver = "0", bronze = "0", total = "0" },
                new Country { name = AppResources.Greece, gold = "0", silver = "0", bronze = "0", total = "0" },
                new Country { name = AppResources.Georgia, gold = "0", silver = "0", bronze = "0", total = "0" },
                new Country { name = AppResources.Denmark, gold = "0", silver = "0", bronze = "0", total = "0" },
                new Country { name = AppResources.Israel, gold = "0", silver = "0", bronze = "0", total = "0" },
                new Country { name = AppResources.Ireland, gold = "0", silver = "0", bronze = "0", total = "0" },
                new Country { name = AppResources.Iceland, gold = "0", silver = "0", bronze = "0", total = "0" },
                new Country { name = AppResources.Spain, gold = "0", silver = "0", bronze = "0", total = "0" },
                new Country { name = AppResources.Italy, gold = "0", silver = "0", bronze = "0", total = "0" },
                new Country { name = AppResources.Cyprus, gold = "0", silver = "0", bronze = "0", total = "0" },
                new Country { name = AppResources.Kosovo, gold = "0", silver = "0", bronze = "0", total = "0" },
                new Country { name = AppResources.Latvia, gold = "0", silver = "0", bronze = "0", total = "0" },
                new Country { name = AppResources.Lithuania, gold = "0", silver = "0", bronze = "0", total = "0" },
                new Country { name = AppResources.Liechtenstein, gold = "0", silver = "0", bronze = "0", total = "0" },
                new Country { name = AppResources.Luxembourg, gold = "0", silver = "0", bronze = "0", total = "0" },
                new Country { name = AppResources.Macedonia, gold = "0", silver = "0", bronze = "0", total = "0" },
                new Country { name = AppResources.Malta, gold = "0", silver = "0", bronze = "0", total = "0" },
                new Country { name = AppResources.Moldova, gold = "0", silver = "0", bronze = "0", total = "0" },
                new Country { name = AppResources.Monaco, gold = "0", silver = "0", bronze = "0", total = "0" },
                new Country { name = AppResources.Netherlands, gold = "0", silver = "0", bronze = "0", total = "0" },
                new Country { name = AppResources.Norway, gold = "0", silver = "0", bronze = "0", total = "0" },
                new Country { name = AppResources.Poland, gold = "0", silver = "0", bronze = "0", total = "0" },
                new Country { name = AppResources.Portugal, gold = "0", silver = "0", bronze = "0", total = "0" },
                new Country { name = AppResources.Russia, gold = "0", silver = "0", bronze = "0", total = "0" },
                new Country { name = AppResources.Romania, gold = "0", silver = "0", bronze = "0", total = "0" },
                new Country { name = AppResources.SanMarino, gold = "0", silver = "0", bronze = "0", total = "0" },
                new Country { name = AppResources.Serbia, gold = "0", silver = "0", bronze = "0", total = "0" },
                new Country { name = AppResources.Slovakia, gold = "0", silver = "0", bronze = "0", total = "0" },
                new Country { name = AppResources.Slovenia, gold = "0", silver = "0", bronze = "0", total = "0" },
                new Country { name = AppResources.Turkey, gold = "0", silver = "0", bronze = "0", total = "0" },
                new Country { name = AppResources.Ukraine, gold = "0", silver = "0", bronze = "0", total = "0" },
                new Country { name = AppResources.Finland, gold = "0", silver = "0", bronze = "0", total = "0" },
                new Country { name = AppResources.France, gold = "0", silver = "0", bronze = "0", total = "0" },
                new Country { name = AppResources.Croatia, gold = "0", silver = "0", bronze = "0", total = "0" },
                new Country { name = AppResources.Montenegro, gold = "0", silver = "0", bronze = "0", total = "0" },
                new Country { name = AppResources.CzechRepublic, gold = "0", silver = "0", bronze = "0", total = "0" },
                new Country { name = AppResources.Switzerland, gold = "0", silver = "0", bronze = "0", total = "0" },
                new Country { name = AppResources.Sweden, gold = "0", silver = "0", bronze = "0", total = "0" },
                new Country { name = AppResources.Estonia, gold = "0", silver = "0", bronze = "0", total = "0" },
            };

            foreach (var item in mockItems)
            {
                Countries.Add(item);
            }
        }


    }
}