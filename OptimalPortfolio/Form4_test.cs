using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;


namespace OptimalPortfolio
{
    public partial class Form4_test : Form
    {
        List<Portfolio> results;
        static double[,] finalArray;
        static Asset[] selectedAssets;
        static double[] constraints;
        string path = Program.path + "test\\";
        DateTime[] weeks;
        LineItem index = null, sp = null;
        double[] x;
        int year = 2015;
        int count = 0;

        static Dictionary<double, double> profitYear = new Dictionary<double, double>();
        public Form4_test()
        {
            InitializeComponent();
        }

        public void DoGraphProfit(double[,] finalArray, Portfolio result)
        {
            zGC.GraphPane.CurveList.Clear();

            GraphPane pane = zGC.GraphPane;
            pane.Title.Text = "Доходность портфеля по неделям за " + (year + 1) + " год";
            zGC.GraphPane.YAxis.Title.Text = "Доходность (%)";
            zGC.GraphPane.XAxis.Title.Text = "Неделя";

            pane.XAxis.Scale.Min = 0;
            pane.XAxis.Scale.Max = 53;

            pane.CurveList.Clear();

            zGC.AxisChange();
            zGC.Invalidate();

            zGC.IsShowPointValues = true;

            x = new double[finalArray.GetLength(1)];
            double[] y = new double[finalArray.GetLength(1)];

            for (int i = 0; i < finalArray.GetLength(1); i++)
            {
                for (int j = 0; j < finalArray.GetLength(0); j++)
                {
                    y[i] += finalArray[j, i] * result.ConvertPortfolio()[j] * 100;
                }
                x[i] = i + 1;
                profitYear.Add(x[i], y[i]);
            }

            double[] y_profit = new double[y.Length];
            y_profit[0] = 0;
            for (int i = 1; i < y_profit.Length; i++)
            {
                y_profit[i] = ((y[i] / y[0]) - 1) * 100;
            }

            double t = (y[y.Length - 1] - y[0]) / y[0];

            label_profitFact.Text = Math.Round(t * 100, 2).ToString() + "%";

            double dd = 0, ddR = 0;
            dd = Drawdown(profitYear, out ddR);

            // label_ddMax.Text = dd.ToString();
            label_ddRel.Text = Math.Round(ddR, 2).ToString() + "%";

            LineItem line = pane.AddCurve("Портфель", x, y_profit, Color.Red);
            line.Symbol.Fill.Type = FillType.Solid;

            CurveList cl = pane.CurveList;
            zGC.AxisChange();
            zGC.Invalidate();
        }

        public static double Drawdown(Dictionary<double, double> dic, out double drowdownR)
        {
            double max1 = 0, max2 = 0, min = Double.MaxValue;
            List<double> drowdown = new List<double>();
            List<double> drowdownRel = new List<double>();
            for (int i = 1; i <= dic.Count; i++)
            {
                double current = 0;
                dic.TryGetValue(i, out current);
                if (max1 < current) max1 = current;
                else
                {
                    for (int j = i; j <= dic.Count; j++)
                    {
                        dic.TryGetValue(j, out current);
                        if (min > current) min = current;
                        if (max2 < current) max2 = current;
                        if (max2 > max1)
                        {
                            drowdown.Add(max1 - min);
                            drowdownRel.Add((max1 - min) / max1 * 100);
                            i = j - 1;
                            max1 = 0; max2 = 0; min = Double.MaxValue;
                            break;
                        }
                    }
                }
            }
            if (max1 != 0 && min < max1)
            {
                drowdown.Add(max1 - min);
                drowdownRel.Add((max1 - min) / max1 * 100);
            }
            if (drowdown.Count != 0)
            {
                drowdownR = drowdownRel.Max();
                return drowdown.Max();
            }
            else
            {
                drowdownR = 0;
                return 0;
            }
        }

