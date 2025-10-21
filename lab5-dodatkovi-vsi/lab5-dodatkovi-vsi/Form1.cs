
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace lab5_dodatkovi_vsi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // ЗАВДАННЯ 3: Додано третє рівняння 6x³ - 9x = 0
        // Функція f - ліві частини рівнянь
        double f(double x, ref int k1)
        {
            switch (k1)
            {
                case 0: return x * x - 4;  // x² - 4 = 0
                case 1: return 3 * x - 4 * Math.Log(x) - 5;  // 3x - 4ln(x) - 5 = 0
                case 2: return Math.Cos(x) - x;
            }
            return 0;
        }

        // Перша похідна
        double fp(double x, double d, ref int k1)
        {
            return (f(x + d, ref k1) - f(x, ref k1)) / d;
        }

        // Друга похідна
        double f2p(double x, double d, ref int k1)
        {
            return (f(x + d, ref k1) + f(x - d, ref k1) - 2 * f(x, ref k1)) / (d * d);
        }

        // ЗАВДАННЯ 1: Метод ділення навпіл як void функція
        void MDP(double a, double b, double Eps, ref int k1, ref int L, ref double result)
        {
            double c = 0, Fc;
            while (b - a > Eps)
            {
                c = 0.5 * (b - a) + a;
                L++;
                Fc = f(c, ref k1);
                if (Math.Abs(Fc) < Eps)
                {
                    result = c;
                    return;
                }
                if (f(a, ref k1) * Fc > 0) a = c;
                else b = c;
            }
            result = c;
        }

        // ЗАВДАННЯ 1: Метод Ньютона як void функція
        void MN(double a, double b, double Eps, ref int k1, int Kmax, ref int L, ref double result)
        {
            double x, Dx, D;
            int i;
            Dx = 0.0;
            D = Eps / 100.0;
            x = b;

            if (f(x, ref k1) * f2p(x, D, ref k1) < 0)
                x = a;

            if (f(x, ref k1) * f2p(x, D, ref k1) < 0)
            {
                MessageBox.Show("Для цього рівняння збіжність ітерацій не гарантована");
            }

            for (i = 1; i <= Kmax; i++)
            {
                Dx = f(x, ref k1) / fp(x, D, ref k1);
                x = x - Dx;
                if (Math.Abs(Dx) < Eps)
                {
                    L = i;
                    result = x;
                    return;
                }
            }
            MessageBox.Show("За задану кількість ітерацій кореня не знайдено");
            result = -1000.0;
        }

        // Обробник завантаження форми
        private void Form1_Load(object sender, EventArgs e)
        {
            // Приховуємо поле Kmax при запуску
            label7.Visible = false;
            textBox4.Visible = false;

            // ЗАВДАННЯ 2: Ініціалізація RadioButton
            // За замовчуванням обираємо метод ділення навпіл
            if (radioButton1 != null)
                radioButton1.Checked = true;
        }

        // ЗАВДАННЯ 2: Обробники для RadioButton (вибір методу)
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            // Метод ділення навпіл
            if (radioButton1.Checked)
            {
                label7.Visible = false;
                textBox4.Visible = false;
                textBox1.Clear();
                textBox2.Clear();
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            // Метод Ньютона
            if (radioButton2.Checked)
            {
                label7.Visible = true;
                textBox4.Visible = true;
                textBox1.Clear();
                textBox2.Clear();
            }
        }

        // Обробник кнопки "Розв'язати"
        private void button1_Click(object sender, EventArgs e)
        {
            int L, k = -1, Kmax, m = -1;
            double D, Eps = 0, a, b;
            double result = 0; // ЗАВДАННЯ 1: Змінна для збереження результату
            L = 0;

            // ЗАВДАННЯ 2: Визначаємо метод через RadioButton
            if (radioButton1.Checked)
                m = 0; // Метод ділення навпіл
            else if (radioButton2.Checked)
            {
                m = 1; // Метод Ньютона
                label7.Visible = true;
                textBox4.Visible = true;
                textBox4.Enabled = true;
            }

            if (m == -1)
            {
                MessageBox.Show("Оберіть метод !");
                return;
            }

            textBox1.Enabled = true;
            textBox2.Enabled = true;

            // ЗАВДАННЯ 3: Додано третє рівняння
            switch (comboBox2.SelectedIndex)
            {
                case 0: k = 0; break;
                case 1: k = 1; break;
                case 2: k = 2; break; // НОВЕ рівняння 6x³ - 9x = 0
            }

            if (k == -1)
            {
                MessageBox.Show("Оберіть рівняння !");
                comboBox2.Focus();
                return;
            }

            // Перевірка введення a
            if (textBox1.Text == "")
            {
                MessageBox.Show("Введіть число в textBox1");
                textBox1.Focus();
                return;
            }

            a = Convert.ToDouble(textBox1.Text);
            textBox2.Enabled = true;

            // Перевірка введення b
            if (textBox2.Text == "")
            {
                MessageBox.Show("Введіть число в textBox2");
                textBox2.Focus();
                return;
            }

            b = Convert.ToDouble(textBox2.Text);

            // Міняємо місцями a і b, якщо потрібно
            if (a > b)
            {
                D = a;
                a = b;
                b = D;
                textBox1.Text = Convert.ToString(a);
                textBox2.Text = Convert.ToString(b);
            }

            // Перевірка введення Eps
            if (textBox3.Text == "")
            {
                MessageBox.Show("Введіть число в textBox3");
                textBox3.Focus();
                return;
            }

            Eps = Convert.ToDouble(textBox3.Text);

            if ((Eps > 1e-1) || (Eps <= 0))
            {
                Eps = 1e-4;
                textBox3.Text = Convert.ToString(Eps);
            }

            // Перевірка для методу ділення навпіл
            if (m == 0)
            {
                if ((f(a, ref k)) * (f(b, ref k)) > 0)
                {
                    MessageBox.Show("Введіть правильний інтервал [a, b]!");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox1.Focus();
                    return;
                }
            }

            // Перевірка меж інтервалу
            if (Math.Abs(f(a, ref k)) < Eps)
            {
                textBox6.Text = Convert.ToString(a);  // textBox6 - корінь
                textBox5.Text = Convert.ToString(L);  // textBox5 - кількість
                return;
            }

            if (Math.Abs(f(b, ref k)) < Eps)
            {
                textBox6.Text = Convert.ToString(b);  // textBox6 - корінь
                textBox5.Text = Convert.ToString(L);  // textBox5 - кількість
                return;
            }

            // ЗАВДАННЯ 1: Виклик методів як void функцій
            switch (m)
            {
                case 0: // Метод ділення навпіл
                    {
                        MDP(a, b, Eps, ref k, ref L, ref result);
                        textBox6.Text = Convert.ToString(result);  // textBox6 - корінь
                        textBox5.Text = Convert.ToString(L);        // textBox5 - кількість
                        label10.Text = "К-ть поділів =";
                    }
                    break;
                case 1: // Метод Ньютона
                    {
                        if (textBox4.Text == "")
                        {
                            MessageBox.Show("Введіть число в textBox4");
                            textBox4.Focus();
                            return;
                        }
                        Kmax = Convert.ToInt32(textBox4.Text);
                        MN(a, b, Eps, ref k, Kmax, ref L, ref result);
                        textBox6.Text = Convert.ToString(result);  // textBox6 - корінь
                        textBox5.Text = Convert.ToString(L);        // textBox5 - кількість
                        label10.Text = "К-ть ітерац.=";
                    }
                    break;
            }
        }

        // Обробник кнопки "Очистити"
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();

            // Перевіряємо, який метод обрано
            if (radioButton1.Checked)
            {
                label7.Visible = false;
                textBox4.Visible = false;
            }
            else if (radioButton2.Checked)
            {
                label7.Visible = true;
                textBox4.Visible = true;
            }
        }

        // Обробник кнопки "Закрити"
        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Порожній обробник
        }
    }
}
