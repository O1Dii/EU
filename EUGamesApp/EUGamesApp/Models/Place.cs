using System;
using System.Collections.Generic;
using System.Text;

namespace EUGamesApp.Models
{
    public class Place
    {
        public double x { get; set; }
        public double y { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public int type { get; set; }
        public string xy {
            get
            {
                return x.ToString() + " " + y.ToString();
            }
            set { }
        }

        public Place(double x, double y, string name, string address, int type)
        {
            this.x = x;
            this.y = y;
            this.name = name;
            this.address = address;
            this.type = type;
        }
    }
}
