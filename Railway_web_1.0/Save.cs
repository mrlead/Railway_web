using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Railway_web_1._0
{
    public static class Save
    {
        public static string from_name;
        public static string to_name;
        public static List<MainForm.Train> selected_trains = new List<MainForm.Train>();
        public static int selected_train_indx;
        public static DateTime low = DateTime.Now;
        public static DateTime high = DateTime.Now;
        public static List<MainForm.Train> trains = new List<MainForm.Train>();
        public static List<string> station_name = new List<string>();
    }
}