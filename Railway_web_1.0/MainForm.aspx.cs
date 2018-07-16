using ExcelLibrary.SpreadSheet;
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
        class Train
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

        string conn_string = "Server=127.0.0.1; Port=5432; User Id=postgres; Password=632123; Database=postgres";
        string sql = "select * from trainlist_view";
        List<string> station_name = new List<string>();
        List<Train> train_list = new List<Train>();
        List<Train> selected_trains = new List<Train>();
        Train tr = new Train();

        protected void Page_Load(object sender, EventArgs e)
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

            station_name.Sort();
            Reset_list(cb_from);
            Reset_list(cb_to);
            cb_from.SelectedIndex = 0;
            cb_to.SelectedIndex = 0;
            Init_train();
        }

        //Разбиение списка на отдельные поезда
        private void Init_train()
        {
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
                train_list.Add(train);
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
            for (int i = 0; i < station_name.Count; i++)
            {
                combo.Items.Add(station_name[i]);
            }
        }

        //Отсеивание неуникальных названий станций
        private bool Unique(string new_name)
        {
            string trimmed = new_name.Trim();
            foreach (string item in station_name)
            {
                if (item == trimmed)
                    return false;
            }
            station_name.Add(trimmed);
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
                foreach (string item in station_name)
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
                bEnter.Enabled = cb_to.Enabled & cb_from.Enabled;
            }
        }

        protected void tb_to_TextChanged(object sender, EventArgs e)
        {
            try
            {
                cb_to.Enabled = true;
                cb_to.Items.Clear();
                Regex reg = new Regex(@"^" + tb_to.Text, RegexOptions.IgnoreCase);
                foreach (string item in station_name)
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
                bEnter.Enabled = cb_to.Enabled & cb_from.Enabled;
            }
        }

        protected void bEnter_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("num");
            dt.Columns.Add("name_from");
            dt.Columns.Add("name_to");
            dt.Columns.Add("time_from");
            dt.Columns.Add("time_to");

            for (int i = 0; i < train_list.Count; i++)
            {
                dt.Rows.Add(tr.num[i], tr.station[i], tr.station[i], tr.from_time[i], tr.to_time[i]);
            }

            dg.DataSource = dt;
            dg.DataBind();
            /*string from = cb_from.Items[cb_from.SelectedIndex].ToString();
            string to = cb_to.Items[cb_to.SelectedIndex].ToString();
            if (from == to)
            {
                //MessageBox.Show("Пункты отправки и прибытия не должны совпадать");
                return;
            }
            int k = 0;
            int i = 0;
            selected_trains.Clear();
            //dg.Rows.Clear();
            iteration:
            for (; i < train_list.Count; i++)
            {
                for (int j = 0; j < train_list[i].station.Count; j++)
                {
                    if (train_list[i].station[j] == from)
                    {
                        for (j += 1; j < train_list[i].station.Count; j++)
                        {
                            if (train_list[i].station[j] == to && DateTime.Parse(train_list[i].start_date[j]) <= low && (train_list[i].end_date[j] == null || DateTime.Parse(train_list[i].end_date[j]) >= high))
                            {
                                dg.Rows.Add();
                                dg.Rows[k].Cells[0].Value = UniqNum(train_list[i]);
                                dg.Rows[k].Cells[1].Value = from;
                                dg.Rows[k].Cells[2].Value = to;
                                dg.Rows[k].Cells[3].Value = train_list[i].from_time[train_list[i].station.IndexOf(from)];
                                dg.Rows[k].Cells[4].Value = train_list[i].to_time[train_list[i].station.IndexOf(to)];
                                dg.Rows[k].Cells[5].Value = train_list[i].date_diff[0];
                                dg.Rows[k].Cells[6].Value = train_list[i].start_date[0];
                                dg.Rows[k++].Cells[7].Value = train_list[i].end_date[0];
                                selected_trains.Add(train_list[i]);
                                i++;
                                goto iteration;
                            }
                        }
                    }
                }
            }
            /*if (dg.RowCount == 1)
            {
                MessageBox.Show("Отсутствуют пригородные поезда");
            }*/
        }

        /*private void bToday_Click(object sender, EventArgs e)
        {
            low = high = DateTime.Now;
            date_low.Value = date_high.Value = DateTime.Now;
        }

        private void date_low_ValueChanged(object sender, EventArgs e)
        {
            low = date_low.Value;
        }

        private void date_high_ValueChanged(object sender, EventArgs e)
        {
            high = date_high.Value;
            // (-1) из-за участии в сравнении ещё и времени
            high = high.AddDays(-1);
        }

        private void bAllTrains_Click(object sender, EventArgs e)
        {
            selected_trains.Clear();
            dg.Rows.Clear();
            int j = 0;
            for (int i = 0; i < train_list.Count; i++)
            {
                if (DateTime.Parse(train_list[i].start_date[0]) <= low && (train_list[i].end_date[0] == null || DateTime.Parse(train_list[i].end_date[0]) >= high))
                {
                    dg.Rows.Add();
                    dg.Rows[j].Cells[0].Value = UniqNum(train_list[i]);
                    dg.Rows[j].Cells[1].Value = train_list[i].station[0];
                    dg.Rows[j].Cells[2].Value = train_list[i].station[train_list[i].station.Count - 1];
                    dg.Rows[j].Cells[3].Value = train_list[i].from_time[0];
                    dg.Rows[j].Cells[4].Value = train_list[i].to_time[train_list[i].to_time.Count - 1];
                    dg.Rows[j].Cells[5].Value = train_list[i].date_diff[0];
                    dg.Rows[j].Cells[6].Value = train_list[i].start_date[0];
                    dg.Rows[j++].Cells[7].Value = train_list[i].end_date[0];
                    selected_trains.Add(train_list[i]);
                }
            }
        }*/

    }
}