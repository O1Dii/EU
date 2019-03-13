using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace EUGamesApp.Models
{
    public class InfoList
    {
        public ObservableCollection<InfoElement> list { get; set; }
        public string header { get; set; }
        public string count
        {
            get
            {
                var temp = this.list.Count * 50 + 61;
                if(temp < 100)
                {
                    temp = this.list.Count * 50 + 61;
                }
                return temp.ToString();
            }
            set
            { }
        }

        public InfoList(ObservableCollection<InfoElement> list, string header)
        {
            this.list = list;
            this.header = header;
        }
    }
}
