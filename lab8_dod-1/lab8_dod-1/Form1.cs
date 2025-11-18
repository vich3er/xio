using System;
using System.Collections;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace lab8_dod_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string report = "Декоративна щуряча зграя\n\n";

            // створюємо зграю на 5 щурів
            RatColony colony = new RatColony(5);

            colony.Add(1, "Стоьопа", "Чорно-білий", 300, 3);
            colony.Add(2, "Кабан", "Чорний", 1200, 9);
            colony.Add(3, "Вася", "Білий", 150, 5);
            colony.Add(4, "Малий", "Сірий", 350, 10);

            report += "Перебір за допомогою foreach (IEnumerable)\n";
            // завдяки реалізації IEnumerable ми можемо використовувати foreach
            foreach (Rat rat in colony)
            {
                report += rat.ToString() + "\n";
            }

            report += "\nРучний перебір (IEnumerator: MoveNext / Current)\n";
            // скидаємо лічильник
            colony.Reset();

            // рухаємось вручну
            if (colony.MoveNext())
            {
                report += "Перший у списку: " + colony.Current.ToString() + "\n";
            }

            if (colony.MoveNext())
            {
                report += "Другий у списку: " + colony.Current.ToString() + "\n";
            }

            // перевірка роботи індексатора (доступ по індексу)
            report += "\nДоступ через індексатор [index]\n";
            Rat boss = colony[1]; // беремо другого щура (індекс 1)
            if (boss != null)
            {
                report += "Бос зграї (індекс 1): " + boss.Name + ", Номер: " + boss.Number + ", Вага: " + boss.Weight + "г";
            }

            label1.Text = report;
        }
    }


    public class Rat
    {
        public int Number { get; set; }  
        public string Name { get; set; }
        public string Color { get; set; }
        public int Weight { get; set; }
        public int Intelligence { get; set; }
         
        public Rat(int number, string name, string color, int weight, int intelligence)
        {
            Number = number;
            Name = name;
            Color = color;
            Weight = weight;
            Intelligence = intelligence;
        }

        public override string ToString()
        {
            return $"[Щур №{Number}] {Name} | Колір: {Color} | Вага: {Weight}г | IQ: {Intelligence}/10";
        }
    }


    // реалізуємо IEnumerable (щоб працював foreach) та IEnumerator (щоб працювали MoveNext/Current)
    public class RatColony : IEnumerable, IEnumerator
    {
        private Rat[] _rats;

        private int _position = -1;

        // поточна кількість щурів у зграї
        private int _count = 0;

        // конструктор зграї
        public RatColony(int size)
        {
            _rats = new Rat[size];
        }

        public void Add(int number, string name, string color, int weight, int intelligence)
        {
            if (_count < _rats.Length)
            {
                _rats[_count] = new Rat(number, name, color, weight, intelligence);
                _count++;
            }
            else
            {
                MessageBox.Show("Клітка переповнена! Немає місця для нових щурів((((.");
            }
        }

        // індексатор: дозволяє звертатись до зграї як до масиву: colony[0]
        public Rat this[int index]
        {
            get
            {
                if (index >= 0 && index < _count)
                    return _rats[index];
                else
                    return null;
            }
            set
            {
                if (index >= 0 && index < _rats.Length)
                    _rats[index] = value;
            }
        }


        // цей метод викликається, коли починається цикл foreach.
        public IEnumerator GetEnumerator()
        {
            Reset();
            return (IEnumerator)this;
        }


        // пересуває вказівник на наступний елемент
        public bool MoveNext()
        {
            _position++;
            return (_position < _count);
        }


        public void Reset()
        {
            _position = -1;
        }

        // повертає поточний об'єкт
        public object Current
        {
            get
            {
                try
                {
                    return _rats[_position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}