using System;
using System.Drawing;
using System.Windows.Forms;

namespace dod6
{
    public partial class Form1 : Form
    {
        int N = 1;
        int i = 0;
        int j = 0;
        int Change;
        double[,] A = new double[6, 6];
        double[] B = new double[6];
        double[] X = new double[6];

        public Form1()
        {
            InitializeComponent();
        }

        private void Decomp(int N, ref int Change)
        {
            int k;
            double R;
            Change = 1;

            double maxEl = Math.Abs(A[1, 1]);
            int maxRow = 1;
            for (i = 2; i <= N; i++)
            {
                if (Math.Abs(A[i, 1]) > maxEl)
                {
                    maxEl = Math.Abs(A[i, 1]);
                    maxRow = i;
                }
            }

            if (maxRow != 1)
            {
                Change = maxRow;
                for (j = 1; j <= N; j++)
                {
                    double temp = A[1, j];
                    A[1, j] = A[maxRow, j];
                    A[maxRow, j] = temp;
                }
            }

            if (A[1, 1] == 0)
            {
                MessageBox.Show("Помилка: a[1,1] = 0. LU-розклад неможливий.");
                return;
            }

            for (i = 2; i <= N; i++)
            {
                A[1, i] = A[1, i] / A[1, 1];
            }

            for (i = 2; i <= N; i++)
            {
                for (k = i; k <= N; k++)
                {
                    R = 0;
                    for (j = 1; j <= i - 1; j++)
                    {
                        R += A[k, j] * A[j, i];
                    }
                    A[k, i] = A[k, i] - R;
                }

                if (A[i, i] == 0)
                {
                    MessageBox.Show("Помилка: Матриця вироджена (a[i,i] = 0). LU-розклад неможливий.");
                    return;
                }

                for (k = i + 1; k <= N; k++)
                {
                    R = 0;
                    for (j = 1; j <= i - 1; j++)
                    {
                        R += A[i, j] * A[j, k];
                    }
                    A[i, k] = (A[i, k] - R) / A[i, i];
                }
            }

            for (i = 0; i < N; i++)
                for (j = 0; j < N; j++)
                {
                    C_matrix_dgv.Rows[i].Cells[j].Value = Convert.ToString(A[i + 1, j + 1]);
                }
        }

        private void Solve(int Change, int N)
        {
            int i, j;
            double R;

            if (Change != 1)
            {
                double temp = B[1];
                B[1] = B[Change];
                B[Change] = temp;
            }

            B[1] = B[1] / A[1, 1];

            for (i = 2; i <= N; i++)
            {
                R = 0;
                for (j = 1; j <= i - 1; j++)
                {
                    R += A[i, j] * B[j];
                }
                B[i] = (B[i] - R) / A[i, i];
            }

            X[N] = B[N];

            for (i = N - 1; i >= 1; i--)
            {
                R = 0;
                for (j = i + 1; j <= N; j++)
                {
                    R += A[i, j] * X[j];
                }
                X[i] = B[i] - R;
            }
        }

