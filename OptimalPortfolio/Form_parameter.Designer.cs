namespace OptimalPortfolio
{
    partial class Form_parameter
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
            this.textBox_finish = new System.Windows.Forms.TextBox();
            this.label_step = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_step = new System.Windows.Forms.TextBox();
            this.textBox_start = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label_int = new System.Windows.Forms.Label();
            this.button_go = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_finish
            // 
            this.textBox_finish.Location = new System.Drawing.Point(173, 42);
            this.textBox_finish.Name = "textBox_finish";
            this.textBox_finish.Size = new System.Drawing.Size(81, 20);
            this.textBox_finish.TabIndex = 20;
            this.textBox_finish.Text = "100";
            // 
            // label_step
            // 
            this.label_step.AutoSize = true;
            this.label_step.Location = new System.Drawing.Point(39, 77);
            this.label_step.Name = "label_step";
            this.label_step.Size = new System.Drawing.Size(135, 13);
            this.label_step.TabIndex = 14;
            this.label_step.Text = "Шаг для доходности (в %)";
            this.label_step.Click += new System.EventHandler(this.label_step_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(148, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "до";
            // 
            // textBox_step
            // 
            this.textBox_step.Location = new System.Drawing.Point(42, 102);
            this.textBox_step.Name = "textBox_step";
            this.textBox_step.Size = new System.Drawing.Size(100, 20);
            this.textBox_step.TabIndex = 15;
            this.textBox_step.Text = "0,1";
            // 
            // textBox_start
            // 
            this.textBox_start.Location = new System.Drawing.Point(61, 42);
            this.textBox_start.Name = "textBox_start";
            this.textBox_start.Size = new System.Drawing.Size(81, 20);
            this.textBox_start.TabIndex = 17;
            this.textBox_start.Text = "0,1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "от";
            // 
            // label_int
            // 
            this.label_int.AutoSize = true;
            this.label_int.Location = new System.Drawing.Point(37, 22);
            this.label_int.Name = "label_int";
            this.label_int.Size = new System.Drawing.Size(167, 13);
            this.label_int.TabIndex = 16;
            this.label_int.Text = "Интервал для доходности  (в %)";
            // 
            // button_go
            // 
            this.button_go.Location = new System.Drawing.Point(173, 97);
            this.button_go.Name = "button_go";
            this.button_go.Size = new System.Drawing.Size(81, 29);
            this.button_go.TabIndex = 21;
            this.button_go.Text = "Применить";
            this.button_go.UseVisualStyleBackColor = true;
            this.button_go.Click += new System.EventHandler(this.button_go_Click);
            // 
            // Form_parameter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 142);
            this.Controls.Add(this.button_go);
            this.Controls.Add(this.textBox_finish);
            this.Controls.Add(this.label_step);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_step);
            this.Controls.Add(this.textBox_start);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_int);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(320, 180);
            this.MinimumSize = new System.Drawing.Size(320, 180);
            this.Name = "Form_parameter";
            this.Text = "Параметры";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_finish;
        private System.Windows.Forms.Label label_step;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_step;
        private System.Windows.Forms.TextBox textBox_start;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_int;
        private System.Windows.Forms.Button button_go;
    }
}