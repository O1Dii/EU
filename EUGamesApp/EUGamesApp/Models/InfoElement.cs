using System;
using System.Collections.Generic;
using System.Text;

namespace EUGamesApp.Models
{
    public class InfoElement
    {
        public string name { get; set; }
        public string time { get; set; }
        public InfoElement(string name, string time)
        {
            this.name = name;
            this.time = time;
        }
    }
}
