using EUGamesApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using EUGamesApp.Views;

namespace EUGamesApp.ViewModels
{
    public class NearPlacesViewModel : BaseViewModel
    {
        public ObservableCollection<NearPlace> Items
        {
            get
            {
                ObservableCollection<NearPlace> temp = new ObservableCollection<NearPlace>();
                var temp_1 = new EventsViewModel().tempPlaces;
                foreach (Xamarin.Forms.GoogleMaps.Pin item in MapPage.nearbyPins)
                {
                    //if (Math.Sqrt(Math.Pow((item.Position.Latitude - MapPage.lastKnownLocation.Latitude), 2) + Math.Pow((item.Position.Longitude - MapPage.lastKnownLocation.Longitude), 2)) < Math.Pow(Setting.radius, 2))
                    //{
                    if (item.IsVisible == true)
                    {
                        var a = new NearPlace(item.Label, item.Label + ".png", 0, item.Position.Latitude, item.Position.Longitude);
                        foreach (var position in temp_1)
                        {
                            if(a.x == position.x)
                            {
                                a.type = position.type;
                            }
                        }
                        temp.Add(a);
                    }
                    //}
                }
                return temp;
            }
            set { }
        }

        public NearPlacesViewModel()
        {
            Items = new ObservableCollection<NearPlace>();
            //nearPlaces = new List<NearPlace>()
            //{
            //};
        }
    }
}
