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
    public partial class Form3_graph : Form
    {
        //static List<double[]> results;
        static List<Portfolio> results;
        static double[,] finalArray;
        static Asset[] selectedAssets;
        static double[] constraints;
        double step = 0.001, start = -0.1, finish = 1;
        int count = 0;
        Portfolio sp = null;
/*
        public static void DoGraph(double start, double finish, double step)
        {
            double r = 0, p = 0;
            while (start <= finish)
            {
                Portfolio result = ClassAssistant.DoCalculations(finalArray, selectedAssets, start, false);

                if (result.Profit == p && result.Risk == r)
                    break;
                else
                {
                    if (start > result.Profit)
                    {
                        break;
                    }
                    else
                    {
                        double t = Math.Truncate(result.Profit / step);
                        start = step * t + step;
                    }
                   // start += step;
                    p = result.Profit;
                    r = result.Risk;
                    double sum = 0;
                    for (int k = 0; k < result.ConvertPortfolio().Length; k++)
                    {
                        result.ConvertPortfolio()[k] = Math.Round(result.ConvertPortfolio()[k], 4) * 100;
                    }
                    result.Profit = Math.Round(result.Profit, 4) * 100;
                    result.Risk = Math.Round(result.Risk, 4) * 100;
                    sum = result.GetSum;
                    if (Math.Abs(sum - 100) <= 0.1)
                        results.Add(result);
                    if (results.Count > 100) break;
                }
            }
        }
 */

        public Form3_graph()
        {
            InitializeComponent();
        }
        public Form3_graph(double start, double finish, double step)
        {
            InitializeComponent();
            this.start = start;
            this.finish = finish;
            this.step = step;
        }

        private void Form3_graph_Load(object sender, EventArgs e)
        {
            LoadForm();
        }

        private Task DownloadTask(Asset[] selectedAssets, string path, int period)
        {
            return Task.Run(() =>
                {
                    ClassAssistant.DownloadAllAssets(selectedAssets, path, period, false);
                });
        }

        private async void LoadForm()
        {
            this.Cursor = Cursors.WaitCursor;

            zGC.GraphPane.CurveList.Clear();

            GraphPane pane = zGC.GraphPane;
            pane.Title.Text = "Граница эффективных портфелей";
            zGC.GraphPane.YAxis.Title.Text = "Доходность (%)";
            zGC.GraphPane.XAxis.Title.Text = "Риск (%)";
            zGC.GraphPane.XAxis.Scale.Min = -0.1;

            label_step.Text = "0.1%";

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
            await DownloadTask(selectedAssets, Program.path, Program.form.trackBar_period.Value);
           // ClassAssistant.DownloadAllAssets(selectedAssets, Program.path, Program.form.trackBar_period.Value, false);

            try
            {
                finalArray = ClassAssistant.ReadData(selectedAssets, Program.path);

                sp = ClassAssistant.SinglePortfolio(finalArray);
                
                DoEffectiveLine();
                if (results.Count != 0)
                    DoTable(results.Last());
                this.Cursor = Cursors.Default;
                dataGridView.Cursor = Cursors.Default;
            }
            catch (System.IO.IOException ex)
            {
                string[] exception = ex.Message.Split(' ');
              //  DialogResult dr = MessageBox.Show("Ошибка при считывании файла " + exception[exception.Length - 1] + ". Замените этот актив или попробуйте еще раз.\nПовторить попытку?",
              //      "Ошибка!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
              //  if (dr == System.Windows.Forms.DialogResult.Retry) LoadForm();
              //  else this.Close();
                count++;
                if (count == 3)
                {
                   // DialogResult dr = MessageBox.Show("Ошибка при считывании файла " + exception[exception.Length - 1] + ". Замените этот актив.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DialogResult dr = MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    count = 0;
                    if (dr == System.Windows.Forms.DialogResult.OK) this.Close();
                }
                else
                    LoadForm();
            }
            catch (Exception ex)
            {
                string[] exception = ex.Message.Split(' ');
                DialogResult dr = MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (dr == System.Windows.Forms.DialogResult.Retry) LoadForm();
                else this.Close();
            }
            
        }

        private void button_drow_Click(object sender, EventArgs e)
        {
            DoEffectiveLine();
            if (results.Count != 0)
                DoTable(results.Last());
        }

        public void DoEffectiveLine()
        {
            try
            {
                results = new List<Portfolio>(); //new List<double[]>();

                
                if (start == 0) start = step;
                if (start > finish) finish = 1;

                results = ClassAssistant.DoListPortfolio(finalArray, selectedAssets, start, finish, step, constraints);

                GraphPane gp = zGC.GraphPane;
                gp.CurveList.Clear();

                zGC.AxisChange();
                zGC.Invalidate();

                if (results.Count == 0)
                {
                    MessageBox.Show("Решения для данных параметров не найдены", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    zGC.IsShowPointValues = true;

                    double[] x = new double[results.Count];
                    double[] y = new double[results.Count];
                    int i = 0;
                    foreach (var a in results)
                    {
                        x[i] = a.Risk;
                        y[i] = a.Profit;
                        i++;
                    }
                    LineItem line = gp.AddCurve("Эффективная граница", x, y, Color.Red);
                    line.Symbol.Fill.Type = FillType.Solid;

                    CurveList cl = gp.CurveList;
                    zGC.AxisChange();
                    zGC.Invalidate();

                    double[] xSP = new double[1];
                    double[] ySP = new double[1];
                    xSP[0] = sp.Risk;
                    ySP[0] = sp.Profit;
                    LineItem lineSP = gp.AddCurve("ЕП", xSP, ySP, Color.Blue);
                    lineSP.Symbol.Fill.Type = FillType.Solid;

                    cl = gp.CurveList;
                    zGC.AxisChange();
                    zGC.Invalidate();
                    label_.Text = "Портфели: " + Convert.ToString(results.Count);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Неверный формат числа!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
         
        private string zGC_PointValueEvent(ZedGraphControl sender, GraphPane pane, CurveItem curve, int iPt)
        {
            PointPair point = curve[iPt];

            //double[] res = new double[results.ElementAt(0).ConvertPortfolio().Length];
            Portfolio p = sp;
            foreach(var t in results)
            {
                if (t.Profit == point.Y && t.Risk == point.X) p = t;
            }
            DoTable(p);

            string result = string.Format("Риск: {0:F2}%\nДоходность: {1:F2}%", point.X, point.Y);
            return result;
        }

        private void zGC_CursorChanged(object sender, EventArgs e)
        {
            if (!zGC.Capture)
            {
                zGC.Cursor = Cursors.Arrow;
            }
        }
        public void DoTable(Portfolio res)
        {
            int j = 0;
            double sum = 0;
            dataGridView.Rows.Clear();
            dataGridView.Rows.Add(Program.form.dataGridView2.Rows.Count + 1);
            foreach (DataGridViewRow a in Program.form.dataGridView2.Rows)
            {
                Asset asset = (Asset)a.Cells[0].Value;
                dataGridView[0, j].Value = asset.ToString();
                dataGridView[1, j].Value = res.ConvertPortfolio()[j] + "%";
                j++;
            }
            sum = res.GetSum;
            dataGridView[1, j].Value = sum + "%";
            label_stand.Text = res.StandDev + "%";
            label_profitValue.Text = res.Profit + "%";
            label_riskValue.Text = res.Risk + "%";
           // label_cost.Text =string.Format("{0:###,###.##} руб.", Math.Round(res.Cost));
        }

        private void button_max_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            step *= 10;
            label_step.Text = (step * 100) + "%";
            button_min.Enabled = true;
            if (step == 0.1) button_max.Enabled = false;
            DoEffectiveLine();
            if (results.Count != 0)
                DoTable(results.Last());
            this.Cursor = Cursors.Default;
        }

        private void button_min_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            step /= 10;
            label_step.Text = (step * 100) + "%";
            button_max.Enabled = true;
            if (step == 0.0001) button_min.Enabled = false;
            DoEffectiveLine();
            if (results.Count != 0)
                DoTable(results.Last());
            this.Cursor = Cursors.Default;

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
