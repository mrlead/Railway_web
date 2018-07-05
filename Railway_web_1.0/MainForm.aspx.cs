using System;
using System.Collections.Generic;

namespace Railway_web_1._0
{
    public partial class MainForm : System.Web.UI.Page
    {
        class Train
        {
            public List<string> num = new List<string>();
            public List<string> unum = new List<string>();
            public List<string> station = new List<string>();
            public List<string> from_time = new List<string>();
            public List<string> to_time = new List<string>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}