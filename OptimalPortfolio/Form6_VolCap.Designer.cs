namespace OptimalPortfolio
{
    partial class Form6_VolCap
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
            this.zGC = new ZedGraph.ZedGraphControl();
            this.SuspendLayout();
            // 
            // zGC
            // 
            this.zGC.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.zGC.Location = new System.Drawing.Point(0, -1);
            this.zGC.Name = "zGC";
            this.zGC.ScrollGrace = 0D;
            this.zGC.ScrollMaxX = 0D;
            this.zGC.ScrollMaxY = 0D;
            this.zGC.ScrollMaxY2 = 0D;
            this.zGC.ScrollMinX = 0D;
            this.zGC.ScrollMinY = 0D;
            this.zGC.ScrollMinY2 = 0D;
            this.zGC.Size = new System.Drawing.Size(486, 383);
            this.zGC.TabIndex = 2;
            this.zGC.PointValueEvent += new ZedGraph.ZedGraphControl.PointValueHandler(this.zGC_PointValueEvent);
            // 
            // Form6_VolCap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 382);
            this.Controls.Add(this.zGC);
            this.Name = "Form6_VolCap";
            this.Text = "График";
            this.Load += new System.EventHandler(this.Form6_VolCap_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public ZedGraph.ZedGraphControl zGC;

    }
}