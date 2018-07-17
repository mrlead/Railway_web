using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Railway_web_1._0
{
    public static class Save
    {
        public static int from_name;
        public static int to_name;
        public static List<MainForm.Train> list = new List<MainForm.Train>();
        public static int selected_train_indx;
        public static DateTime low = DateTime.Now;
        public static DateTime high = DateTime.Now;
    }
}