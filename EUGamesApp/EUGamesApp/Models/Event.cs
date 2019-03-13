using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace EUGamesApp.Models
{
    public class Event
    {
        public string icon { get; set; }
        public string name { get; set; }
        public Place place { get; set; }
        public ObservableCollection<Date> date { get; set; }

        public string count
        {
            get
            {
                double c = 0;
                while (c == 0)
                {
                    foreach (var elem in date)
                    {
                        c += Double.Parse(elem.count);
                    }
                }
                c = Math.Round(c);
                c += 2;
                return c.ToString();
            }
            set
            { }
        }

        public Event(string icon, string name, Place place, ObservableCollection<Date> date)
        {
            this.icon = icon;
            this.name = name;
            this.place = place;
            this.date = date;
        }
    }
}
