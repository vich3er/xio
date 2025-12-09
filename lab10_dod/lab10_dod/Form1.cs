using System;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;
using System.Linq;

namespace lab10_dod
{
    public partial class Form1 : Form
    {

        private int N = 3;
        public double[,] Ja = new double[4, 4];
        public double[] X0 = new double[4];
        public double[] X_classic = new double[4];
        public double[] X_raphson = new double[4];
        public double[] F = new double[4];
        public double[] Dx = new double[4];
        public double[] Fp = new double[4];

        private const double Q_perturbation = 0.000001D;
        private const double ZERO_TOLERANCE = 1e-15;



        public Form1()
        {
            InitializeComponent();
            InitializeDataGrids();
            UpdateN();
        }

        private void UpdateN()
        {
            N = (int)numericUpDownN.Value;

            dgvInitialConditions.RowCount = N;
            dgvInitialConditions.ColumnCount = 1;
            dgvInitialConditions.Columns[0].Width = 100;
            dgvInitialConditions.Columns[0].HeaderText = "X0";

            for (int i = 0; i < N; i++)
            {
                dgvInitialConditions.Rows[i].HeaderCell.Value = $"x{i + 1}";
            }

            dgvSolutionVectorClassic.RowCount = N;
            dgvSolutionVectorClassic.ColumnCount = 1;
            dgvSolutionVectorClassic.Columns[0].Width = 200;
            dgvSolutionVectorClassic.Columns[0].HeaderText = "X*";

            for (int i = 0; i < N; i++)
            {
                dgvSolutionVectorClassic.Rows[i].HeaderCell.Value = $"x{i + 1}";
            }

            dgvSolutionVectorRaphson.RowCount = N;
            dgvSolutionVectorRaphson.ColumnCount = 1;
            dgvSolutionVectorRaphson.Columns[0].Width = 200;
            dgvSolutionVectorRaphson.Columns[0].HeaderText = "X*";

            for (int i = 0; i < N; i++)
            {
                dgvSolutionVectorRaphson.Rows[i].HeaderCell.Value = $"x{i + 1}";
            }
        }

        private void numericUpDownN_ValueChanged(object sender, EventArgs e)
        {
            UpdateN();
        }

        private void ReadInitialConditions(DataGridView dgv, double[] X0, int N)
        {
            for (int i = 1; i <= N; i++)
            {
                if (dgv.Rows[i - 1].Cells[0].Value != null)
                {
                    string cellValue = dgv.Rows[i - 1].Cells[0].Value.ToString();
                    if (!double.TryParse(cellValue, NumberStyles.Any, CultureInfo.InvariantCulture, out X0[i]))
                    {
                        throw new FormatException($"Некоректний формат числа для x{i}. Використовуйте крапку як розділювач.");
                    }
                }
                else
                {
                    throw new Exception($"Не введено початкову умову для x{i}");
                }
            }
        }

        private void DisplaySolution(DataGridView dgv, double[] X, int N)
        {
            dgv.Rows.Clear();
            dgv.RowCount = N;
            for (int i = 1; i <= N; i++)
            {
                dgv.Rows[i - 1].HeaderCell.Value = $"x{i}";
                dgv.Rows[i - 1].Cells[0].Value = X[i].ToString("0.################", CultureInfo.InvariantCulture);
            }
        }



        public void FM(double[] X, ref double[] f)
        {
            f[1] = X[1] + Math.Exp(X[1] - 1.0D) + (X[2] + X[3]) * (X[2] + X[3]) - 27.0D;
            f[2] = X[1] * Math.Exp(X[2] - 2.0D) + X[3] * X[3] - 10.0D;
            f[3] = X[3] + Math.Sin(X[2] - 2.0D) + X[2] * X[2] - 7.0D;
        }

        public double[,] Jacob(double[] X)
        {
            double[] X_copy = (double[])X.Clone();
            double[,] Ja_new = new double[4, 4];

            FM(X_copy, ref F);

            for (int j = 1; j <= N; j++)
            {
                X_copy[j] = X_copy[j] + Q_perturbation;
                FM(X_copy, ref Fp);

                for (int i = 1; i <= N; i++)
                {
                    Ja_new[i, j] = (Fp[i] - F[i]) / Q_perturbation;
                }

                X_copy[j] = X_copy[j] - Q_perturbation;
            }

            return Ja_new;
        }

        public void Decomp(double[,] A, int N)
        {
            for (int i = 1; i <= N; i++)
            {
                for (int j = i; j <= N; j++)
                {
                    double sum = 0;
                    for (int k = 1; k < i; k++)
                    {
                        sum += A[i, k] * A[k, j];
                    }
                    A[i, j] = A[i, j] - sum;
                }

                if (i < N)
                {
                    if (Math.Abs(A[i, i]) < ZERO_TOLERANCE)
                    {
                        throw new Exception("Матриця Якобі вироджена (нульовий опорний елемент при LU-розкладі).");
                    }
                    for (int j = i + 1; j <= N; j++)
                    {
                        double sum = 0;
                        for (int k = 1; k < i; k++)
                        {
                            sum += A[j, k] * A[k, i];
                        }
                        A[j, i] = (A[j, i] - sum) / A[i, i];
                    }
                }
            }
        }

