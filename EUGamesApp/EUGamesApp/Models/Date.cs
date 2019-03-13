using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace EUGamesApp.Models
{
    public class Date
    {
        public string dt_str { get; set; }
        public ObservableCollection<InfoList> infoList { get; set; }
        public string count
        {
            get
            {
                double c = 0;
                while (c == 0)
                {
                    foreach (var elem in infoList)
                    {
                        c += Double.Parse(elem.count);
                    }
                }
                c = Math.Round(c);
                c += 61;
                return c.ToString();
            }
            set
            { }
        }

        public Date(string костыль, ObservableCollection<InfoList> infoList)
        {
            /* костыль смотреть 
             * EventsViewModel
             * date = new ObservableCollection<Date>
             *   {
             *      new Date(dates[0], infoList),
             *       new Date(dates[1],infoList)
             *   };
             * 
             */

            //this.dt = dt;
            this.dt_str = костыль;
            this.infoList = infoList;
        }
    }
}
