namespace OptimalPortfolio
{
    partial class Form4_test
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
            this.comboBox_test = new System.Windows.Forms.ComboBox();
            this.label_risk = new System.Windows.Forms.Label();
            this.label_profit = new System.Windows.Forms.Label();
            this.label_riskV = new System.Windows.Forms.Label();
            this.label_profitV = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.ColName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColW = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label_profitFact = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label_profRisk = new System.Windows.Forms.Label();
            this.zGC = new ZedGraph.ZedGraphControl();
            this.label_ddRel = new System.Windows.Forms.Label();
            this.comboBox_year = new System.Windows.Forms.ComboBox();
            this.label_year = new System.Windows.Forms.Label();
            this.checkBox1_index = new System.Windows.Forms.CheckBox();
            this.label_indProfit = new System.Windows.Forms.Label();
            this.label_indDrowdown = new System.Windows.Forms.Label();
            this.label_p = new System.Windows.Forms.Label();
            this.label_i = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label_std = new System.Windows.Forms.Label();
            this.label_stand = new System.Windows.Forms.Label();
            this.checkBox_sp = new System.Windows.Forms.CheckBox();
            this.label_sp = new System.Windows.Forms.Label();
            this.label_spDD = new System.Windows.Forms.Label();
            this.label_spP = new System.Windows.Forms.Label();
            this.button_edit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox_test
            // 
            this.comboBox_test.FormattingEnabled = true;
            this.comboBox_test.Location = new System.Drawing.Point(13, 89);
            this.comboBox_test.Name = "comboBox_test";
            this.comboBox_test.Size = new System.Drawing.Size(121, 21);
            this.comboBox_test.TabIndex = 0;
            this.comboBox_test.SelectedIndexChanged += new System.EventHandler(this.comboBox_test_SelectedIndexChanged);
            // 
            // label_risk
            // 
            this.label_risk.AutoSize = true;
            this.label_risk.Location = new System.Drawing.Point(13, 139);
            this.label_risk.Name = "label_risk";
            this.label_risk.Size = new System.Drawing.Size(82, 13);
            this.label_risk.TabIndex = 2;
            this.label_risk.Text = "Риск (прогноз)";
            this.toolTip1.SetToolTip(this.label_risk, "Риск складывается из риска снижения доходности при падении доходности ЕП и \r\nриск" +
        "а несоответствия доходности построенной линии регрессии.");
            // 
            // label_profit
            // 
            this.label_profit.AutoSize = true;
            this.label_profit.Location = new System.Drawing.Point(13, 159);
            this.label_profit.Name = "label_profit";
            this.label_profit.Size = new System.Drawing.Size(118, 13);
            this.label_profit.TabIndex = 3;
            this.label_profit.Text = "Доходность (прогноз)";
            // 
            // label_riskV
            // 
            this.label_riskV.AutoSize = true;
            this.label_riskV.Location = new System.Drawing.Point(220, 138);
            this.label_riskV.Name = "label_riskV";
            this.label_riskV.Size = new System.Drawing.Size(21, 13);
            this.label_riskV.TabIndex = 4;
            this.label_riskV.Text = "0%";
            // 
            // label_profitV
            // 
            this.label_profitV.AutoSize = true;
            this.label_profitV.Location = new System.Drawing.Point(220, 158);
            this.label_profitV.Name = "label_profitV";
            this.label_profitV.Size = new System.Drawing.Size(21, 13);
            this.label_profitV.TabIndex = 5;
            this.label_profitV.Text = "0%";
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColName,
            this.ColW});
            this.dataGridView.Location = new System.Drawing.Point(15, 222);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(261, 158);
            this.dataGridView.TabIndex = 6;
            this.dataGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView_KeyDown);
            // 
            // ColName
            // 
            this.ColName.HeaderText = "Активы";
            this.ColName.Name = "ColName";
            this.ColName.ReadOnly = true;
            // 
            // ColW
            // 
            this.ColW.HeaderText = "Доли";
            this.ColW.Name = "ColW";
            this.ColW.ReadOnly = true;
            // 
            // label_profitFact
            // 
            this.label_profitFact.AutoSize = true;
            this.label_profitFact.Location = new System.Drawing.Point(157, 401);
            this.label_profitFact.Name = "label_profitFact";
            this.label_profitFact.Size = new System.Drawing.Size(21, 13);
            this.label_profitFact.TabIndex = 10;
            this.label_profitFact.Text = "0%";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 402);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Общая доходность";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 422);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Максимальная просадка";
            // 
            // label_profRisk
            // 
            this.label_profRisk.AutoSize = true;
            this.label_profRisk.Location = new System.Drawing.Point(13, 62);
            this.label_profRisk.Name = "label_profRisk";
            this.label_profRisk.Size = new System.Drawing.Size(118, 26);
            this.label_profRisk.TabIndex = 11;
            this.label_profRisk.Text = "Выберите портфель\r\n(№: доходность, риск)";
            // 
            // zGC
            // 
            this.zGC.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.zGC.Location = new System.Drawing.Point(323, 56);
            this.zGC.Name = "zGC";
            this.zGC.ScrollGrace = 0D;
            this.zGC.ScrollMaxX = 0D;
            this.zGC.ScrollMaxY = 0D;
            this.zGC.ScrollMaxY2 = 0D;
            this.zGC.ScrollMinX = 0D;
            this.zGC.ScrollMinY = 0D;
            this.zGC.ScrollMinY2 = 0D;
            this.zGC.Size = new System.Drawing.Size(423, 386);
            this.zGC.TabIndex = 12;
            this.zGC.PointValueEvent += new ZedGraph.ZedGraphControl.PointValueHandler(this.zGC_PointValueEvent);
            // 
            // label_ddRel
            // 
            this.label_ddRel.AutoSize = true;
            this.label_ddRel.Location = new System.Drawing.Point(157, 422);
            this.label_ddRel.Name = "label_ddRel";
            this.label_ddRel.Size = new System.Drawing.Size(21, 13);
            this.label_ddRel.TabIndex = 14;
            this.label_ddRel.Text = "0%";
            // 
            // comboBox_year
            // 
            this.comboBox_year.FormattingEnabled = true;
            this.comboBox_year.Items.AddRange(new object[] {
            "2015",
            "2014",
            "2013",
            "2012",
            "2011",
            "2010",
            "2009"});
            this.comboBox_year.Location = new System.Drawing.Point(13, 21);
            this.comboBox_year.Name = "comboBox_year";
            this.comboBox_year.Size = new System.Drawing.Size(121, 21);
            this.comboBox_year.TabIndex = 15;
            this.comboBox_year.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label_year
            // 
            this.label_year.AutoSize = true;
            this.label_year.Location = new System.Drawing.Point(13, 5);
            this.label_year.Name = "label_year";
            this.label_year.Size = new System.Drawing.Size(25, 13);
            this.label_year.TabIndex = 16;
            this.label_year.Text = "Год";
            this.toolTip1.SetToolTip(this.label_year, "Год, для которого строятся портфели. График строится по данным следующего года.");
            // 
            // checkBox1_index
            // 
            this.checkBox1_index.AutoSize = true;
            this.checkBox1_index.Location = new System.Drawing.Point(323, 28);
            this.checkBox1_index.Name = "checkBox1_index";
            this.checkBox1_index.Size = new System.Drawing.Size(165, 17);
            this.checkBox1_index.TabIndex = 17;
            this.checkBox1_index.Text = "График для индекса ММВБ";
            this.checkBox1_index.UseVisualStyleBackColor = true;
            this.checkBox1_index.CheckedChanged += new System.EventHandler(this.checkBox1_index_CheckedChanged);
            // 
            // label_indProfit
            // 
            this.label_indProfit.AutoSize = true;
            this.label_indProfit.Location = new System.Drawing.Point(217, 401);
            this.label_indProfit.Name = "label_indProfit";
            this.label_indProfit.Size = new System.Drawing.Size(10, 13);
            this.label_indProfit.TabIndex = 18;
            this.label_indProfit.Text = " ";
            // 
            // label_indDrowdown
            // 
            this.label_indDrowdown.AutoSize = true;
            this.label_indDrowdown.Location = new System.Drawing.Point(217, 421);
            this.label_indDrowdown.Name = "label_indDrowdown";
            this.label_indDrowdown.Size = new System.Drawing.Size(10, 13);
            this.label_indDrowdown.TabIndex = 19;
            this.label_indDrowdown.Text = " ";
            // 
            // label_p
            // 
            this.label_p.AutoSize = true;
            this.label_p.Location = new System.Drawing.Point(149, 384);
            this.label_p.Name = "label_p";
            this.label_p.Size = new System.Drawing.Size(58, 13);
            this.label_p.TabIndex = 20;
            this.label_p.Text = "Портфель";
            // 
            // label_i
            // 
            this.label_i.AutoSize = true;
            this.label_i.Location = new System.Drawing.Point(217, 384);
            this.label_i.Name = "label_i";
            this.label_i.Size = new System.Drawing.Size(39, 13);
            this.label_i.TabIndex = 21;
            this.label_i.Text = "ММВБ";
            this.label_i.Visible = false;
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 10000;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.ReshowDelay = 100;
            // 
            // label_std
            // 
            this.label_std.AutoSize = true;
            this.label_std.Location = new System.Drawing.Point(13, 119);
            this.label_std.Name = "label_std";
            this.label_std.Size = new System.Drawing.Size(184, 13);
            this.label_std.TabIndex = 22;
            this.label_std.Text = "Стандартное отклонение (прогноз)";
            this.toolTip1.SetToolTip(this.label_std, "Классическая мера риска");
            this.label_std.Click += new System.EventHandler(this.label_std_Click);
            // 
            // label_stand
            // 
            this.label_stand.Location = new System.Drawing.Point(220, 119);
            this.label_stand.Name = "label_stand";
            this.label_stand.Size = new System.Drawing.Size(57, 13);
            this.label_stand.TabIndex = 23;
            this.label_stand.Text = "0%";
            // 
            // checkBox_sp
            // 
            this.checkBox_sp.AutoSize = true;
            this.checkBox_sp.Location = new System.Drawing.Point(525, 28);
            this.checkBox_sp.Name = "checkBox_sp";
            this.checkBox_sp.Size = new System.Drawing.Size(198, 17);
            this.checkBox_sp.TabIndex = 24;
            this.checkBox_sp.Text = "График для единичного портфеля";
            this.checkBox_sp.UseVisualStyleBackColor = true;
            this.checkBox_sp.CheckedChanged += new System.EventHandler(this.checkBox_sp_CheckedChanged);
            // 
            // label_sp
            // 
            this.label_sp.AutoSize = true;
            this.label_sp.Location = new System.Drawing.Point(266, 384);
            this.label_sp.Name = "label_sp";
            this.label_sp.Size = new System.Drawing.Size(22, 13);
            this.label_sp.TabIndex = 27;
            this.label_sp.Text = "ЕП";
            this.label_sp.Visible = false;
            // 
            // label_spDD
            // 
            this.label_spDD.AutoSize = true;
            this.label_spDD.Location = new System.Drawing.Point(266, 421);
            this.label_spDD.Name = "label_spDD";
            this.label_spDD.Size = new System.Drawing.Size(10, 13);
            this.label_spDD.TabIndex = 26;
            this.label_spDD.Text = " ";
            // 
            // label_spP
            // 
            this.label_spP.AutoSize = true;
            this.label_spP.Location = new System.Drawing.Point(266, 401);
            this.label_spP.Name = "label_spP";
            this.label_spP.Size = new System.Drawing.Size(10, 13);
            this.label_spP.TabIndex = 25;
            this.label_spP.Text = " ";
            // 
            // button_edit
            // 
            this.button_edit.Location = new System.Drawing.Point(172, 62);
            this.button_edit.Name = "button_edit";
            this.button_edit.Size = new System.Drawing.Size(105, 48);
            this.button_edit.TabIndex = 28;
            this.button_edit.Text = "Ввести значения";
            this.button_edit.UseVisualStyleBackColor = true;
            this.button_edit.Click += new System.EventHandler(this.button_edit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(141, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "или";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 186);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(271, 26);
            this.label2.TabIndex = 30;
            this.label2.Text = "Нажмите Enter, чтобы закончить редактирование и \r\nпостроить график";
            this.label2.Visible = false;
            // 
            // Form4_test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 442);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_edit);
            this.Controls.Add(this.label_sp);
            this.Controls.Add(this.label_spDD);
            this.Controls.Add(this.label_spP);
            this.Controls.Add(this.checkBox_sp);
            this.Controls.Add(this.label_stand);
            this.Controls.Add(this.label_std);
            this.Controls.Add(this.label_i);
            this.Controls.Add(this.label_p);
            this.Controls.Add(this.label_indDrowdown);
            this.Controls.Add(this.label_indProfit);
            this.Controls.Add(this.checkBox1_index);
            this.Controls.Add(this.label_year);
            this.Controls.Add(this.comboBox_year);
            this.Controls.Add(this.label_ddRel);
            this.Controls.Add(this.zGC);
            this.Controls.Add(this.label_profRisk);
            this.Controls.Add(this.label_profitFact);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.label_profitV);
            this.Controls.Add(this.label_riskV);
            this.Controls.Add(this.label_profit);
            this.Controls.Add(this.label_risk);
            this.Controls.Add(this.comboBox_test);
            this.MaximizeBox = false;
            this.Name = "Form4_test";
            this.Text = "Тестирование";
            this.Load += new System.EventHandler(this.Form4_test_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_test;
        private System.Windows.Forms.Label label_risk;
        private System.Windows.Forms.Label label_profit;
        private System.Windows.Forms.Label label_riskV;
        private System.Windows.Forms.Label label_profitV;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label label_profitFact;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_profRisk;
        public ZedGraph.ZedGraphControl zGC;
        private System.Windows.Forms.Label label_ddRel;
        private System.Windows.Forms.ComboBox comboBox_year;
        private System.Windows.Forms.Label label_year;
        private System.Windows.Forms.CheckBox checkBox1_index;
        private System.Windows.Forms.Label label_indProfit;
        private System.Windows.Forms.Label label_indDrowdown;
        private System.Windows.Forms.Label label_p;
        private System.Windows.Forms.Label label_i;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label_stand;
        private System.Windows.Forms.Label label_std;
        private System.Windows.Forms.CheckBox checkBox_sp;
        private System.Windows.Forms.Label label_sp;
        private System.Windows.Forms.Label label_spDD;
        private System.Windows.Forms.Label label_spP;
        private System.Windows.Forms.Button button_edit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColW;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}