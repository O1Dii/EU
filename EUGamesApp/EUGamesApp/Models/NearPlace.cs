using System;
using System.Collections.Generic;
using System.Text;

namespace EUGamesApp.Models
{
    public class NearPlace
    {
        public string name { get; set; }
        public string image { get; set; }
        public int type { get; set; }
        public double x { get; set; }
        public double y { get; set; }

        public NearPlace(string name, string image, int type, double x, double y)
        {
            this.name = name;
            this.image = image;
            this.type = type;
            this.x = x;
            this.y = y;
        }
    }
}
