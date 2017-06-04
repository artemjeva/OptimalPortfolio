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
    public partial class Form_parameter : Form
    {
        public Form_parameter()
        {
            InitializeComponent();
        }

        private void label_step_Click(object sender, EventArgs e)
        {

        }

        private void button_go_Click(object sender, EventArgs e)
        {
            Form3_graph form = new Form3_graph(Convert.ToDouble(textBox_start.Text) / 100, Convert.ToDouble(textBox_finish.Text) / 100, Convert.ToDouble(textBox_step.Text) / 100);
            form.Show();
            this.Close();
        }
    }
}
