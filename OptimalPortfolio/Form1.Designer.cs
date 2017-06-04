namespace OptimalPortfolio
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label_period = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button_add = new System.Windows.Forms.Button();
            this.button_delete = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label_myAssets = new System.Windows.Forms.Label();
            this.trackBar_period = new System.Windows.Forms.TrackBar();
            this.label_1 = new System.Windows.Forms.Label();
            this.label_12 = new System.Windows.Forms.Label();
            this.label_6 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton_clear = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripDropDownButton_graph = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItem_volcap = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_capliq = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_volliq = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton_test = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton_cor = new System.Windows.Forms.ToolStripButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.ColName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_optimal = new System.Windows.Forms.Button();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ticker = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnProfit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnVol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLiq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDiv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_period)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // label_period
            // 
            this.label_period.AutoSize = true;
            this.label_period.Location = new System.Drawing.Point(12, 56);
            this.label_period.Name = "label_period";
            this.label_period.Size = new System.Drawing.Size(192, 13);
            this.label_period.TabIndex = 2;
            this.label_period.Text = "Период инвестирования (в месяцах)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Доступные акции";
            // 
            // button_add
            // 
            this.button_add.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button_add.Location = new System.Drawing.Point(771, 287);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(47, 37);
            this.button_add.TabIndex = 8;
            this.button_add.Text = ">";
            this.toolTip1.SetToolTip(this.button_add, "Добавить");
            this.button_add.UseVisualStyleBackColor = true;
            this.button_add.Click += new System.EventHandler(this.button_add_Click);
            // 
            // button_delete
            // 
            this.button_delete.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button_delete.Location = new System.Drawing.Point(771, 349);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(47, 37);
            this.button_delete.TabIndex = 9;
            this.button_delete.Text = "<";
            this.toolTip1.SetToolTip(this.button_delete, "Удалить");
            this.button_delete.UseVisualStyleBackColor = true;
            this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 517);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1079, 22);
            this.statusStrip1.TabIndex = 19;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel.Text = " ";
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 10000;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.ReshowDelay = 100;
            // 
            // label_myAssets
            // 
            this.label_myAssets.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_myAssets.AutoSize = true;
            this.label_myAssets.Location = new System.Drawing.Point(821, 135);
            this.label_myAssets.Name = "label_myAssets";
            this.label_myAssets.Size = new System.Drawing.Size(99, 13);
            this.label_myAssets.TabIndex = 24;
            this.label_myAssets.Text = "Выбранные акции";
            // 
            // trackBar_period
            // 
            this.trackBar_period.LargeChange = 1;
            this.trackBar_period.Location = new System.Drawing.Point(14, 75);
            this.trackBar_period.Maximum = 12;
            this.trackBar_period.Minimum = 3;
            this.trackBar_period.Name = "trackBar_period";
            this.trackBar_period.Size = new System.Drawing.Size(734, 45);
            this.trackBar_period.TabIndex = 25;
            this.trackBar_period.Value = 3;
            this.trackBar_period.ValueChanged += new System.EventHandler(this.trackBar_period_ValueChanged);
            this.trackBar_period.MouseLeave += new System.EventHandler(this.trackBar_period_MouseLeave);
            // 
            // label_1
            // 
            this.label_1.AutoSize = true;
            this.label_1.Location = new System.Drawing.Point(21, 106);
            this.label_1.Name = "label_1";
            this.label_1.Size = new System.Drawing.Size(13, 13);
            this.label_1.TabIndex = 26;
            this.label_1.Text = "3";
            // 
            // label_12
            // 
            this.label_12.AutoSize = true;
            this.label_12.Location = new System.Drawing.Point(726, 106);
            this.label_12.Name = "label_12";
            this.label_12.Size = new System.Drawing.Size(19, 13);
            this.label_12.TabIndex = 27;
            this.label_12.Text = "12";
            this.label_12.Click += new System.EventHandler(this.label_12_Click);
            // 
            // label_6
            // 
            this.label_6.AutoSize = true;
            this.label_6.Location = new System.Drawing.Point(335, 106);
            this.label_6.Name = "label_6";
            this.label_6.Size = new System.Drawing.Size(13, 13);
            this.label_6.TabIndex = 28;
            this.label_6.Text = "7";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel5,
            this.toolStripButton_clear,
            this.toolStripLabel1,
            this.toolStripSeparator2,
            this.toolStripLabel4,
            this.toolStripDropDownButton_graph,
            this.toolStripLabel3,
            this.toolStripButton_test,
            this.toolStripLabel2,
            this.toolStripButton_cor});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1079, 39);
            this.toolStrip1.TabIndex = 30;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // toolStripLabel5
            // 
            this.toolStripLabel5.Name = "toolStripLabel5";
            this.toolStripLabel5.Size = new System.Drawing.Size(10, 36);
            this.toolStripLabel5.Text = " ";
            // 
            // toolStripButton_clear
            // 
            this.toolStripButton_clear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_clear.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_clear.Image")));
            this.toolStripButton_clear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_clear.Name = "toolStripButton_clear";
            this.toolStripButton_clear.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton_clear.Text = "Очистить данные";
            this.toolStripButton_clear.Click += new System.EventHandler(this.toolStripButton_clear_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(10, 36);
            this.toolStripLabel1.Text = " ";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(10, 36);
            this.toolStripLabel4.Text = " ";
            // 
            // toolStripDropDownButton_graph
            // 
            this.toolStripDropDownButton_graph.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton_graph.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_volcap,
            this.toolStripMenuItem_capliq,
            this.toolStripMenuItem_volliq});
            this.toolStripDropDownButton_graph.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton_graph.Image")));
            this.toolStripDropDownButton_graph.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton_graph.Name = "toolStripDropDownButton_graph";
            this.toolStripDropDownButton_graph.Size = new System.Drawing.Size(45, 36);
            this.toolStripDropDownButton_graph.Text = "Графики";
            // 
            // toolStripMenuItem_volcap
            // 
            this.toolStripMenuItem_volcap.Name = "toolStripMenuItem_volcap";
            this.toolStripMenuItem_volcap.Size = new System.Drawing.Size(252, 22);
            this.toolStripMenuItem_volcap.Text = "Волатильность и капитализация";
            this.toolStripMenuItem_volcap.Click += new System.EventHandler(this.toolStripMenuItem_volcap_Click);
            // 
            // toolStripMenuItem_capliq
            // 
            this.toolStripMenuItem_capliq.Name = "toolStripMenuItem_capliq";
            this.toolStripMenuItem_capliq.Size = new System.Drawing.Size(252, 22);
            this.toolStripMenuItem_capliq.Text = "Капитализация и ликвидность";
            this.toolStripMenuItem_capliq.Click += new System.EventHandler(this.toolStripMenuItem_capliq_Click);
            // 
            // toolStripMenuItem_volliq
            // 
            this.toolStripMenuItem_volliq.Name = "toolStripMenuItem_volliq";
            this.toolStripMenuItem_volliq.Size = new System.Drawing.Size(252, 22);
            this.toolStripMenuItem_volliq.Text = "Волатильность и ликвидность";
            this.toolStripMenuItem_volliq.Click += new System.EventHandler(this.toolStripMenuItem_volliq_Click);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(10, 36);
            this.toolStripLabel3.Text = " ";
            // 
            // toolStripButton_test
            // 
            this.toolStripButton_test.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_test.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_test.Image")));
            this.toolStripButton_test.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_test.Name = "toolStripButton_test";
            this.toolStripButton_test.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton_test.Text = "Тестирование";
            this.toolStripButton_test.Click += new System.EventHandler(this.toolStripButton_test_Click);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(10, 36);
            this.toolStripLabel2.Text = " ";
            // 
            // toolStripButton_cor
            // 
            this.toolStripButton_cor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_cor.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_cor.Image")));
            this.toolStripButton_cor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_cor.Name = "toolStripButton_cor";
            this.toolStripButton_cor.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton_cor.Text = "Таблица корреляции";
            this.toolStripButton_cor.Click += new System.EventHandler(this.toolStripButton_cor_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnName,
            this.Ticker,
            this.ColumnProfit,
            this.ColumnVol,
            this.ColumnCap,
            this.ColumnLiq,
            this.ColumnDiv,
            this.ColumnCor});
            this.dataGridView1.Location = new System.Drawing.Point(12, 151);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(753, 363);
            this.dataGridView1.TabIndex = 33;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(99, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(178, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 35;
            this.label3.Text = "5";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(257, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 13);
            this.label4.TabIndex = 36;
            this.label4.Text = "6";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(415, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 13);
            this.label5.TabIndex = 37;
            this.label5.Text = "8";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(492, 107);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 13);
            this.label6.TabIndex = 38;
            this.label6.Text = "9";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(568, 107);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(19, 13);
            this.label7.TabIndex = 39;
            this.label7.Text = "10";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(647, 107);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(19, 13);
            this.label8.TabIndex = 40;
            this.label8.Text = "11";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColName,
            this.Weight});
            this.dataGridView2.Location = new System.Drawing.Point(824, 151);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(243, 363);
            this.dataGridView2.TabIndex = 41;
            // 
            // ColName
            // 
            this.ColName.Frozen = true;
            this.ColName.HeaderText = "Название";
            this.ColName.Name = "ColName";
            this.ColName.ReadOnly = true;
            // 
            // Weight
            // 
            this.Weight.Frozen = true;
            this.Weight.HeaderText = "Макс. вес (%)";
            this.Weight.Name = "Weight";
            // 
            // button_optimal
            // 
            this.button_optimal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_optimal.Location = new System.Drawing.Point(824, 56);
            this.button_optimal.Name = "button_optimal";
            this.button_optimal.Size = new System.Drawing.Size(243, 64);
            this.button_optimal.TabIndex = 42;
            this.button_optimal.Text = "Определить оптимальный портфель";
            this.button_optimal.UseVisualStyleBackColor = true;
            this.button_optimal.Click += new System.EventHandler(this.button_optimal_Click);
            // 
            // ColumnName
            // 
            this.ColumnName.Frozen = true;
            this.ColumnName.HeaderText = "Название";
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.ReadOnly = true;
            // 
            // Ticker
            // 
            this.Ticker.Frozen = true;
            this.Ticker.HeaderText = "Тикер";
            this.Ticker.Name = "Ticker";
            this.Ticker.ReadOnly = true;
            this.Ticker.Width = 65;
            // 
            // ColumnProfit
            // 
            this.ColumnProfit.Frozen = true;
            this.ColumnProfit.HeaderText = "Средняя доходность за день (%)";
            this.ColumnProfit.Name = "ColumnProfit";
            this.ColumnProfit.ReadOnly = true;
            this.ColumnProfit.ToolTipText = "Средняя доходность акции за рассматриваемый период";
            this.ColumnProfit.Width = 85;
            // 
            // ColumnVol
            // 
            this.ColumnVol.Frozen = true;
            this.ColumnVol.HeaderText = "Волатильность (%)";
            this.ColumnVol.Name = "ColumnVol";
            this.ColumnVol.ReadOnly = true;
            this.ColumnVol.ToolTipText = "Степень изменчивости стоимости актива";
            this.ColumnVol.Width = 90;
            // 
            // ColumnCap
            // 
            this.ColumnCap.Frozen = true;
            this.ColumnCap.HeaderText = "Капитализация (млн руб.)";
            this.ColumnCap.Name = "ColumnCap";
            this.ColumnCap.ReadOnly = true;
            this.ColumnCap.ToolTipText = "Рыночная стоимость компании";
            this.ColumnCap.Width = 95;
            // 
            // ColumnLiq
            // 
            this.ColumnLiq.Frozen = true;
            this.ColumnLiq.HeaderText = "Ликвидность";
            this.ColumnLiq.Name = "ColumnLiq";
            this.ColumnLiq.ReadOnly = true;
            this.ColumnLiq.ToolTipText = "Способность акции быть быстро проданной без существенных потерь";
            this.ColumnLiq.Width = 90;
            // 
            // ColumnDiv
            // 
            this.ColumnDiv.Frozen = true;
            this.ColumnDiv.HeaderText = "Дивидендная доходность (%)";
            this.ColumnDiv.Name = "ColumnDiv";
            this.ColumnDiv.ReadOnly = true;
            this.ColumnDiv.ToolTipText = "Отношение годового дивиденда на акцию к стоимости акции";
            this.ColumnDiv.Width = 90;
            // 
            // ColumnCor
            // 
            this.ColumnCor.Frozen = true;
            this.ColumnCor.HeaderText = "Корреляция";
            this.ColumnCor.Name = "ColumnCor";
            this.ColumnCor.ReadOnly = true;
            this.ColumnCor.ToolTipText = "Корреляция между доступными акциями и портфелем (выбранными акциями).";
            this.ColumnCor.Width = 80;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1079, 539);
            this.Controls.Add(this.button_optimal);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label_6);
            this.Controls.Add(this.label_12);
            this.Controls.Add(this.label_1);
            this.Controls.Add(this.trackBar_period);
            this.Controls.Add(this.label_myAssets);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.button_delete);
            this.Controls.Add(this.button_add);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_period);
            this.Name = "Form1";
            this.Text = "Выбор параметров";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_period)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label label_period;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button button_add;
        public System.Windows.Forms.Button button_delete;
        private System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label_myAssets;
        public System.Windows.Forms.TrackBar trackBar_period;
        private System.Windows.Forms.Label label_1;
        private System.Windows.Forms.Label label_12;
        private System.Windows.Forms.Label label_6;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton_clear;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton_graph;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_volcap;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_capliq;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_volliq;
        private System.Windows.Forms.ToolStripButton toolStripButton_test;
        private System.Windows.Forms.ToolStripButton toolStripButton_cor;
        private System.Windows.Forms.ToolStripLabel toolStripLabel5;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Weight;
        private System.Windows.Forms.Button button_optimal;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ticker;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnProfit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnVol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCap;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLiq;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDiv;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCor;
    }
}