        public void Solve_LU(double[,] LU, double[] F, ref double[] Dx, int N)
        {
            double[] Y = new double[N + 1];

            // 1. L * Y = F
            for (int i = 1; i <= N; i++)
            {
                double sum = 0;
                for (int k = 1; k < i; k++)
                {
                    sum += LU[i, k] * Y[k];
                }
                Y[i] = F[i] - sum;
            }

            // 2. U * Dx = Y
            for (int i = N; i >= 1; i--)
            {
                double sum = 0;
                for (int k = i + 1; k <= N; k++)
                {
                    sum += LU[i, k] * Dx[k];
                }
                if (Math.Abs(LU[i, i]) < ZERO_TOLERANCE)
                {
                    throw new Exception("Вироджена матриця U.");
                }
                Dx[i] = (Y[i] - sum) / LU[i, i];
            }
        }

        public void GAUSS_Classic(double[,] A, double[] b, ref double[] x, int N)
        {
            double[,] Ab = new double[N + 1, N + 2];
            for (int i = 1; i <= N; i++)
            {
                for (int j = 1; j <= N; j++)
                {
                    Ab[i, j] = A[i, j];
                }
                Ab[i, N + 1] = b[i];
                x[i] = 0.0;
            }

            // прямий хід 
            for (int k = 1; k <= N; k++)
            {
                int pivotRow = k;
                for (int i = k + 1; i <= N; i++)
                {
                    if (Math.Abs(Ab[i, k]) > Math.Abs(Ab[pivotRow, k]))
                    {
                        pivotRow = i;
                    }
                }

                if (pivotRow != k)
                {
                    for (int j = k; j <= N + 1; j++)
                    {
                        double temp = Ab[k, j];
                        Ab[k, j] = Ab[pivotRow, j];
                        Ab[pivotRow, j] = temp;
                    }
                }

                double pivot = Ab[k, k];
                if (Math.Abs(pivot) < ZERO_TOLERANCE)
                {
                    throw new Exception("Матриця Якобі вироджена.");
                }

                for (int i = k + 1; i <= N; i++)
                {
                    double factor = Ab[i, k] / pivot;
                    for (int j = k; j <= N + 1; j++)
                    {
                        Ab[i, j] = Ab[i, j] - factor * Ab[k, j];
                    }
                }
            }

            // зворотний хід 
            for (int i = N; i >= 1; i--)
            {
                double sum = 0;
                for (int j = i + 1; j <= N; j++)
                {
                    sum = sum + Ab[i, j] * x[j];
                }
                x[i] = (Ab[i, N + 1] - sum) / Ab[i, i];
            }
        }


