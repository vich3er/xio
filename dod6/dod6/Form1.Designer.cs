using static System.Net.Mime.MediaTypeNames;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Xml.Linq;

namespace dod6
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            A_matrix_dgv = new DataGridView();
            C_matrix_dgv = new DataGridView();
            B_vector_dgv = new DataGridView();
            X_vector_dgv = new DataGridView();
            BCreateGrid = new Button();
            BClear = new Button();
            BClose = new Button();
            NUD_rozmir = new NumericUpDown();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            Cmb_MethodSelection = new ComboBox();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)A_matrix_dgv).BeginInit();
            ((System.ComponentModel.ISupportInitialize)C_matrix_dgv).BeginInit();
            ((System.ComponentModel.ISupportInitialize)B_vector_dgv).BeginInit();
            ((System.ComponentModel.ISupportInitialize)X_vector_dgv).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NUD_rozmir).BeginInit();
            SuspendLayout();
            // 
            // A_matrix_dgv
            // 
            A_matrix_dgv.AllowUserToAddRows = false;
            A_matrix_dgv.AllowUserToDeleteRows = false;
            A_matrix_dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            A_matrix_dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            A_matrix_dgv.ColumnHeadersVisible = false;
            A_matrix_dgv.Location = new Point(16, 106);
            A_matrix_dgv.Margin = new Padding(4, 5, 4, 5);
            A_matrix_dgv.Name = "A_matrix_dgv";
            A_matrix_dgv.RowHeadersVisible = false;
            A_matrix_dgv.RowHeadersWidth = 51;
            A_matrix_dgv.Size = new Size(433, 231);
            A_matrix_dgv.TabIndex = 0;
            A_matrix_dgv.CellClick += A_matrix_dgv_CellClick;
            // 
            // C_matrix_dgv
            // 
            C_matrix_dgv.AllowUserToAddRows = false;
            C_matrix_dgv.AllowUserToDeleteRows = false;
            C_matrix_dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            C_matrix_dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            C_matrix_dgv.ColumnHeadersVisible = false;
            C_matrix_dgv.Location = new Point(16, 409);
            C_matrix_dgv.Margin = new Padding(4, 5, 4, 5);
            C_matrix_dgv.Name = "C_matrix_dgv";
            C_matrix_dgv.ReadOnly = true;
            C_matrix_dgv.RowHeadersVisible = false;
            C_matrix_dgv.RowHeadersWidth = 51;
            C_matrix_dgv.Size = new Size(433, 231);
            C_matrix_dgv.TabIndex = 1;
            // 
            // B_vector_dgv
            // 
            B_vector_dgv.AllowUserToAddRows = false;
            B_vector_dgv.AllowUserToDeleteRows = false;
            B_vector_dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            B_vector_dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            B_vector_dgv.ColumnHeadersVisible = false;
            B_vector_dgv.Location = new Point(472, 106);
            B_vector_dgv.Margin = new Padding(4, 5, 4, 5);
            B_vector_dgv.Name = "B_vector_dgv";
            B_vector_dgv.RowHeadersVisible = false;
            B_vector_dgv.RowHeadersWidth = 51;
            B_vector_dgv.Size = new Size(127, 231);
            B_vector_dgv.TabIndex = 2;
            B_vector_dgv.CellClick += B_vector_dgv_CellClick;
            // 
            // X_vector_dgv
            // 
            X_vector_dgv.AllowUserToAddRows = false;
            X_vector_dgv.AllowUserToDeleteRows = false;
            X_vector_dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            X_vector_dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            X_vector_dgv.ColumnHeadersVisible = false;
            X_vector_dgv.Location = new Point(625, 106);
            X_vector_dgv.Margin = new Padding(4, 5, 4, 5);
            X_vector_dgv.Name = "X_vector_dgv";
            X_vector_dgv.ReadOnly = true;
            X_vector_dgv.RowHeadersVisible = false;
            X_vector_dgv.RowHeadersWidth = 51;
            X_vector_dgv.Size = new Size(127, 231);
            X_vector_dgv.TabIndex = 3;
            // 
            // BCreateGrid
            // 
            BCreateGrid.Location = new Point(472, 409);
            BCreateGrid.Margin = new Padding(4, 5, 4, 5);
            BCreateGrid.Name = "BCreateGrid";
            BCreateGrid.Size = new Size(139, 52);
            BCreateGrid.TabIndex = 4;
            BCreateGrid.Text = "Розв'язати";
            BCreateGrid.UseVisualStyleBackColor = true;
            BCreateGrid.Click += BCreateGrid_Click;
            // 
            // BClear
            // 
            BClear.Location = new Point(625, 409);
            BClear.Margin = new Padding(4, 5, 4, 5);
            BClear.Name = "BClear";
            BClear.Size = new Size(127, 52);
            BClear.TabIndex = 5;
            BClear.Text = "Очистити";
            BClear.UseVisualStyleBackColor = true;
            BClear.Click += BClear_Click;
            // 
            // BClose
            // 
            BClose.Location = new Point(549, 502);
            BClose.Margin = new Padding(4, 5, 4, 5);
            BClose.Name = "BClose";
            BClose.Size = new Size(127, 52);
            BClose.TabIndex = 6;
            BClose.Text = "Вихід";
            BClose.UseVisualStyleBackColor = true;
            BClose.Click += BClose_Click;
            // 
            // NUD_rozmir
            // 
            NUD_rozmir.Location = new Point(264, 26);
            NUD_rozmir.Margin = new Padding(4, 5, 4, 5);
            NUD_rozmir.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            NUD_rozmir.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            NUD_rozmir.Name = "NUD_rozmir";
            NUD_rozmir.Size = new Size(61, 27);
            NUD_rozmir.TabIndex = 7;
            NUD_rozmir.Value = new decimal(new int[] { 1, 0, 0, 0 });
            NUD_rozmir.ValueChanged += NUD_rozmir_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(61, 29);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(191, 20);
            label1.TabIndex = 8;
            label1.Text = "Оберіть розмір матриці А";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 82);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(215, 20);
            label2.TabIndex = 9;
            label2.Text = "Матриця А коефіцієнтів СЛАР";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(16, 385);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(318, 20);
            label3.TabIndex = 10;
            label3.Text = "Матриця L/U розкладу або трикутна матриця";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(468, 82);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(70, 20);
            label4.TabIndex = 11;
            label4.Text = "Вектор B";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(621, 82);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(70, 20);
            label5.TabIndex = 12;
            label5.Text = "Вектор X";
            // 
            // Cmb_MethodSelection
            // 
            Cmb_MethodSelection.DropDownStyle = ComboBoxStyle.DropDownList;
            Cmb_MethodSelection.FormattingEnabled = true;
            Cmb_MethodSelection.Location = new Point(513, 26);
            Cmb_MethodSelection.Name = "Cmb_MethodSelection";
            Cmb_MethodSelection.Size = new Size(178, 28);
            Cmb_MethodSelection.TabIndex = 13;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(389, 29);
            label6.Name = "label6";
            label6.Size = new Size(118, 20);
            label6.TabIndex = 14;
            label6.Text = "Оберіть метод:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(772, 660);
            Controls.Add(label6);
            Controls.Add(Cmb_MethodSelection);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(NUD_rozmir);
            Controls.Add(BClose);
            Controls.Add(BClear);
            Controls.Add(BCreateGrid);
            Controls.Add(X_vector_dgv);
            Controls.Add(B_vector_dgv);
            Controls.Add(C_matrix_dgv);
            Controls.Add(A_matrix_dgv);
            Margin = new Padding(4, 5, 4, 5);
            Name = "Form1";
            Text = "Чередник Метод L / U перетворення для розв'язання СЛАР";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)A_matrix_dgv).EndInit();
            ((System.ComponentModel.ISupportInitialize)C_matrix_dgv).EndInit();
            ((System.ComponentModel.ISupportInitialize)B_vector_dgv).EndInit();
            ((System.ComponentModel.ISupportInitialize)X_vector_dgv).EndInit();
            ((System.ComponentModel.ISupportInitialize)NUD_rozmir).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView A_matrix_dgv;
        private System.Windows.Forms.DataGridView C_matrix_dgv;
        private System.Windows.Forms.DataGridView B_vector_dgv;
        private System.Windows.Forms.DataGridView X_vector_dgv;
        private System.Windows.Forms.Button BCreateGrid;
        private System.Windows.Forms.Button BClear;
        private System.Windows.Forms.Button BClose;
        private System.Windows.Forms.NumericUpDown NUD_rozmir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private ComboBox Cmb_MethodSelection;
        private Label label6;
    }
}