using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OptimalPortfolio
{
    public partial class Form5_cor : Form
    {
        static double[,] finalArray;
        static Asset[] selectedAssets;
        int count = 0;
        public Form5_cor()
        {
            InitializeComponent();
        }
        public void FillTable(double[,] finalArray)
        {
            double[] average = CalculationClass.AverageProfitability(finalArray);
            for (int i = 0; i < selectedAssets.Length; i++)
            {
                for (int j = 0; j<i+1; j++)
                {
                    double result = Math.Round(CalculationClass.Cor(finalArray, average, i, j), 4);
                    dataGridView[j + 1, i].Value = result;
                    if (result == 1) dataGridView[j + 1, i].Style.BackColor = Color.IndianRed;
                    else
                    {
                        if (result < 0) dataGridView[j + 1, i].Style.BackColor = Color.LightGreen;
                        else dataGridView[j + 1, i].Style.BackColor = Color.Coral;
                    }
                }
            }
        }

        private void Form5_cor_Load(object sender, EventArgs e)
        {
            //ClassAssistant.DownloadAllAssets(selectedAssets, path, Program.form.trackBar_period.Value, false);
            Correlation();
        }

        private Task DownloadTask(Asset[] selectedAssets, string path, int period)
        {
            return Task.Run(() =>
            {
                ClassAssistant.DownloadAllAssets(selectedAssets, path, period, false);
            });
        }

        private async void Correlation()
        {
            this.Cursor = Cursors.WaitCursor;
            selectedAssets = new Asset[Program.form.dataGridView2.Rows.Count];
            int j = 0;
            foreach (DataGridViewRow t in Program.form.dataGridView2.Rows)
            {
                Asset a = (Asset)t.Cells[0].Value;
                selectedAssets[j] = a;
                j++;
            }
            string path = Program.path + "cor\\";

            await DownloadTask(selectedAssets, path, Program.form.trackBar_period.Value);

            try
            {
                finalArray = ClassAssistant.ReadData(selectedAssets, path);

                dataGridView.Columns.Add("colName", "Актив");
                for (int i = 0; i < selectedAssets.Length; i++)
                {
                    dataGridView.Columns.Add(selectedAssets[i].Ticker, selectedAssets[i].Name);
                    dataGridView.Rows.Add(selectedAssets[i].Name);
                }
                this.FillTable(finalArray);
                for(int i = 0;  i < dataGridView.Columns.Count; i++)
                {
                    dataGridView.Columns[i].Width = 60;
                }
                this.Cursor = Cursors.Default;
            }
            catch (System.IO.IOException ex)
            {
                //Form5_cor_Load(sender, e); 
                string[] exception = ex.Message.Split(' ');
             /*   DialogResult dr = MessageBox.Show("Ошибка при считывании файла " + exception[exception.Length - 1] + ". Замените этот актив или попробуйте еще раз.\nПовторить попытку?",
                    "Ошибка!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (dr == System.Windows.Forms.DialogResult.Retry) Correlation();
                else this.Close();
              */
                count++;
                if (count == 3)
                {
                    DialogResult dr = MessageBox.Show("Ошибка при считывании файла " + exception[exception.Length - 1] + ". Замените этот актив.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    count = 0;
                    if (dr == System.Windows.Forms.DialogResult.OK) this.Close();
                }
                else
                    Correlation();
            }
            catch (Exception ex)
            {
                string[] exception = ex.Message.Split(' ');
                DialogResult dr = MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (dr == System.Windows.Forms.DialogResult.Retry) Correlation();
                else this.Close();
            }
            
        }
    }
}
