using System;

namespace EUGamesApp.Models
{
    public class Setting
    {
        public static int radius { get; set; }
        public static int sortedField { get; set; }
        public static bool byDec { get; set; }

        static Setting()
        {
            radius = 0;
        }
    }
}
