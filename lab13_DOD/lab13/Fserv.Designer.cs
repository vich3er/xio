namespace lab13
{
    partial class FServ
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox FServTB;
        private System.Windows.Forms.Button FServBOk;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.FServTB = new System.Windows.Forms.TextBox();
            this.FServBOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FServTB
            // 
            this.FServTB.Location = new System.Drawing.Point(12, 25);
            this.FServTB.Name = "FServTB";
            this.FServTB.Size = new System.Drawing.Size(360, 20);
            this.FServTB.TabIndex = 0;
            // 
            // FServBOk
            // 
            this.FServBOk.Location = new System.Drawing.Point(150, 60);
            this.FServBOk.Name = "FServBOk";
            this.FServBOk.Size = new System.Drawing.Size(75, 23);
            this.FServBOk.TabIndex = 1;
            this.FServBOk.Text = "Ввести";
            this.FServBOk.UseVisualStyleBackColor = true;
            this.FServBOk.Click += new System.EventHandler(this.FServBOk_Click);
            // 
            // FServ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 111);
            this.Controls.Add(this.FServBOk);
            this.Controls.Add(this.FServTB);
            this.Name = "FServ";
            this.Text = "Введення параметру";
            this.Load += new System.EventHandler(this.FServ_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}