        private void Form4_test_Load(object sender, EventArgs e)
        {
            comboBox_year.SelectedText = "2015";
            checkBox1_index.Enabled = false;
            checkBox_sp.Enabled = false;
            selectedAssets = new Asset[Program.form.dataGridView2.Rows.Count];
            constraints = new double[Program.form.dataGridView2.Rows.Count];
            
            int j = 0;
            foreach (DataGridViewRow t in Program.form.dataGridView2.Rows)
            {
                Asset a = (Asset)t.Cells[0].Value;
                selectedAssets[j] = a;
                constraints[j] = Convert.ToDouble(t.Cells[1].Value.ToString().Replace('.', ','));
                
                j++;
            }
            j = 0;
            dataGridView.Rows.Clear();
            dataGridView.Rows.Add(Program.form.dataGridView2.Rows.Count + 1);
            foreach (DataGridViewRow a in Program.form.dataGridView2.Rows)
            {
                Asset asset = (Asset)a.Cells[0].Value;
                
                dataGridView[0, j].Value = asset.ToString();
                j++;
            }
            dataGridView[0, j].Value = "СУММА";

            DoList();
            /*
            try
            {
                DoList();
            }
            catch (System.IO.IOException ex) 
            { 
                
                string[] exception = ex.Message.Split(' ');
                DialogResult dr = MessageBox.Show("Ошибка при считывании файла " + exception[exception.Length - 1] + ". Замените этот актив или попробуйте еще раз.\nПовторить попытку?",
                    "Ошибка!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (dr == System.Windows.Forms.DialogResult.Retry) Form4_test_Load(sender, e);
                else this.Close();
            }
            catch (Exception ex)
            {
                string[] exception = ex.Message.Split(' ');
                DialogResult dr = MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (dr == System.Windows.Forms.DialogResult.Retry) Form4_test_Load(sender, e);
                else this.Close();
            }*/
        }

        private void button_test_Click(object sender, EventArgs e)
        {

            //     ClassAssistant.DownloadAllAssets(selectedAssets, path, year+1, false);
            // Test();   
        }

        private async void Test()
        {
            this.Cursor = Cursors.WaitCursor;
            if (comboBox_test.SelectedItem == null) MessageBox.Show("Выберите значение", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                checkBox1_index.Checked = false;
                checkBox_sp.Checked = false;
                profitYear = new Dictionary<double, double>();
                string text = comboBox_test.SelectedItem.ToString();
                string[] t = text.Split(' ');
                t[1] = t[1].Remove(t[1].Length - 1);
                double prof = Convert.ToDouble(t[1]);
                double risk = Convert.ToDouble(t[2]);
                Portfolio result = null;

                foreach (var res in results)
                {
                    if (Math.Abs(res.Profit - prof) < 0.001 && Math.Abs(res.Risk - risk) < 0.001)
                    {
                        result = res;
                        int j = 0;

                        foreach (DataGridViewRow a in Program.form.dataGridView2.Rows)
                        {
                            Asset asset = (Asset)a.Cells[0].Value;
                            dataGridView[1, j].Value = res.ConvertPortfolio()[j] + "%";
                            j++;
                        }
                        dataGridView[1, j].Value = res.GetSum + "%";
                        // double st = ;
                        label_stand.Text = res.StandDev.ToString() + "%";
                        label_profitV.Text = prof + "%";
                        label_riskV.Text = risk + "%";
                       // label_cost.Text = string.Format("{0:###,###.##} руб.", Math.Round(res.Cost));
                    }
                }
                await DownloadTask(selectedAssets, path, year + 1);
                try
                {
                    finalArray = ClassAssistant.ReadData(selectedAssets, path);
                    weeks = ClassAssistant.DateTimeArray(selectedAssets, path);
                    checkBox1_index.Enabled = true;
                    checkBox_sp.Enabled = true;

                    DoGraphProfit(finalArray, result);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }//button_test_Click(sender, e); }
            }
            this.Cursor = Cursors.Default;
            dataGridView.Cursor = Cursors.Default;
        }