        private void GaussSolve(int N)
        {
            for (int k = 1; k <= N - 1; k++)
            {
                int maxRow = k;
                double maxVal = Math.Abs(A[k, k]);

                for (int i = k + 1; i <= N; i++)
                {
                    if (Math.Abs(A[i, k]) > maxVal)
                    {
                        maxVal = Math.Abs(A[i, k]);
                        maxRow = i;
                    }
                }

                if (maxRow != k)
                {
                    for (int j = 1; j <= N; j++)
                    {
                        double temp = A[k, j];
                        A[k, j] = A[maxRow, j];
                        A[maxRow, j] = temp;
                    }

                    double tempB = B[k];
                    B[k] = B[maxRow];
                    B[maxRow] = tempB;
                }

                if (A[k, k] == 0)
                {
                    MessageBox.Show($"Помилка: нульовий елемент на діагоналі A[{k},{k}].");
                    return;
                }

                for (int i = k + 1; i <= N; i++)
                {
                    double factor = A[i, k] / A[k, k];
                    A[i, k] = 0;  

                    for (int j = k + 1; j <= N; j++)
                    {
                        A[i, j] = A[i, j] - factor * A[k, j];
                    }

                    B[i] = B[i] - factor * B[k];
                }
            }

            if (A[N, N] == 0)
            {
                MessageBox.Show("Помилка: матриця вироджена, розв’язок неможливий.");
                return;
            }

            X[N] = B[N] / A[N, N];

            for (int i = N - 1; i >= 1; i--)
            {
                double sum = 0;
                for (int j = i + 1; j <= N; j++)
                {
                    sum += A[i, j] * X[j];
                }
                X[i] = (B[i] - sum) / A[i, i];
            }

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    C_matrix_dgv.Rows[i].Cells[j].Value = A[i + 1, j + 1].ToString("F3");
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            X_vector_dgv.ReadOnly = true;

            A_matrix_dgv.AllowUserToAddRows = false;
            B_vector_dgv.AllowUserToAddRows = false;
            X_vector_dgv.AllowUserToAddRows = false;
            C_matrix_dgv.AllowUserToAddRows = false;

            A_matrix_dgv.ColumnCount = 1;
            A_matrix_dgv.RowCount = 1;
            X_vector_dgv.ColumnCount = 1;
            X_vector_dgv.RowCount = 1;
            B_vector_dgv.ColumnCount = 1;
            B_vector_dgv.RowCount = 1;
            C_matrix_dgv.ColumnCount = 1;
            C_matrix_dgv.RowCount = 1;

            Cmb_MethodSelection.Items.Add("Метод LU-розкладу");
            Cmb_MethodSelection.Items.Add("Метод Гауса");
            Cmb_MethodSelection.SelectedIndex = 0;
        }

        private void NUD_rozmir_ValueChanged(object sender, EventArgs e)
        {
            N = Convert.ToInt16(NUD_rozmir.Value);
            A_matrix_dgv.RowCount = N;
            A_matrix_dgv.ColumnCount = N;
            X_vector_dgv.RowCount = N;
            B_vector_dgv.RowCount = N;
            C_matrix_dgv.RowCount = N;
            C_matrix_dgv.ColumnCount = N;
        }

        private void BCreateGrid_Click(object sender, EventArgs e)
        {
            bool exc_A = false;
            bool exc_B = false;

            for (i = 0; i < N; i++)
            {
                for (j = 0; j < N; j++)
                {
                    C_matrix_dgv[j, i].Value = "";
                }
            }


            for (i = 1; i <= N; i++)
            {
                for (j = 1; j <= N; j++)
                {
                    try
                    {
                        A[i, j] = Convert.ToDouble(A_matrix_dgv[j - 1, i - 1].Value);
                    }
                    catch
                    {
                        A_matrix_dgv[j - 1, i - 1].Style.ForeColor = Color.Red;
                        exc_A = true;
                    }
                }
            }

            for (j = 0; j < N; j++)
            {
                try
                {
                    B[j + 1] = Convert.ToDouble(B_vector_dgv[0, j].Value);
                }
                catch
                {
                    B_vector_dgv[0, j].Style.ForeColor = Color.Red;
                    exc_B = true;
                }
            }

            if (exc_A || exc_B)
            {
                MessageBox.Show("Помилка введення!");
                return;
            }

            string selectedMethod = Cmb_MethodSelection.SelectedItem.ToString();

            if (selectedMethod == "Метод LU-розкладу")
            {
                Decomp(N, ref Change);
                Solve(Change, N);
            }
            else if (selectedMethod == "Метод Гауса")
            {
                GaussSolve(N);
            }

            {
                for (i = 0; i < N; i++)
                {
                    X_vector_dgv[0, i].Value = X[i + 1].ToString();
                }
                MessageBox.Show("Розв'язок знайдено");
            }
        }

        private void BClear_Click(object sender, EventArgs e)
        {
            for (i = 0; i < N; i++)
            {
                for (j = 0; j < N; j++)
                {
                    A_matrix_dgv[j, i].Value = "";
                    C_matrix_dgv[j, i].Value = "";
                }
            }

            for (j = 0; j < N; j++)
            {
                B_vector_dgv[0, j].Value = "";
                X_vector_dgv[0, j].Value = "";
            }
        }

        private void BClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void A_matrix_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            A_matrix_dgv.CurrentCell.Style.ForeColor = Color.Black;
        }

        private void B_vector_dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            B_vector_dgv.CurrentCell.Style.ForeColor = Color.Black;
        }
    }
}