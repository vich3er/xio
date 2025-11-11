namespace DodZavdOOP
{
    partial class FormTransport
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            btnDemonstrate = new Button();
            btnClear = new Button();
            btnExit = new Button();
            txtLog = new TextBox();
            txtSummary = new TextBox();
            lblTitle = new Label();
            lblSummary = new Label();
            SuspendLayout();
            // 
            // btnDemonstrate
            // 
            btnDemonstrate.BackColor = Color.LightGreen;
            btnDemonstrate.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnDemonstrate.ForeColor = Color.DarkGreen;
            btnDemonstrate.Location = new Point(286, 71);
            btnDemonstrate.Margin = new Padding(3, 4, 3, 4);
            btnDemonstrate.Name = "btnDemonstrate";
            btnDemonstrate.Size = new Size(206, 53);
            btnDemonstrate.TabIndex = 1;
            btnDemonstrate.Text = "Демонструвати";
            btnDemonstrate.UseVisualStyleBackColor = false;
            btnDemonstrate.Click += btnDemonstrate_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FloralWhite;
            btnClear.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnClear.ForeColor = Color.DarkOrange;
            btnClear.Location = new Point(514, 71);
            btnClear.Margin = new Padding(3, 4, 3, 4);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(171, 53);
            btnClear.TabIndex = 2;
            btnClear.Text = "Очистити";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.LightCoral;
            btnExit.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnExit.ForeColor = Color.DarkRed;
            btnExit.Location = new Point(709, 71);
            btnExit.Margin = new Padding(3, 4, 3, 4);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(171, 53);
            btnExit.TabIndex = 3;
            btnExit.Text = " Вихід";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // txtLog
            // 
            txtLog.BackColor = Color.WhiteSmoke;
            txtLog.Font = new Font("Consolas", 9F);
            txtLog.Location = new Point(14, 171);
            txtLog.Margin = new Padding(3, 4, 3, 4);
            txtLog.Multiline = true;
            txtLog.Name = "txtLog";
            txtLog.ReadOnly = true;
            txtLog.ScrollBars = ScrollBars.Vertical;
            txtLog.Size = new Size(742, 546);
            txtLog.TabIndex = 5;
            // 
            // txtSummary
            // 
            txtSummary.BackColor = Color.Honeydew;
            txtSummary.Font = new Font("Segoe UI", 9.5F);
            txtSummary.Location = new Point(775, 171);
            txtSummary.Margin = new Padding(3, 4, 3, 4);
            txtSummary.Multiline = true;
            txtSummary.Name = "txtSummary";
            txtSummary.ReadOnly = true;
            txtSummary.ScrollBars = ScrollBars.Vertical;
            txtSummary.Size = new Size(354, 546);
            txtSummary.TabIndex = 7;
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.DarkBlue;
            lblTitle.Location = new Point(14, 18);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(1115, 35);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Демонстрація Концепцій ООП: Транспортна Система";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSummary
            // 
            lblSummary.AutoSize = true;
            lblSummary.Dock = DockStyle.Left;
            lblSummary.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSummary.Location = new Point(0, 0);
            lblSummary.Name = "lblSummary";
            lblSummary.Size = new Size(0, 23);
            lblSummary.TabIndex = 6;
            lblSummary.Click += lblSummary_Click;
            // 
            // FormTransport
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1143, 757);
            Controls.Add(txtSummary);
            Controls.Add(lblSummary);
            Controls.Add(txtLog);
            Controls.Add(btnExit);
            Controls.Add(btnClear);
            Controls.Add(btnDemonstrate);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormTransport";
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterScreen;
            Text = " ";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnDemonstrate;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.TextBox txtSummary;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSummary;
    }
}