        private void buttonSolve_Click(object sender, EventArgs e)
        {
            double Eps;
            int KMax;
            dgvSolutionVectorClassic.Rows.Clear();
            dgvSolutionVectorRaphson.Rows.Clear();
            textBoxNIterClassic.Text = "";
            textBoxNIterRaphson.Text = "";

            try
            {
                N = (int)numericUpDownN.Value;
                Eps = Convert.ToDouble(textBoxEps.Text.Replace(',', '.'), CultureInfo.InvariantCulture);
                KMax = Convert.ToInt32(textBoxKMax.Text);

                ReadInitialConditions(dgvInitialConditions, X0, N);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка введення даних: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //  метод Ньютона

            X_classic = (double[])X0.Clone();
            int k_classic = 0;
            try
            {
                for (int k = 1; k <= KMax; k++)
                {
                    k_classic = k;
                    FM(X_classic, ref F);
                    Ja = Jacob(X_classic);

                    GAUSS_Classic(Ja, F, ref Dx, N);

                    double dxmax = 0.0D;
                    for (int i = 1; i <= N; i++)
                    {
                        X_classic[i] = X_classic[i] - Dx[i];
                        if (Math.Abs(Dx[i]) > dxmax)
                            dxmax = Math.Abs(Dx[i]);
                    }

                    if (dxmax < Eps)
                    {
                        textBoxNIterClassic.Text = Convert.ToString(k);
                        DisplaySolution(dgvSolutionVectorClassic, X_classic, N);
                        MessageBox.Show($"Класичний метод Ньютона зійшовся за {k} ітерацій.", "Результат: Класичний Ньютон", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                    if (k == KMax) textBoxNIterClassic.Text = "N/A";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка у Класичному Ньютоні (ітерація {k_classic}): {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxNIterClassic.Text = "ERR";
            }

            if (textBoxNIterClassic.Text == "N/A")
            {
                MessageBox.Show($"Класичний метод Ньютона не зійшовся за {KMax} ітерацій.", "Результат: Класичний Ньютон", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            //метод Ньютона-Рафсона

            X_raphson = (double[])X0.Clone();
            int k_raphson = 0;

            try
            {
                // 1.Обчислення Ja(X0) та LU-розклад (Один раз)
                double[,] Ja_Raphson = Jacob(X_raphson);
                Decomp(Ja_Raphson, N);

                //2ю Ітераційний цикл
                for (int k = 1; k <= KMax; k++)
                {
                    k_raphson = k;
                    FM(X_raphson, ref F);

                    Solve_LU(Ja_Raphson, F, ref Dx, N);

                    double dxmax = 0.0D;
                    for (int i = 1; i <= N; i++)
                    {
                        X_raphson[i] = X_raphson[i] - Dx[i];
                        if (Math.Abs(Dx[i]) > dxmax)
                            dxmax = Math.Abs(Dx[i]);
                    }

                    if (dxmax < Eps)
                    {
                        textBoxNIterRaphson.Text = Convert.ToString(k);
                        DisplaySolution(dgvSolutionVectorRaphson, X_raphson, N);
                        MessageBox.Show($"Метод Ньютона-Рафсона зійшовся за {k} ітерацій.", "Результат: Ньютон-Рафсон", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                    if (k == KMax) textBoxNIterRaphson.Text = "N/A";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка у Ньютоні-Рафсоні (ітерація {k_raphson}): {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxNIterRaphson.Text = "ERR";
            }

            if (textBoxNIterRaphson.Text == "N/A")
            {
                MessageBox.Show($"Метод Ньютона-Рафсона не зійшовся за {KMax} ітерацій.", "Результат: Ньютон-Рафсон", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            bool classicConverged = int.TryParse(textBoxNIterClassic.Text, out int classicIter);
            bool raphsonConverged = int.TryParse(textBoxNIterRaphson.Text, out int raphsonIter);

            string comparisonMessage = "ПІДСУМОК ПОРІВНЯННЯ\n";

            if (classicConverged)
                comparisonMessage += $"- Класичний Ньютон: {classicIter} ітерацій.\n";
            else
                comparisonMessage += "- Класичний Ньютон: Не зійшовся або Помилка.\n";

            if (raphsonConverged)
                comparisonMessage += $"- Ньютон-Рафсон: {raphsonIter} ітерацій.\n";
            else
                comparisonMessage += "- Ньютон-Рафсон: Не зійшовся або Помилка.\n";

            if (classicConverged && raphsonConverged)
            {
                if (classicIter < raphsonIter)
                    comparisonMessage += "\nКласичний Ньютон виявився швидшим (менше ітерацій).";
                else if (raphsonIter < classicIter)
                    comparisonMessage += "\nНьютон-Рафсон виявився швидшим(менше ітерацій).";
                else
                    comparisonMessage += "\nОбидва методи показали однакову кількість ітерацій.";
            }
            else if (classicConverged || raphsonConverged)
            {
                comparisonMessage += "\nЗійшовся лише один метод.";
            }
            else
            {
                comparisonMessage += "\nЖоден метод не зійшовся або виникла помилка.";
            }

            MessageBox.Show(comparisonMessage, "Загальні результати", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxEps.Text = "1e-6";
            textBoxKMax.Text = "15";
            textBoxNIterClassic.Text = "";
            textBoxNIterRaphson.Text = "";

            Array.Clear(X0, 0, X0.Length);
            Array.Clear(X_classic, 0, X_classic.Length);
            Array.Clear(X_raphson, 0, X_raphson.Length);

            dgvSolutionVectorClassic.Rows.Clear();
            dgvSolutionVectorRaphson.Rows.Clear();

            UpdateN();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InitializeDataGrids()
        {
            dgvInitialConditions.ColumnHeadersVisible = true;
            dgvSolutionVectorClassic.ColumnHeadersVisible = true;
            dgvSolutionVectorRaphson.ColumnHeadersVisible = true;
            dgvInitialConditions.RowHeadersVisible = true;
            dgvSolutionVectorClassic.RowHeadersVisible = true;
            dgvSolutionVectorRaphson.RowHeadersVisible = true;

            dgvInitialConditions.AllowUserToAddRows = false;
            dgvInitialConditions.AllowUserToDeleteRows = false;
            dgvInitialConditions.SelectionMode = DataGridViewSelectionMode.CellSelect;

            dgvSolutionVectorClassic.ReadOnly = true;
            dgvSolutionVectorClassic.AllowUserToAddRows = false;
            dgvSolutionVectorClassic.AllowUserToDeleteRows = false;
            dgvSolutionVectorClassic.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvSolutionVectorRaphson.ReadOnly = true;
            dgvSolutionVectorRaphson.AllowUserToAddRows = false;
            dgvSolutionVectorRaphson.AllowUserToDeleteRows = false;
            dgvSolutionVectorRaphson.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            textBoxEps.Text = "1e-6";
            textBoxKMax.Text = "15";
        }

        private void labelX0_Click(object sender, EventArgs e)
        {

        }
    }
}