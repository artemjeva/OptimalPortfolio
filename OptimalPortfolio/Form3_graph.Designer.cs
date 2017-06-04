using ZedGraph;

namespace OptimalPortfolio
{
    partial class Form3_graph
    {
     
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label_assets = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.Column_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label_profit = new System.Windows.Forms.Label();
            this.label_risk = new System.Windows.Forms.Label();
            this.label_profitValue = new System.Windows.Forms.Label();
            this.label_riskValue = new System.Windows.Forms.Label();
            this.label_ = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_stand = new System.Windows.Forms.Label();
            this.label_std = new System.Windows.Forms.Label();
            this.zGC = new ZedGraph.ZedGraphControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label_step = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button_max = new System.Windows.Forms.Button();
            this.button_min = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_assets
            // 
            this.label_assets.AutoSize = true;
            this.label_assets.Location = new System.Drawing.Point(3, 137);
            this.label_assets.Name = "label_assets";
            this.label_assets.Size = new System.Drawing.Size(78, 13);
            this.label_assets.TabIndex = 3;
            this.label_assets.Text = "Доли активов";
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_Name,
            this.Column_Value});
            this.dataGridView.Location = new System.Drawing.Point(3, 153);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.Size = new System.Drawing.Size(237, 304);
            this.dataGridView.TabIndex = 6;
            // 
            // Column_Name
            // 
            this.Column_Name.HeaderText = "Актив";
            this.Column_Name.Name = "Column_Name";
            this.Column_Name.ReadOnly = true;
            // 
            // Column_Value
            // 
            this.Column_Value.HeaderText = "Доля";
            this.Column_Value.MaxInputLength = 5;
            this.Column_Value.Name = "Column_Value";
            this.Column_Value.ReadOnly = true;
            this.Column_Value.Width = 75;
            // 
            // label_profit
            // 
            this.label_profit.AutoSize = true;
            this.label_profit.Location = new System.Drawing.Point(3, 93);
            this.label_profit.Name = "label_profit";
            this.label_profit.Size = new System.Drawing.Size(68, 13);
            this.label_profit.TabIndex = 15;
            this.label_profit.Text = "Доходность";
            // 
            // label_risk
            // 
            this.label_risk.AutoSize = true;
            this.label_risk.Location = new System.Drawing.Point(3, 67);
            this.label_risk.Name = "label_risk";
            this.label_risk.Size = new System.Drawing.Size(32, 13);
            this.label_risk.TabIndex = 16;
            this.label_risk.Text = "Риск";
            this.toolTip1.SetToolTip(this.label_risk, "Риск складывается из риска снижения доходности при падении доходности ЕП и \r\nриск" +
        "а несоответствия доходности построенной линии регрессии.");
            // 
            // label_profitValue
            // 
            this.label_profitValue.Location = new System.Drawing.Point(149, 92);
            this.label_profitValue.Name = "label_profitValue";
            this.label_profitValue.Size = new System.Drawing.Size(62, 14);
            this.label_profitValue.TabIndex = 17;
            this.label_profitValue.Text = "0%";
            // 
            // label_riskValue
            // 
            this.label_riskValue.Location = new System.Drawing.Point(149, 67);
            this.label_riskValue.Name = "label_riskValue";
            this.label_riskValue.Size = new System.Drawing.Size(62, 13);
            this.label_riskValue.TabIndex = 18;
            this.label_riskValue.Text = "0%";
            // 
            // label_
            // 
            this.label_.AutoSize = true;
            this.label_.Location = new System.Drawing.Point(3, 16);
            this.label_.Name = "label_";
            this.label_.Size = new System.Drawing.Size(13, 13);
            this.label_.TabIndex = 19;
            this.label_.Text = "0";
            this.toolTip1.SetToolTip(this.label_, "Количество найденных портфелей");
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.label_stand);
            this.panel1.Controls.Add(this.label_std);
            this.panel1.Controls.Add(this.label_profitValue);
            this.panel1.Controls.Add(this.label_riskValue);
            this.panel1.Controls.Add(this.label_);
            this.panel1.Controls.Add(this.label_profit);
            this.panel1.Controls.Add(this.label_risk);
            this.panel1.Controls.Add(this.label_assets);
            this.panel1.Controls.Add(this.dataGridView);
            this.panel1.Location = new System.Drawing.Point(477, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(245, 460);
            this.panel1.TabIndex = 20;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label_stand
            // 
            this.label_stand.Location = new System.Drawing.Point(149, 43);
            this.label_stand.Name = "label_stand";
            this.label_stand.Size = new System.Drawing.Size(62, 13);
            this.label_stand.TabIndex = 21;
            this.label_stand.Text = "0%";
            // 
            // label_std
            // 
            this.label_std.AutoSize = true;
            this.label_std.Location = new System.Drawing.Point(3, 43);
            this.label_std.Name = "label_std";
            this.label_std.Size = new System.Drawing.Size(134, 13);
            this.label_std.TabIndex = 20;
            this.label_std.Text = "Стандартное отклонение";
            this.toolTip1.SetToolTip(this.label_std, "Классическая мера риска");
            // 
            // zGC
            // 
            this.zGC.Location = new System.Drawing.Point(0, 0);
            this.zGC.Name = "zGC";
            this.zGC.ScrollGrace = 0D;
            this.zGC.ScrollMaxX = 0D;
            this.zGC.ScrollMaxY = 0D;
            this.zGC.ScrollMaxY2 = 0D;
            this.zGC.ScrollMinX = 0D;
            this.zGC.ScrollMinY = 0D;
            this.zGC.ScrollMinY2 = 0D;
            this.zGC.Size = new System.Drawing.Size(466, 429);
            this.zGC.TabIndex = 0;
            this.zGC.PointValueEvent += new ZedGraph.ZedGraphControl.PointValueHandler(this.zGC_PointValueEvent);
            this.zGC.CursorChanged += new System.EventHandler(this.zGC_CursorChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label_step);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.button_max);
            this.panel2.Controls.Add(this.button_min);
            this.panel2.Controls.Add(this.zGC);
            this.panel2.Location = new System.Drawing.Point(0, -1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(466, 460);
            this.panel2.TabIndex = 21;
            // 
            // label_step
            // 
            this.label_step.AutoSize = true;
            this.label_step.Location = new System.Drawing.Point(214, 437);
            this.label_step.Name = "label_step";
            this.label_step.Size = new System.Drawing.Size(21, 13);
            this.label_step.TabIndex = 5;
            this.label_step.Text = "0%";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(292, 437);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Увеличить шаг";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(81, 436);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Уменьшить шаг";
            // 
            // button_max
            // 
            this.button_max.Location = new System.Drawing.Point(251, 432);
            this.button_max.Name = "button_max";
            this.button_max.Size = new System.Drawing.Size(35, 23);
            this.button_max.TabIndex = 2;
            this.button_max.Text = "+";
            this.button_max.UseVisualStyleBackColor = true;
            this.button_max.Click += new System.EventHandler(this.button_max_Click);
            // 
            // button_min
            // 
            this.button_min.Location = new System.Drawing.Point(169, 432);
            this.button_min.Name = "button_min";
            this.button_min.Size = new System.Drawing.Size(35, 23);
            this.button_min.TabIndex = 1;
            this.button_min.Text = "-";
            this.button_min.UseVisualStyleBackColor = true;
            this.button_min.Click += new System.EventHandler(this.button_min_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 10000;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.ReshowDelay = 100;
            // 
            // Form3_graph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 462);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(745, 500);
            this.MinimumSize = new System.Drawing.Size(745, 500);
            this.Name = "Form3_graph";
            this.Text = "Эффективная граница портфелей";
            this.Load += new System.EventHandler(this.Form3_graph_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.Label label_assets;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label label_profit;
        private System.Windows.Forms.Label label_risk;
        private System.Windows.Forms.Label label_profitValue;
        private System.Windows.Forms.Label label_riskValue;
        private System.Windows.Forms.Label label_;
        private System.Windows.Forms.Panel panel1;
        public ZedGraphControl zGC;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label_stand;
        private System.Windows.Forms.Label label_std;
        private System.Windows.Forms.Label label_step;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_max;
        private System.Windows.Forms.Button button_min;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Value;
    }
}