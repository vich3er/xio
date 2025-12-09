namespace lab10_dod
{
    partial class Form1
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

        #region Код, автоматично згенерований дизайнером форм Windows

        private void InitializeComponent()
        {
            labelTitle = new Label();
            labelN = new Label();
            numericUpDownN = new NumericUpDown();
            labelX0 = new Label();
            dgvInitialConditions = new DataGridView();
            dgvSolutionVectorClassic = new DataGridView();
            labelXClassic = new Label();
            labelEps = new Label();
            textBoxEps = new TextBox();
            labelKMax = new Label();
            textBoxKMax = new TextBox();
            buttonSolve = new Button();
            buttonClear = new Button();
            buttonExit = new Button();
            labelNIterClassic = new Label();
            textBoxNIterClassic = new TextBox();
            labelParams = new Label();
            labelX_Raphson = new Label();
            dgvSolutionVectorRaphson = new DataGridView();
            labelNIterRaphson = new Label();
            textBoxNIterRaphson = new TextBox();
            ((System.ComponentModel.ISupportInitialize)numericUpDownN).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvInitialConditions).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvSolutionVectorClassic).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvSolutionVectorRaphson).BeginInit();
            SuspendLayout();
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelTitle.Location = new Point(12, 9);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(255, 28);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Метод Ньютона для СНР";
            // 
            // labelN
            // 
            labelN.AutoSize = true;
            labelN.Location = new Point(12, 50);
            labelN.Name = "labelN";
            labelN.Size = new Size(186, 20);
            labelN.TabIndex = 1;
            labelN.Text = "Оберіть розмірність СНР:";
            // 
            // numericUpDownN
            // 
            numericUpDownN.Location = new Point(201, 48);
            numericUpDownN.Minimum = new decimal(new int[] { 2, 0, 0, 0 });
            numericUpDownN.Name = "numericUpDownN";
            numericUpDownN.Size = new Size(50, 27);
            numericUpDownN.TabIndex = 2;
            numericUpDownN.Value = new decimal(new int[] { 3, 0, 0, 0 });
            numericUpDownN.ValueChanged += numericUpDownN_ValueChanged;
            // 
            // labelX0
            // 
            labelX0.AutoSize = true;
            labelX0.Location = new Point(12, 90);
            labelX0.Name = "labelX0";
            labelX0.Size = new Size(282, 20);
            labelX0.TabIndex = 3;
            labelX0.Text = "Елементи вектора початкових умов X0:";
            labelX0.Click += labelX0_Click;
            // 
            // dgvInitialConditions
            // 
            dgvInitialConditions.AllowUserToResizeColumns = false;
            dgvInitialConditions.AllowUserToResizeRows = false;
            dgvInitialConditions.BackgroundColor = SystemColors.ControlLightLight;
            dgvInitialConditions.BorderStyle = BorderStyle.Fixed3D;
            dgvInitialConditions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInitialConditions.Location = new Point(15, 110);
            dgvInitialConditions.Name = "dgvInitialConditions";
            dgvInitialConditions.RowHeadersWidth = 51;
            dgvInitialConditions.RowTemplate.Height = 24;
            dgvInitialConditions.Size = new Size(260, 180);
            dgvInitialConditions.TabIndex = 4;
            // 
            // dgvSolutionVectorClassic
            // 
            dgvSolutionVectorClassic.AllowUserToResizeColumns = false;
            dgvSolutionVectorClassic.AllowUserToResizeRows = false;
            dgvSolutionVectorClassic.BackgroundColor = SystemColors.ControlLightLight;
            dgvSolutionVectorClassic.BorderStyle = BorderStyle.Fixed3D;
            dgvSolutionVectorClassic.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSolutionVectorClassic.Location = new Point(400, 110);
            dgvSolutionVectorClassic.Name = "dgvSolutionVectorClassic";
            dgvSolutionVectorClassic.RowHeadersWidth = 51;
            dgvSolutionVectorClassic.RowTemplate.Height = 24;
            dgvSolutionVectorClassic.Size = new Size(350, 180);
            dgvSolutionVectorClassic.TabIndex = 5;
            // 
            // labelXClassic
            // 
            labelXClassic.AutoSize = true;
            labelXClassic.Location = new Point(397, 90);
            labelXClassic.Name = "labelXClassic";
            labelXClassic.Size = new Size(227, 20);
            labelXClassic.TabIndex = 6;
            labelXClassic.Text = "X* (Класичний метод Ньютона)";
            // 
            // labelEps
            // 
            labelEps.AutoSize = true;
            labelEps.Location = new Point(290, 120);
            labelEps.Name = "labelEps";
            labelEps.Size = new Size(98, 20);
            labelEps.TabIndex = 7;
            labelEps.Text = "Точність Eps:";
            // 
            // textBoxEps
            // 
            textBoxEps.Location = new Point(293, 140);
            textBoxEps.Name = "textBoxEps";
            textBoxEps.Size = new Size(90, 27);
            textBoxEps.TabIndex = 8;
            textBoxEps.Text = "1e-6";
            // 
            // labelKMax
            // 
            labelKMax.AutoSize = true;
            labelKMax.Location = new Point(290, 175);
            labelKMax.Name = "labelKMax";
            labelKMax.Size = new Size(49, 20);
            labelKMax.TabIndex = 9;
            labelKMax.Text = "KMax:";
            // 
            // textBoxKMax
            // 
            textBoxKMax.Location = new Point(293, 195);
            textBoxKMax.Name = "textBoxKMax";
            textBoxKMax.Size = new Size(90, 27);
            textBoxKMax.TabIndex = 10;
            textBoxKMax.Text = "15";
            // 
            // buttonSolve
            // 
            buttonSolve.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            buttonSolve.Location = new Point(15, 310);
            buttonSolve.Name = "buttonSolve";
            buttonSolve.Size = new Size(120, 40);
            buttonSolve.TabIndex = 11;
            buttonSolve.Text = "Розв'язати";
            buttonSolve.UseVisualStyleBackColor = true;
            buttonSolve.Click += buttonSolve_Click;
            // 
            // buttonClear
            // 
            buttonClear.Location = new Point(145, 310);
            buttonClear.Name = "buttonClear";
            buttonClear.Size = new Size(120, 40);
            buttonClear.TabIndex = 12;
            buttonClear.Text = "Очистити";
            buttonClear.UseVisualStyleBackColor = true;
            buttonClear.Click += buttonClear_Click;
            // 
            // buttonExit
            // 
            buttonExit.Location = new Point(275, 310);
            buttonExit.Name = "buttonExit";
            buttonExit.Size = new Size(120, 40);
            buttonExit.TabIndex = 13;
            buttonExit.Text = "Завершити";
            buttonExit.UseVisualStyleBackColor = true;
            buttonExit.Click += buttonExit_Click;
            // 
            // labelNIterClassic
            // 
            labelNIterClassic.AutoSize = true;
            labelNIterClassic.Location = new Point(400, 300);
            labelNIterClassic.Name = "labelNIterClassic";
            labelNIterClassic.Size = new Size(144, 20);
            labelNIterClassic.TabIndex = 14;
            labelNIterClassic.Text = "Кл. Ньютон (N_Iter):";
            // 
            // textBoxNIterClassic
            // 
            textBoxNIterClassic.Location = new Point(403, 320);
            textBoxNIterClassic.Name = "textBoxNIterClassic";
            textBoxNIterClassic.ReadOnly = true;
            textBoxNIterClassic.Size = new Size(100, 27);
            textBoxNIterClassic.TabIndex = 15;
            // 
            // labelParams
            // 
            labelParams.AutoSize = true;
            labelParams.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelParams.Location = new Point(290, 90);
            labelParams.Name = "labelParams";
            labelParams.Size = new Size(91, 20);
            labelParams.TabIndex = 16;
            labelParams.Text = "Вхідні дані:";
            // 
            // labelX_Raphson
            // 
            labelX_Raphson.AutoSize = true;
            labelX_Raphson.Location = new Point(777, 90);
            labelX_Raphson.Name = "labelX_Raphson";
            labelX_Raphson.Size = new Size(214, 20);
            labelX_Raphson.TabIndex = 17;
            labelX_Raphson.Text = "X* (Метод Ньютона-Рафсона)";
            // 
            // dgvSolutionVectorRaphson
            // 
            dgvSolutionVectorRaphson.AllowUserToResizeColumns = false;
            dgvSolutionVectorRaphson.AllowUserToResizeRows = false;
            dgvSolutionVectorRaphson.BackgroundColor = SystemColors.ControlLightLight;
            dgvSolutionVectorRaphson.BorderStyle = BorderStyle.Fixed3D;
            dgvSolutionVectorRaphson.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSolutionVectorRaphson.Location = new Point(780, 110);
            dgvSolutionVectorRaphson.Name = "dgvSolutionVectorRaphson";
            dgvSolutionVectorRaphson.RowHeadersWidth = 51;
            dgvSolutionVectorRaphson.RowTemplate.Height = 24;
            dgvSolutionVectorRaphson.Size = new Size(350, 180);
            dgvSolutionVectorRaphson.TabIndex = 18;
            // 
            // labelNIterRaphson
            // 
            labelNIterRaphson.AutoSize = true;
            labelNIterRaphson.Location = new Point(780, 300);
            labelNIterRaphson.Name = "labelNIterRaphson";
            labelNIterRaphson.Size = new Size(177, 20);
            labelNIterRaphson.TabIndex = 19;
            labelNIterRaphson.Text = "Ньютон-Рафсон (N_Iter):";
            // 
            // textBoxNIterRaphson
            // 
            textBoxNIterRaphson.Location = new Point(783, 320);
            textBoxNIterRaphson.Name = "textBoxNIterRaphson";
            textBoxNIterRaphson.ReadOnly = true;
            textBoxNIterRaphson.Size = new Size(100, 27);
            textBoxNIterRaphson.TabIndex = 20;
            // 
            // Form1
            // 
            ClientSize = new Size(1242, 419);
            Controls.Add(textBoxNIterRaphson);
            Controls.Add(labelNIterRaphson);
            Controls.Add(dgvSolutionVectorRaphson);
            Controls.Add(labelX_Raphson);
            Controls.Add(labelParams);
            Controls.Add(textBoxNIterClassic);
            Controls.Add(labelNIterClassic);
            Controls.Add(buttonExit);
            Controls.Add(buttonClear);
            Controls.Add(buttonSolve);
            Controls.Add(textBoxKMax);
            Controls.Add(labelKMax);
            Controls.Add(textBoxEps);
            Controls.Add(labelEps);
            Controls.Add(labelXClassic);
            Controls.Add(dgvSolutionVectorClassic);
            Controls.Add(dgvInitialConditions);
            Controls.Add(labelX0);
            Controls.Add(numericUpDownN);
            Controls.Add(labelN);
            Controls.Add(labelTitle);
            Name = "Form1";
            Text = "КП 10: Метод Ньютона для СНР (Порівняння)";
            ((System.ComponentModel.ISupportInitialize)numericUpDownN).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvInitialConditions).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvSolutionVectorClassic).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvSolutionVectorRaphson).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelN;
        private System.Windows.Forms.NumericUpDown numericUpDownN;
        private System.Windows.Forms.Label labelX0;
        private System.Windows.Forms.DataGridView dgvInitialConditions;
        private System.Windows.Forms.DataGridView dgvSolutionVectorClassic;
        private System.Windows.Forms.Label labelXClassic;
        private System.Windows.Forms.Label labelEps;
        private System.Windows.Forms.TextBox textBoxEps;
        private System.Windows.Forms.Label labelKMax;
        private System.Windows.Forms.TextBox textBoxKMax;
        private System.Windows.Forms.Button buttonSolve;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Label labelNIterClassic;
        private System.Windows.Forms.TextBox textBoxNIterClassic;
        private System.Windows.Forms.Label labelParams;
        private System.Windows.Forms.Label labelX_Raphson;
        private System.Windows.Forms.DataGridView dgvSolutionVectorRaphson;
        private System.Windows.Forms.Label labelNIterRaphson;
        private System.Windows.Forms.TextBox textBoxNIterRaphson;
    }
}