        private string zGC_PointValueEvent(ZedGraphControl sender, GraphPane pane, CurveItem curve, int iPt)
        {
            PointPair point = curve[iPt];

            string result = string.Format("Неделя: {0}\nДоходность: {1:F2}%", point.X, point.Y);
            return result;
        }
        private Task DownloadTask(Asset[] selectedAssets, string path, int period)
        {
            return Task.Run(() =>
            {
                ClassAssistant.DownloadAllAssets(selectedAssets, path, period, false);
            });
        }

        public async void DoList()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                int j = 0;
                comboBox_test.Items.Clear();

                //ClassAssistant.DownloadAllAssets(selectedAssets, path, year, false);

                await DownloadTask(selectedAssets, path, year);

                finalArray = ClassAssistant.ReadData(selectedAssets, path);

                double start = -0.02, finish = 1, step = 0.001;
                results = ClassAssistant.DoListPortfolio(finalArray, selectedAssets, start, finish, step, constraints);

                if (results.Count == 0)
                {
                    MessageBox.Show("Решения не найдены", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
                else
                {
                    j = 1;
                    foreach (var t in results)
                    {
                        comboBox_test.Items.Add(j + ": " + t.Profit.ToString() + "; " + t.Risk.ToString());
                        j++;
                    }
                }
                dataGridView.Cursor = Cursors.Default;
                this.Cursor = Cursors.Default;
            }
            catch (System.IO.IOException ex)
            {

                string[] exception = ex.Message.Split(' ');
                count++;
                if (count == 3)
                {
                   // DialogResult dr = MessageBox.Show("Нет данных для " + exception[exception.Length - 1] + ". Замените этот актив.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DialogResult dr = MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    count = 0;
                    if (dr == System.Windows.Forms.DialogResult.OK) this.Close();
                }
                else
                    DoList();
            }
            catch (Exception ex)
            {
                string[] exception = ex.Message.Split(' ');
                DialogResult dr = MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (dr == System.Windows.Forms.DialogResult.Retry) DoList();//Form4_test_Load(sender, e);
                // else this.Close();
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            year = Convert.ToInt32(comboBox_year.SelectedItem.ToString());
            //  comboBox_test.SelectedIndex = -1;
            zGC.GraphPane.CurveList.Clear();
            checkBox1_index.Checked = false;
            checkBox_sp.Checked = false;
            checkBox1_index.Enabled = false;
            checkBox_sp.Enabled = false;
            DoList();
        }

        private void checkBox1_index_CheckedChanged(object sender, EventArgs e)
        {
            GraphPane pane = zGC.GraphPane;

            if (checkBox1_index.Checked)
            {
                Asset[] a = new Asset[1];
                a[0] = new Asset("MICEXINDEXCF", "MICEX", 13851);
                ClassAssistant.DownloadAllAssets(a, path, year + 1, false);
                Dictionary<double, double> profitIndex = new Dictionary<double, double>();
                double[] y = ClassAssistant.ReadAssets(path + a[0].Ticker + ".txt", weeks);
                for (int i = 0; i < y.Length; i++)
                {
                    profitIndex.Add(x[i], y[i]);
                }

                double[] y_profit = new double[y.Length];
                y_profit[0] = 0;
                for (int i = 1; i < y_profit.Length; i++)
                {
                    y_profit[i] = ((y[i] / y[0]) - 1) * 100;
                }

                double t = (y[y.Length - 1] - y[0]) / y[0];
                double ddr = 0;
                Drawdown(profitIndex, out ddr);

                label_i.Visible = true;
                label_indProfit.Text = Math.Round(t * 100, 2).ToString() + "%";
                label_indDrowdown.Text = Math.Round(ddr, 2).ToString() + "%";

                index = pane.AddCurve("ММВБ", x, y_profit, Color.Blue, SymbolType.Square);
                index.Symbol.Fill.Type = FillType.Solid;
                CurveList cl = pane.CurveList;
                zGC.AxisChange();
                zGC.Invalidate();
            }
            else
            {
                pane.CurveList.Remove(index);
                zGC.AxisChange();
                zGC.Invalidate();
                label_i.Visible = false;
                label_indProfit.Text = "";
                label_indDrowdown.Text = "";
            }
        }

        private void comboBox_test_SelectedIndexChanged(object sender, EventArgs e)
        {
            Test();
        }

        private void label_std_Click(object sender, EventArgs e)
        {

        }

        private void checkBox_sp_CheckedChanged(object sender, EventArgs e)
        {
            GraphPane pane = zGC.GraphPane;

            if (checkBox_sp.Checked)
            {
                Dictionary<double, double> profit = new Dictionary<double, double>();

                double[] y = new double[finalArray.GetLength(1)];

                for (int i = 0; i < finalArray.GetLength(1); i++)
                {
                    for (int j = 0; j < finalArray.GetLength(0); j++)
                    {
                        y[i] += finalArray[j, i];
                    }
                    y[i] /= finalArray.GetLength(0);
                    y[i] *= 100;
                    profit.Add(x[i], y[i]);
                }

                double[] y_profit = new double[y.Length];
                y_profit[0] = 0;
                for (int i = 1; i < y_profit.Length; i++)
                {
                    y_profit[i] = ((y[i] / y[0]) - 1) * 100;
                }

                double t = (y[y.Length - 1] - y[0]) / y[0];
                double ddr = 0;
                Drawdown(profit, out ddr);

                label_sp.Visible = true;
                label_spP.Text = Math.Round(t * 100, 2).ToString() + "%";
                label_spDD.Text = Math.Round(ddr, 2).ToString() + "%";

                sp = pane.AddCurve("ЕП", x, y_profit, Color.Green, SymbolType.Square);
                sp.Symbol.Fill.Type = FillType.Solid;

                CurveList cl = pane.CurveList;
                zGC.AxisChange();
                zGC.Invalidate();
            }
            else
            {
                label_sp.Visible = false;
                label_spDD.Text = "";
                label_spP.Text = "";

                pane.CurveList.Remove(sp);
                zGC.AxisChange();
                zGC.Invalidate();
            }
        }

        private async void dataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                double sum = 0;
                double[] w = new double[dataGridView.Rows.Count - 1];
                for (int i = 0; i < dataGridView.Rows.Count - 1; i++)
                {
                    try
                    {
                        w[i] = Convert.ToDouble(dataGridView[1, i].Value.ToString());
                        sum += w[i];
                    }
                    catch (FormatException) { MessageBox.Show("Неверный формат числа!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error); break; }
                }
                dataGridView[1, dataGridView.Rows.Count - 1].Value = sum + "%";
                if (dataGridView[1, dataGridView.Rows.Count - 1].Value.ToString() == "100%")
                {
                    await DownloadTask(selectedAssets, path, year + 1);
                    try
                    {
                        for (int i = 0; i < dataGridView.Rows.Count - 1; i++)
                        {
                            dataGridView[1, i].Value = dataGridView[1, i].Value.ToString() + "%";
                        }
                        finalArray = ClassAssistant.ReadData(selectedAssets, path);
                        weeks = ClassAssistant.DateTimeArray(selectedAssets, path);
                        checkBox1_index.Enabled = true;
                        checkBox_sp.Enabled = true;

                        Portfolio p = new Portfolio(w, 0, 0);
                      //  p.Cost = CalculationClass.PortfolioCost(finalArray, p);

                       // label_cost.Text = string.Format("{0:###,###.##} руб.", Math.Round(p.Cost));
                        profitYear = new Dictionary<double, double>();
                        DoGraphProfit(finalArray, p);
                        dataGridView.Columns[1].ReadOnly = true;
                        label2.Visible = false;
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                }
                else MessageBox.Show("Сумма долей должна быть равна 100%!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_edit_Click(object sender, EventArgs e)
        {
            dataGridView.Columns[1].ReadOnly = false;
            label2.Visible = true;
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                dataGridView[1, i].Value = "";
            }
            label_profitV.Text = "";
            label_riskV.Text = "";
            label_stand.Text = "";
        }
    }
}
