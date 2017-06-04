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
    public partial class Form6_VolCap : Form
    {
        private Asset[] assets;
        private string xAxis = "", yAxis = "";
        public Form6_VolCap()
        {
            InitializeComponent();
        }
        public Form6_VolCap(string xAxis, string yAxis, Asset[] assets)
        {
            InitializeComponent();
            this.xAxis = xAxis;
            this.yAxis = yAxis;
            this.assets = assets;
        }

        private void Form6_VolCap_Load(object sender, EventArgs e)
        {
          //  tableLayoutPanel1.Controls.Add(zGC, 0, 0);
          //  tableLayoutPanel1.Controls.Add(dataGridView1, 1, 0);
            
            int i = 0;
      /*      foreach(var t in Program.form.listBox_allAssets.Items)
            {
                assets[i] = (Asset)t;
                i++;
            }
*/
            zGC.GraphPane.CurveList.Clear();
            DoGraphic(xAxis, yAxis);
            
        }
        private string zGC_PointValueEvent(ZedGraphControl sender, GraphPane pane, CurveItem curve, int iPt)
        {
            PointPair point = curve[iPt];
            Asset a = null;
            string result = "";
            foreach(var t in assets)
            {
                if (point.X == t.Capitalization || point.X == t.Liquidity)
                {
                    a = t;
                    break;
                }
            }
            if (xAxis == "cap" && yAxis == "vol")
                result = string.Format("{0}\nCap: {1}\nVol: {2:F4}%", a.Ticker, point.X, point.Y);
            if (xAxis == "liq" && yAxis == "vol")
                result = string.Format("{0}\nLiq: {1}\nVol: {2:F4}%", a.Ticker, point.X, point.Y);
            if (xAxis == "cap" && yAxis == "liq")
                result = string.Format("{0}\nCap: {1}\nLiq: {2}", a.Ticker, point.X, point.Y);

            return result;
        }
        private void DoGraphic(string xAxis, string yAxis)
        {
            GraphPane gp = zGC.GraphPane;
            double[] x = new double[assets.Length];
            double[] y = new double[assets.Length];
            int i = 0;

            if(xAxis == "cap" && yAxis == "vol")
            {
                gp.Title.Text = "Волатильность и капитализация";
                gp.YAxis.Title.Text = "Волатильность (%)";
                gp.XAxis.Title.Text = "Капитализация (руб.)";

                gp.CurveList.Clear();
                zGC.AxisChange();
                zGC.Invalidate();
                zGC.IsShowPointValues = true;
                
                foreach (var a in assets)
                {
                    x[i] = a.Capitalization;
                    y[i] = a.Volatility;
                    /*
                    dataGridView1.Rows.Add();
                    if (a.Capitalization != 0)
                    {
                        
                        dataGridView1[0, i].Value = a.Code;
                        dataGridView1[1, i].Value = Math.Sqrt(x[i] * x[i] + y[i] * y[i]);
                    }
                   */
                    i++;
                }
                
            }
            if(xAxis == "liq" && yAxis == "vol")
            {
                gp.Title.Text = "Волатильность и ликвидность";
                gp.YAxis.Title.Text = "Волатильность (%)";
                gp.XAxis.Title.Text = "Ликвидность (руб.)";

                gp.CurveList.Clear();
                zGC.AxisChange();
                zGC.Invalidate();
                zGC.IsShowPointValues = true;
                
                foreach (var a in assets)
                {
                    x[i] = a.Liquidity;
                    y[i] = a.Volatility;
                    /*
                    dataGridView1.Rows.Add();
                    dataGridView1[0, i].Value = a.Code;
                    dataGridView1[1, i].Value = Math.Sqrt(x[i] * x[i] + y[i] * y[i]);
                     * */
                    i++;
                }
            }
            if(xAxis == "cap" && yAxis == "liq")
            {
                gp.Title.Text = "Ликвидность и капитализация";
                gp.YAxis.Title.Text = "Ликвидность (руб.)";
                gp.XAxis.Title.Text = "Капитализация (руб.)";

                gp.CurveList.Clear();
                zGC.AxisChange();
                zGC.Invalidate();
                zGC.IsShowPointValues = true;
                
                foreach (var a in assets)
                {
                    x[i] = a.Capitalization;
                    y[i] = a.Liquidity;
                    /*
                    dataGridView1.Rows.Add();
                    if (a.Capitalization != 0)
                    {
                        
                        dataGridView1[0, i].Value = a.Code;
                        dataGridView1[1, i].Value = Math.Sqrt(x[i] * x[i] + y[i] * y[i]);
                    }
                     * */
                    i++;
                }
                 
            }
            LineItem line = gp.AddCurve("", x, y, Color.Red);
            line.Line.IsVisible = false;
            line.Symbol.Type = SymbolType.Diamond;
            line.Symbol.Fill.Color = Color.Red;
            line.Symbol.Fill.Type = FillType.Solid;

            CurveList cl = gp.CurveList;
            zGC.AxisChange();
            zGC.Invalidate();
        }

    }
}
