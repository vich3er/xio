namespace dod_zav
{
    class Program
    {
        public static double f(double x) => x * x - 4;

      
        public static double fp(double x, double D)
        {
            return (f(x + D) - f(x)) / D;
        }

        
        public static double f2p(double x, double D)
        {
            return (f(x + D) - 2 * f(x) + f(x - D)) / (D * D);
        }

        public static double Bisection(double a, double b, double eps, int Kmax, out int iterations)
        {
            iterations = 0;
            if (f(a) * f(b) > 0)
            {
                Console.WriteLine("На iнтервалi немає кореня");
                return double.NaN;
            }

            double c = 0;
            while (Math.Abs(b - a) > eps && iterations < Kmax)
            {
                c = 0.5 * (a + b);
                iterations++;
                if (Math.Abs(f(c)) < eps) return c;
                else if (f(a) * f(c) < 0) b = c;
                else a = c;
            }

            if (Math.Abs(b - a) > eps)
                Console.WriteLine("Бiсекцiя не досягла точностi за Kmax iтерацiй");

            return (a + b) / 2;
        }

        public static double Newton(double a, double b, double eps, int Kmax, out int iterations)
        {
            iterations = 0;
            double x0 = b; // початкове x0 беремо як b
            double D = eps / 100.0;

            if (f(x0) * f2p(x0, D) < 0)
                x0 = a;
            else if (f(x0) * f2p(x0, D) == 0)
            {
                Console.WriteLine("Для заданого рiвняння збiжнiсть методу Ньютона не гарантується");
                return double.NaN;
            }

            double x = x0;

            for (int i = 1; i <= Kmax; i++)
            {
                double Dx = f(x) / fp(x, D);
                x -= Dx;

                iterations = i;

                if (Math.Abs(Dx) < eps)
                    return x;
            }

            Console.WriteLine("Корiнь не знайдено за задану кiлькiсть iтерацiй");
            return x;
        }

        public static bool FindInterval(double start, double end, double step, out double a, out double b)
        {
            a = start; b = start + step;
            while (b <= end)
            {
                if (f(a) * f(b) <= 0) return true;
                a = b;
                b += step;
            }
            return false;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Виберiть метод:\n1 - Метод дiлення навпiл (МДН)\n2 - Метод Ньютона (МН)");
            int method = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Виберiть спосiб визначення iнтервалу:");
            Console.WriteLine("1 - Ввести вручну");
            Console.WriteLine("2 - Автоматично знайти iнтервал");
            int intervalChoice = Convert.ToInt32(Console.ReadLine());

            double a = 0, b = 0;
            bool intervalFound = false;

            if (intervalChoice == 1)
            {
                Console.Write("Введiть початок iнтервалу a: ");
                a = Convert.ToDouble(Console.ReadLine());
                Console.Write("Введiть кiнець iнтервалу b: ");
                b = Convert.ToDouble(Console.ReadLine());
                intervalFound = true;
            }
            else if (intervalChoice == 2)
            {
                intervalFound = FindInterval(-1000, 1000, 10, out a, out b);
                if (!intervalFound)
                {
                    Console.WriteLine("Не вдалося знайти iнтервал, де функцiя змiнює знак.");
                    return;
                }
                else
                {
                    Console.WriteLine($"Автоматично знайдено iнтервал: [{a}, {b}]");
                }
            }

            Console.Write("Введiть точнiсть eps: ");
            double eps = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введiть максимальну кiлькiсть iтерацiй Kmax: ");
            int Kmax = Convert.ToInt32(Console.ReadLine());


            int iterations;
            double root = double.NaN;

            if (method == 1)
            {
                root = Bisection(a, b, eps, Kmax, out iterations);
            }
            else if (method == 2)
            {
                root = Newton(a, b, eps, Kmax, out iterations);
            }
            else
            {
                Console.WriteLine("Невiрний вибiр методу");
                return;
            }

            if (!double.IsNaN(root))
                Console.WriteLine($"Знайдений корiнь: x = {root}, кiлькiсть iтерацiй = {iterations}");
        }
    }
}
