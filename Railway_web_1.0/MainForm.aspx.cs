using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;

namespace Railway_web_1._0
{
    public partial class MainForm : System.Web.UI.Page
    {
        public class Train
        {
            public List<string> num = new List<string>();
            public List<string> unum = new List<string>();
            public List<string> station = new List<string>();
            public List<string> from_time = new List<string>();
            public List<string> to_time = new List<string>();
            public List<string> date_diff = new List<string>();
            public List<string> start_date = new List<string>();
            public List<string> end_date = new List<string>();
        }

        string conn_string = "Server=127.0.0.1; Port=5432; User Id=postgres; Password=1236321; Database=postgres";
        string sql = "select * from trainlist_view";
        Train tr = new Train();
        DataTable dt = new DataTable();
        DataTable dt_1 = new DataTable();
        string from;
        string to;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (NpgsqlConnection cn = new NpgsqlConnection(conn_string))
                {
                    cn.Open();
                    using (NpgsqlCommand comm = new NpgsqlCommand(sql, cn))
                    {
                        NpgsqlDataReader reader = comm.ExecuteReader();
                        while (reader.Read())
                        {
                            Unique(reader.GetString(2));
                            tr.num.Add(reader.GetInt32(0).ToString());
                            tr.unum.Add(reader.GetInt32(1).ToString());
                            tr.station.Add(reader.GetString(2));
                            Union(tr.to_time, reader.GetInt16(3).ToString(), reader.GetInt16(4).ToString());
                            Union(tr.from_time, reader.GetInt16(5).ToString(), reader.GetInt16(6).ToString());
                            try { tr.date_diff.Add(reader.GetInt16(7).ToString()); }
                            catch { tr.date_diff.Add("0"); }
                            tr.start_date.Add(reader.GetDate(8).ToString());
                            try { tr.end_date.Add(reader.GetDate(9).ToString()); }
                            catch { tr.end_date.Add(null); }
                        }
                    }
                }
                Save.station_name.Sort();
                Reset_list(cb_from);
                Reset_list(cb_to);
                try
                {
                    cb_from.SelectedIndex = cb_from.Items.IndexOf(new ListItem(Save.from_name));
                }
                catch
                {
                    cb_from.SelectedIndex = 0;
                }
                try
                {
                    cb_to.SelectedIndex = cb_to.Items.IndexOf(new ListItem(Save.from_name));
                }
                catch
                {
                    cb_to.SelectedIndex = 0;
                }
                Init_train();
            } 
        }

        //Разбиение списка на отдельные поезда
        private void Init_train()
        {
            Save.trains.Clear();
            for (int i = 0; i < tr.unum.Count;)
            {
                Train train = new Train();
                string unum_mem = tr.unum[i];
                for (; i < tr.unum.Count && tr.unum[i] == unum_mem; i++)
                {
                    if (i + 1 < tr.unum.Count && tr.station[i] == tr.station[i + 1])
                    {
                        train.num.Add(tr.num[i + 1]);
                        train.unum.Add(tr.unum[i]);
                        train.station.Add(tr.station[i]);
                        train.from_time.Add(tr.from_time[i + 1]);
                        train.to_time.Add(tr.to_time[i]);
                        train.date_diff.Add(tr.date_diff[i]);
                        train.start_date.Add(tr.start_date[i]);
                        train.end_date.Add(tr.end_date[i]);
                        i++;
                    }
                    else
                    {
                        train.num.Add(tr.num[i]);
                        train.unum.Add(tr.unum[i]);
                        train.station.Add(tr.station[i]);
                        train.from_time.Add(tr.from_time[i]);
                        train.to_time.Add(tr.to_time[i]);
                        train.date_diff.Add(tr.date_diff[i]);
                        train.start_date.Add(tr.start_date[i]);
                        train.end_date.Add(tr.end_date[i]);
                    }
                }
                //train_list.Add(train);
                Save.trains.Add(train);
            }
        }

        //Объединение данных времени
        private void Union(List<string> list, string h, string m)
        {
            list.Add((h.Length == 1 ? "0" + h : h) + ":" + (m.Length == 1 ? "0" + m : m));
        }

        //Перезапись списка
        private void Reset_list(DropDownList combo)
        {
            combo.Items.Clear();
            for (int i = 0; i < Save.station_name.Count; i++)
            {
                combo.Items.Add(Save.station_name[i]);
            }
        }

        //Отсеивание неуникальных названий станций
        private bool Unique(string new_name)
        {
            string trimmed = new_name.Trim();
            foreach (string item in Save.station_name)
            {
                if (item == trimmed)
                    return false;
            }
            Save.station_name.Add(trimmed);
            return true;
        }

        private string UniqNum(Train t)
        {
            string mem = t.num[0];
            for (int i = 1; i < t.num.Count; i++)
            {
                if (t.num[i] != mem)
                    return mem + "/" + t.num[i];
            }
            return mem;
        }

        protected void tb_from_TextChanged(object sender, EventArgs e)
        {
            try
            {
                cb_from.Enabled = true;
                cb_from.Items.Clear();
                Regex reg = new Regex(@"^" + tb_from.Text, RegexOptions.IgnoreCase);
                foreach (string item in Save.station_name)
                {
                    if (reg.Match(item).Success)
                    {
                        cb_from.Items.Add(item);
                    }
                }
                cb_from.SelectedIndex = 0;
            }
            catch
            {
                cb_from.Items.Add("Совпадений не найдено");
                cb_from.SelectedIndex = 0;
                cb_from.Enabled = false;
            }
            finally
            {
                Save.from_name = cb_from.SelectedValue;
                bEnter.Enabled = cb_to.Enabled & cb_from.Enabled;
            }
        }

        public void tb_to_TextChanged(object sender, EventArgs e)
        {
            try
            {
                cb_to.Enabled = true;
                cb_to.Items.Clear();
                Regex reg = new Regex(@"^" + tb_to.Text, RegexOptions.IgnoreCase);
                foreach (string item in Save.station_name)
                {
                    if (reg.Match(item).Success)
                    {
                        cb_to.Items.Add(item);
                    }
                }
                cb_to.SelectedIndex = 0;
            }
            catch
            {
                cb_to.Items.Add("Совпадений не найдено");
                cb_to.SelectedIndex = 0;
                cb_to.Enabled = false;
            }
            finally
            {
                Save.to_name = cb_to.SelectedValue;
                bEnter.Enabled = cb_to.Enabled & cb_from.Enabled;
            }
        }

        protected void bEnter_Click(object sender, EventArgs e)
        {
            dt.Columns.Add("№ поезда");
            dt.Columns.Add("Пункт отправки");
            dt.Columns.Add("Пункт прибытия");
            dt.Columns.Add("Время отпр.");
            dt.Columns.Add("Время приб.");
            dt.Columns.Add("Разница дат");
            dt.Columns.Add("Дата начала курсир.");
            dt.Columns.Add("Дата окончания курсир.");

            from = cb_from.SelectedValue;
            to = cb_to.SelectedValue;

            if (from == to)
            {
                //MessageBox.Show("Пункты отправки и прибытия не должны совпадать");
                return;
            }
            int i = 0;
            Save.selected_trains.Clear();
            dt.Rows.Clear();
            iteration:
            for (; i < Save.trains.Count; i++)
            {
                for (int j = 0; j < Save.trains[i].station.Count; j++)
                {
                    if (Save.trains[i].station[j] == from)
                    {
                        for (j += 1; j < Save.trains[i].station.Count; j++)
                        {
                            if (Save.trains[i].station[j] == to && DateTime.Parse(Save.trains[i].start_date[j]) <= Save.low && (Save.trains[i].end_date[j] == null || DateTime.Parse(Save.trains[i].end_date[j]) >= Save.high))
                            {
                                DataRow workRow = dt.NewRow();
                                workRow[0] = UniqNum(Save.trains[i]);
                                workRow[1] = from;
                                workRow[2] = to;
                                workRow[3] = Save.trains[i].from_time[Save.trains[i].station.IndexOf(from)];
                                workRow[4] = Save.trains[i].to_time[Save.trains[i].station.IndexOf(to)];
                                workRow[5] = Save.trains[i].date_diff[0];
                                workRow[6] = Save.trains[i].start_date[0];
                                workRow[7] = Save.trains[i].end_date[0];
                                dt.Rows.Add(workRow);
                                Save.selected_trains.Add(Save.trains[i]);
                                i++;
                                goto iteration;
                            }
                        }
                    }
                }
            }
            if (dt.Rows.Count == 1)
            {
                //MessageBox.Show("Отсутствуют пригородные поезда");
                return;
            }
            dg.DataSource = dt;
            dg.DataBind();

        }

        protected void dg_SelectedIndexChanged(object sender, EventArgs e)
        {   
            dt_1.Rows.Clear();
            dt_1.Columns.Add("Пункт");
            dt_1.Columns.Add("Время приб.");
            dt_1.Columns.Add("Время отпр.");
            int index = dg.SelectedIndex;

            label3.Text = null;
            try
            {
                for (int i = 0; i < Save.selected_trains[index].station.Count; i++)
                {
                    DataRow workRow = dt_1.NewRow();
                    workRow[0] = Save.selected_trains[index].station[i];
                    if (i != 0)
                        workRow[1] = Save.selected_trains[index].to_time[i];
                    if (i != Save.selected_trains[index].station.Count - 1)
                        workRow[2] = Save.selected_trains[index].from_time[i];
                    dt_1.Rows.Add(workRow);
                }
                label3.Text = "Поезд \"" + Save.selected_trains[index].station[0] + "-" + Save.selected_trains[index].station[Save.selected_trains[index].station.Count - 1] + "\"";
                dg_1.DataSource = dt_1;
                dg_1.DataBind();
            }
            catch { }
        }

        protected void cb_to_SelectedIndexChanged(object sender, EventArgs e)
        {
            Save.to_name = cb_to.SelectedValue;
        }

        protected void cb_from_SelectedIndexChanged(object sender, EventArgs e)
        {
            Save.from_name = cb_from.SelectedValue;
        }

        protected void dg_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        { 
            Save.selected_train_indx = dg.SelectedIndex;
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            Save.low = Save.high = DateTime.Now;
            date_low.SelectedDate = date_high.SelectedDate = DateTime.Now;
        }

        protected void date_low_SelectionChanged(object sender, EventArgs e)
        {
            Save.low = date_low.SelectedDate;
        }

        protected void date_high_SelectionChanged(object sender, EventArgs e)
        {
            Save.high = date_high.SelectedDate;
            // (-1) из-за участия в сравнении ещё и времени
            Save.high = Save.high.AddDays(-1);
        }
    }
}