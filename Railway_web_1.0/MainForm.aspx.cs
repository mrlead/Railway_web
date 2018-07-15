using ExcelLibrary.SpreadSheet;
using System;
using System.Collections.Generic;
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
        }

        List<string> station_name = new List<string>();
        List<Train> train_list = new List<Train>();
        List<Train> selected_trains = new List<Train>();
        Workbook book;
        Worksheet sheets;
        Train tr = new Train();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                book = Workbook.Load("C:\\1.xls");
            }
            catch
            {
                //MessageBox.Show("Ошибка чтения файла. Обратитесь к администратору.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //InitializeComponent();
            sheets = book.Worksheets[0];
            // Подключение к Excel-файлу
            Read_column(station_name, 3, true);
            Read_column(tr.station, 3, false);
            Read_column(tr.num, 0, false);
            Read_column(tr.unum, 1, false);
            Union(tr.from_time, 6, 7);
            Union(tr.to_time, 4, 5);

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
                    train.num.Add(tr.num[i]);
                    train.unum.Add(tr.unum[i]);
                    train.station.Add(tr.station[i]);
                    train.from_time.Add(tr.from_time[i]);
                    train.to_time.Add(tr.to_time[i]);
                }
                train_list.Add(train);
            }
        }

        //Объединение данных времени
        private void Union(List<string> list, int col_hour, int col_minute)
        {
            List<string> hour = new List<string>();
            List<string> minute = new List<string>();

            for (int i = 0; i < sheets.Cells.Rows.Count - 1; i++)
            {
                Read_column(hour, col_hour, false);
                Read_column(minute, col_minute, false);
                list.Add((hour[i].Length == 1 ? "0" + hour[i] : hour[i]) + ":" + (minute[i].Length == 1 ? "0" + minute[i] : minute[i]));
            }
        }

        //Считывание с Excel
        private void Read_column(List<string> list, int column, bool unique)
        {
            if (unique)
            {
                for (int i = 1; i < sheets.Cells.Rows.Count; i++)
                {
                    Unique(sheets.Cells[i, column].Value.ToString().Trim());
                }
            }
            else
            {
                for (int i = 1; i < sheets.Cells.Rows.Count; i++)
                {
                    list.Add(sheets.Cells[i, column].Value.ToString().Trim());
                }
            }
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
            foreach (string item in station_name)
            {
                if (item == new_name)
                    return false;
            }
            station_name.Add(new_name);
            return true;
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

        ///Обработка нажатия кнопки "Ввод"
        /*private void bEnter_Click(object sender, System.EventArgs e)
        {
            string from = cb_from.Items[cb_from.SelectedIndex].ToString();
            string to = cb_to.Items[cb_to.SelectedIndex].ToString();
            if (from == to)
            {
                //MessageBox.Show("Пункты отправки и прибытия не должны совпадать");
                return;
            }
            int k = 0;
            selected_trains.Clear();
            dg.Rows.Clear();
            for (int i = 0; i < train_list.Count; i++)
            {
                iteration:
                for (int j = 0; j < train_list[i].station.Count; j++)
                {
                    if (train_list[i].station[j] == from)
                    {
                        for (j += 1; j < train_list[i].station.Count; j++)
                        {
                            if (train_list[i].station[j] == to)
                            {
                                dg.Rows.Add();
                                dg.Rows[k].Cells[0].Value = train_list[i].num[0] == train_list[i].num[train_list[i].num.Count - 1] ? train_list[i].num[0] : train_list[i].num[0] + "/" + train_list[i].num[train_list[i].num.Count - 1];
                                dg.Rows[k].Cells[1].Value = from;
                                dg.Rows[k].Cells[2].Value = to;
                                dg.Rows[k].Cells[3].Value = train_list[i].from_time[train_list[i].station.IndexOf(from)];
                                dg.Rows[k++].Cells[4].Value = train_list[i].to_time[train_list[i].station.IndexOf(to)];
                                selected_trains.Add(train_list[i]);
                                i++;
                                goto iteration;
                            }
                        }
                    }
                }
            }
            if (dg.RowCount == 1)
            {
                //MessageBox.Show("Отсутствуют пригородные поезда");
            }
        }

        //Выбор поезда из главной таблицы
        private void dg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dg_1.Rows.Clear();
            int k = 0;
            for (int i = 0; i < selected_trains[dg.SelectedRows[0].Index].station.Count; i++)
            {
                dg_1.Rows.Add();
                dg_1.Rows[k].Cells[0].Value = selected_trains[dg.SelectedRows[0].Index].station[i];
                if (i != 0)
                    dg_1.Rows[k].Cells[1].Value = selected_trains[dg.SelectedRows[0].Index].to_time[i];
                if (i != selected_trains[dg.SelectedRows[0].Index].station.Count - 1)
                    dg_1.Rows[k++].Cells[2].Value = selected_trains[dg.SelectedRows[0].Index].from_time[i];
            }
        }*/
    }
}