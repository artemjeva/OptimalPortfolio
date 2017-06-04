using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;


namespace OptimalPortfolio
{
    public partial class Form1 : Form
    {
        private static Asset[] assets;//= ClassAssistant.DoAssetsArray(Application.StartupPath + "\\assets.txt");
        private static Asset[][] arrayAssets = new Asset[10][];
        private List<Asset> list = new List<Asset>();
        bool isChange = false, isCalculate = false;
        int counter = 0;
        private static CancellationTokenSource cancelToken = new CancellationTokenSource();
        private static string dataPath;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                dataPath = Program.path + "\\data.txt";
                ClassAssistant.DownloadData(dataPath);

                dataGridView1.AllowUserToOrderColumns = true;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                assets = ClassAssistant.DoAssetsArray(Application.StartupPath + "\\assets.txt");
                list = assets.ToList<Asset>();
                list = list.OrderBy(x => x.Name).ToList();
                if (File.Exists(Application.StartupPath + "\\options.txt"))
                {
                    using (StreamReader sr = new StreamReader(Application.StartupPath + "\\options.txt",Encoding.GetEncoding(1251)))
                    {
                        string[] text = sr.ReadToEnd().Split('\n');
                        trackBar_period.Value = Convert.ToInt32(text[0].Split('=')[1]);
                        for (int i = 1; i < text.Length - 1; i++)
                        {
                            string[] line = text[i].Split(';');
                            foreach (var a in assets)
                            {
                                if (a.Name == line[0])
                                {
                                    dataGridView2.Rows.Add(a, Convert.ToDouble(line[1].Replace('.', ',')));
                                    list.Remove(a);
                                    break;
                                }
                            }
                        }
                    }
                }

                
                DoTable(list);
                try
                {
                    ClassAssistant.ReadCapitalization(list, 2017, Application.StartupPath);
                }
                catch (FileNotFoundException) { MessageBox.Show("Файл с данными о капитализации не найден!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                DoTable(list);
                
                RefreshParameters();

                if (dataGridView2.Rows.Count != 0 && dataGridView1.RowCount != 0)
                {
                    cancelToken.Cancel(true);
                    cancelToken = new CancellationTokenSource();
                    int i = 0;
                    Asset[] selected = new Asset[dataGridView2.Rows.Count];
                    foreach (DataGridViewRow t in dataGridView2.Rows)
                    {
                        Asset a = (Asset)t.Cells[0].Value;
                        selected[i] = a;
                        i++;
                    }
                    CorrelationTask(selected);
                }
            }
            catch (System.IO.FileNotFoundException)
            {
                MessageBox.Show("Файл с данными об акциях не найден!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DoTable(List<Asset> list)
        {
            try
            {
                if (dataGridView1.Rows.Count == 0)
                {
                    DoNewTable(list);
                }
                else
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        Asset a = (Asset)dataGridView1.Rows[i].Cells[0].Value;
                        foreach(var l in list)
                        {
                            if(l.Name == a.Name)
                            {
                                int cap = (int)Math.Round(l.Capitalization / 1000000);
                                dataGridView1.Rows[i].SetValues(l, l.Ticker, l.AverageProfit, l.Volatility, cap, l.Liquidity, l.Dividend, l.Correlation);
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void DoNewTable(List<Asset> list)
        {
            try
            {
                dataGridView1.Rows.Clear();
                int i = 1;
                foreach (var l in list)
                {
                    int cap = (int)Math.Round(l.Capitalization / 1000000);
                    dataGridView1.Rows.Add(l, l.Ticker, l.AverageProfit, l.Volatility, cap, l.Liquidity, l.Dividend, l.Correlation);
                    i++;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void button_add_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                DataGridViewSelectedRowCollection dt = dataGridView1.SelectedRows;
                    
                for (int i = 0; i < dt.Count; i++)
                {
                    Asset a = (Asset)dt[i].Cells[0].Value;
                    dataGridView2.Rows.Add(a, 100);
                    list.Remove(a);
                    dataGridView1.Rows.Remove(dt[i]);
                }
                //DoTable(list);
              //  dataGridView1.Rows.Remove(dt[0]);
                
               if (dataGridView2.Rows.Count != 0 && dataGridView1.RowCount != 0)
                {
                    cancelToken.Cancel(true);
                    cancelToken = new CancellationTokenSource();
                    int i = 0;
                    Asset[] selected = new Asset[dataGridView2.Rows.Count];
                    foreach (DataGridViewRow t in dataGridView2.Rows)
                    {
                        Asset a = (Asset)t.Cells[0].Value;
                        selected[i] = a;
                        i++;
                    }
                    CorrelationTask(selected);
                }
            }
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            
            if (dataGridView2.Rows.Count != 0)
            {
                DataGridViewSelectedRowCollection dt = dataGridView2.SelectedRows;

                for (int i = 0; i < dt.Count; i++)
                {
                    Asset a = (Asset)dt[i].Cells[0].Value;
                    list.Add((Asset)a);
                    dataGridView2.Rows.Remove(dt[i]);
                }
                list = list.OrderBy(x => x.Name).ToList();
                cancelToken.Cancel(true);
                cancelToken = new CancellationTokenSource();
                if (dataGridView2.Rows.Count == 0)
                {
                    for (int i = 0; i < list.Count; i++)
                        list[i].Correlation = 0;
                }
                else
                {
                    
                    if (dataGridView1.RowCount != 0)
                    {
                        int i = 0;
                        Asset[] selected = new Asset[dataGridView2.Rows.Count];
                        foreach (DataGridViewRow t in dataGridView2.Rows)
                        {
                            Asset a = (Asset)t.Cells[0].Value;
                            selected[i] = a;
                            i++;
                        }
                        CorrelationTask(selected);
                    }
                }                     
                DoNewTable(list);
            }
        }
       
        private Task VolatilityTask(string filename, List<Asset>[] listAssets, int period)
        {
            return Task.Run(() =>
            {
                /*
                for (int i = 0; i < assets.Length; i++)
                {
                    ClassAssistant.VolatilityResult(filename, assets[i], period);
                }
                 */
                try
                {
                    Task t1 = Task.Factory.StartNew(() =>
                    {
                        foreach (var l in listAssets[0])
                        {
                            double[] data = ClassAssistant.ReadNewData(filename, l, period);
                            ClassAssistant.VolatilityResult(l, data);
                            ClassAssistant.AverageProfit(l, data);
                        }
                    });

                    Task t2 = Task.Factory.StartNew(() =>
                    {
                        foreach (var l in listAssets[1])
                        {
                            double[] data = ClassAssistant.ReadNewData(filename, l, period);
                            ClassAssistant.VolatilityResult(l, data);
                            ClassAssistant.AverageProfit(l, data);
                        }
                    });

                    Task t3 = Task.Factory.StartNew(() =>
                    {
                        foreach (var l in listAssets[2])
                        {
                            double[] data = ClassAssistant.ReadNewData(filename, l, period);
                            ClassAssistant.VolatilityResult(l, data);
                            ClassAssistant.AverageProfit(l, data);
                        }
                    });

                    Task t4 = Task.Factory.StartNew(() =>
                    {
                        foreach (var l in listAssets[3])
                        {
                            double[] data = ClassAssistant.ReadNewData(filename, l, period);
                            ClassAssistant.VolatilityResult(l, data);
                            ClassAssistant.AverageProfit(l, data);
                        }
                    });

                    Task.WaitAll(t1, t2, t3, t4);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message + "\n" + ex.InnerException); }
           });
        }
        private Task DividendTask(Asset[] assets)
        {
            return Task.Run(() =>
                {
                    ClassAssistant.DownloadDividend(assets);
                });
        }
        private async void RefreshAllPeriods()
        {
            Asset[] newassets = assets;
            List<Asset>[] l = ClassAssistant.FillQueue(newassets);

            for (int i = 3; i < 13; i++)
            {
                if ((File.GetLastWriteTime(Program.path + "\\" + i + ".txt").Date != DateTime.Now.Date) || !File.Exists(Program.path + "\\" + i + ".txt"))
                {
                    await VolatilityTask(dataPath, l, i);
                    ClassAssistant.SaveData(Program.path + "\\" + i + ".txt", newassets);
                }
            }
            isCalculate = true;
        }
        private async void RefreshParameters()
        {
            DateTime dt = File.GetLastWriteTime(Application.StartupPath+"\\assets.txt").Date;
            if (DateTime.Now.Date != dt)
            {
                toolStripStatusLabel.Text = "Обновляем дивидендную доходность...";
                await DividendTask(assets);
                //  list = assets.ToList().OrderBy(x => x.Name).ToList();
                DoTable(list);

                toolStripStatusLabel.Text = "Обновляем ликвидность...";
                await LiqTask(assets);

                DoTable(list);

                toolStripStatusLabel.Text = "Обновляем волатильность и среднюю доходность...";

                List<Asset>[] l = ClassAssistant.FillQueue(assets);
                await VolatilityTask(dataPath, l, trackBar_period.Value);

                DoTable(list);

                dataGridView1.AllowUserToOrderColumns = true;
                toolStripStatusLabel.Text = "Обновление выполнено";
            }
            RefreshAllPeriods();
        }
                
        private Task Correlation(Asset[] all, int count, int period)
        {
            return Task.Run(() =>
            {
                CorrelationPortfolio(all, count, period);                
            });
        }
        private Task Download(List<Asset>[] lst, string path, int period)
        {
            return Task.Run(() =>
            {
                //ClassAssistant.DownloadAllAssets(allAssets, path, period, false);
                Asset[] asset1 = lst[0].ToArray();
                Asset[] asset2 = lst[1].ToArray();
                Asset[] asset3 = lst[2].ToArray();
                Asset[] asset4 = lst[3].ToArray();

                try
                {
                    Task t1 = Task.Factory.StartNew(() =>
                    {
                        ClassAssistant.DownloadAllAssets(asset1, path, period, false);
                    });

                    Task t2 = Task.Factory.StartNew(() =>
                    {
                        ClassAssistant.DownloadAllAssets(asset2, path, period, false);
                    });

                    Task t3 = Task.Factory.StartNew(() =>
                    {
                        ClassAssistant.DownloadAllAssets(asset3, path, period, false);
                    });

                    Task t4 = Task.Factory.StartNew(() =>
                    {
                        ClassAssistant.DownloadAllAssets(asset4, path, period, false);
                    });

                    Task.WaitAll(t1, t2, t3, t4);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message + "\n" + ex.InnerException); }
                
            });
        }
         private async void CorrelationTask(Asset[] selected)
         {
             ParallelOptions parOpts = new ParallelOptions();
             parOpts.CancellationToken = cancelToken.Token;
             try
             {
                 parOpts.CancellationToken.ThrowIfCancellationRequested();
                 toolStripStatusLabel.Text = "Считаем корреляцию...";

                 Asset[] all = new Asset[assets.Length];
                 int i = 0;
                 foreach (var t in selected)
                 {
                     all[i] = (Asset)t;
                     i++;
                 }
                 foreach (var t in list)
                 {
                     all[i] = (Asset)t;
                     i++;
                 }
                 await Correlation(all, dataGridView2.Rows.Count, trackBar_period.Value);
                 parOpts.CancellationToken.ThrowIfCancellationRequested();
                 // CorrelationPortfolio(all, listBox_assets.Items.Count);
                 list = new List<Asset>();
                 for (int j = dataGridView2.Rows.Count; j < all.Length; j++)
                 {
                     list.Add(all[j]);
                 }
                 list = list.OrderBy(x => x.Name).ToList<Asset>();

                 DoTable(list);

                 toolStripStatusLabel.Text = "Готово";
             }
             catch(OperationCanceledException ex)
             {
                 cancelToken = new CancellationTokenSource();
             }
         }

        private void CorrelationPortfolio(Asset[] allAssets, int count, int period)
        {
            ParallelOptions parOpts = new ParallelOptions();
            parOpts.CancellationToken = cancelToken.Token;
            try
            {
                parOpts.CancellationToken.ThrowIfCancellationRequested();

                double[,] finalArray = ClassAssistant.ReadDataForCorrelation(allAssets, Program.path + "\\data.txt", period); //ClassAssistant.ReadData(allAssets, path);
                parOpts.CancellationToken.ThrowIfCancellationRequested();

                double[] average = CalculationClass.AverageProfitability(finalArray);
                parOpts.CancellationToken.ThrowIfCancellationRequested();
                for (int i = count; i < allAssets.Length; i++)
                {
                    double sum = 0;
                    for (int j = 0; j < count; j++)
                    {
                        sum += CalculationClass.Cor(finalArray, average, i, j);
                    }
                    allAssets[i].Correlation = Math.Round(sum / count, 2);
                    parOpts.CancellationToken.ThrowIfCancellationRequested();
                }
            }
            catch (IOException ex) 
            {
                string[] exception = ex.Message.Split(' ');
              //  DialogResult dr = MessageBox.Show("Ошибка при считывании файла " + exception[exception.Length - 1] + ". Замените этот актив или попробуйте еще раз.\nПовторить попытку?",
              //       "Ошибка!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                  // MessageBox.Show(ex.Message);
                counter++;
                if (counter == 3)
                {
                    MessageBox.Show("Ошибка при расчете корреляции!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    counter = 0;
                } 
                else
                    CorrelationPortfolio(allAssets, count, period);
            }
            catch (OperationCanceledException ex) { throw ex; }
            catch (Exception ex)
            {
                string[] exception = ex.Message.Split(' ');
                DialogResult dr = MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (dr == System.Windows.Forms.DialogResult.Retry) CorrelationPortfolio(allAssets, count, period);
            }
        }

        private Task LiqTask(Asset[] assets)
        {
            return Task.Run(() =>
                {
                    ClassAssistant.ReadLiquidity(assets, DateTime.Now);
                });
        }

        private Task Wait()
        {
            return Task.Run(() =>
            {
                while (!isCalculate)
                {
                    Thread.Sleep(5000);
                }
            });
        }
        private async void trackBar_period_ValueChanged(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Подождите...";
            await Wait();
            isChange = true;
            toolStripStatusLabel.Text = "";
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripButton_clear_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < assets.Length;i++ )
            {
                assets[i].Correlation = 0;
            }
            dataGridView2.Rows.Clear();
            list = assets.ToList().OrderBy(x => x.Name).ToList();
            DoNewTable(list);
            trackBar_period.Value = trackBar_period.Minimum;

        }

        private void toolStripMenuItem_main_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripMenuItem_volcap_Click(object sender, EventArgs e)
        {
            Form6_VolCap form = new Form6_VolCap("cap", "vol", assets);
            form.Show();
        }

        private void toolStripMenuItem_capliq_Click(object sender, EventArgs e)
        {
            Form6_VolCap form = new Form6_VolCap("cap", "liq", assets);
            form.Show();
        }

        private void toolStripMenuItem_volliq_Click(object sender, EventArgs e)
        {
            Form6_VolCap form = new Form6_VolCap("liq", "vol", assets);
            form.Show();
        }

        private void toolStripButton_test_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView2.Rows.Count == 0) MessageBox.Show("Выберите активы!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    Form4_test form4 = new Form4_test();
                    form4.Show();
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Попробуйте еще раз", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButton_cor_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView2.Rows.Count == 0) MessageBox.Show("Выберите активы!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    Form5_cor form5 = new Form5_cor();
                    form5.Show();
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Попробуйте еще раз", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
               
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                ClassAssistant.SaveData(Application.StartupPath + "\\assets.txt", assets);
                using (StreamWriter sw = new StreamWriter(Application.StartupPath + "\\options.txt", false, Encoding.GetEncoding(1251)))
                {
                    sw.WriteLine("period=" + trackBar_period.Value);
                    if (dataGridView2.Rows.Count != 0)
                    {
                        foreach (DataGridViewRow r in dataGridView2.Rows)
                            sw.WriteLine(r.Cells[0].Value + ";" + r.Cells[1].Value);
                    }
                }
            }
            catch (Exception) { }
        }
       
        private void trackBar_period_MouseLeave(object sender, EventArgs e)
        {
            if(isChange)
            {
                isChange = false;
                /*
                List<Asset>[] l = ClassAssistant.FillQueue(assets);
                toolStripStatusLabel.Text = "Обновляем волатильность и среднюю доходность...";

                await VolatilityTask(dataPath, l, trackBar_period.Value);

              //  list = list.OrderBy(x => x.Name).ToList();
                DoTable(list);
                */

                assets = ClassAssistant.DoAssetsArray(Program.path + "\\" + trackBar_period.Value + ".txt");
                List<Asset> lst = new List<Asset>();
                foreach (var a in list)
                {
                    for (int i = 0; i < assets.Length; i++)
                    {
                        if (assets[i].Name == a.Name)
                        {
                            lst.Add(assets[i]);
                            break;
                        }
                    }
                }
                list = lst;
                DoTable(list);
    
                if (dataGridView2.Rows.Count != 0 && dataGridView1.RowCount != 0)
                {
                    cancelToken.Cancel(true);
                    cancelToken = new CancellationTokenSource();
                    int i = 0;
                    Asset[] selected = new Asset[dataGridView2.Rows.Count];
                    foreach (DataGridViewRow t in dataGridView2.Rows)
                    {
                        Asset a = (Asset)t.Cells[0].Value;
                        selected[i] = a;
                        i++;
                    }
                    CorrelationTask(selected);
                }
            }
        }
        
        private void label_12_Click(object sender, EventArgs e)
        {

        }

        private void button_optimal_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView2.Rows.Count == 0) MessageBox.Show("Выберите активы!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    // Form_parameter form = new Form_parameter();
                    Form3_graph form = new Form3_graph();
                    form.Show();
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Попробуйте еще раз", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}


// TODO:
// + 1. Рассчет по заданной доходности (интерфейс)
// 2. Рассчет по всем значениям
// + 2*. Придумать, как хранить риск, доход и доли активов
// 3. График с результатами п. 2 
// 4?. Рассчет и график по заданному промежутку
//
// Риск - х, доходность - у
// Доходность - length-2, Риск - length-1