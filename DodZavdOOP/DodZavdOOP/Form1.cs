using System;
using System.Drawing;
using System.Windows.Forms;

namespace DodZavdOOP
{
   
    public enum TypePalyva
    {
        Benzyn,     
        Dyzel,      
        Elektryka,  
        Gibryd,     
        Gaz         
    }

     
    public enum StanTransportu
    {
        Zupynenyi,  
        Rukh,       
        Remont,     
        Zaparkovanyi
    }

    public partial class FormTransport : Form
    {
        public static string log = "";
        public static int operationCounter = 1;

        public FormTransport()
        {
            InitializeComponent();
        }


        private void btnDemonstrate_Click(object sender, EventArgs e)
        {
            log = "ДЕМОНСТРАЦІЯ КОНЦЕПЦІЙ ООП\r\n\r\n";
            operationCounter = 1;

            log += "1. КОНСТРУКТОРИ\r\n";

            Avtomobil car1 = new Avtomobil("Toyota", "Camry", 2020, TypePalyva.Benzyn);
            Vantazhivka truck1 = new Vantazhivka("Volvo", "FH16", 2019, TypePalyva.Dyzel, 25000);
            Elektromobil tesla = new Elektromobil("Tesla", "Model 3", 2023, 75.0);

            log += "\r\n2. ІНКАПСУЛЯЦІЯ (Properties)\r\n";

            car1.Shvydkist = 120;
            log += $"{operationCounter}. Встановлено швидкість автомобіля: {car1.Shvydkist} км/год\r\n";
            operationCounter++;

            truck1.Vantazh = 15000;
            log += $"{operationCounter}. Завантажено вантажівку: {truck1.Vantazh} кг\r\n";
            operationCounter++;

            tesla.RivenBatareyi = 80;
            log += $"{operationCounter}. Рівень батареї Tesla: {tesla.RivenBatareyi}%\r\n";
            operationCounter++;

            log += "\r\n3. ПОЛІМОРФІЗМ (Virtual/Override)\r\n";


            car1.Start();
            truck1.Start();
            tesla.Start();

            log += "\r\n4. ПЕРЕВАНТАЖЕННЯ МЕТОДІВ\r\n";

            double vidstan1 = car1.Rukh(2.5);
            double vidstan2 = truck1.Rukh(3.0, 80);

            log += $"{operationCounter}. Автомобіль проїхав: {vidstan1:F2} км\r\n";
            operationCounter++;
            log += $"{operationCounter}. Вантажівка проїхала: {vidstan2:F2} км\r\n";
            operationCounter++;

            log += "\r\n5. УСПАДКУВАННЯ (Inheritance)\r\n";

            string info1 = car1.GetInfo();
            string info2 = truck1.GetInfo();

            log += $"{operationCounter}. Інформація про транспорт:\r\n{info1}\r\n";
            operationCounter++;
            log += $"{operationCounter}. Інформація про транспорт:\r\n{info2}\r\n";
            operationCounter++;

            log += "\r\n6. ВИКЛИК БАЗОВИХ МЕТОДІВ\r\n";

            tesla.StartBase();

            log += "\r\n7. СТАТИЧНІ МЕТОДИ\r\n";

            double vidstan = Transport.ObchyslytyVidstan(100, 2.5);
            log += $"{operationCounter}. Статичний метод: Відстань = {vidstan:F2} км\r\n";
            operationCounter++;

            int totalTransport = Transport.TotalTransportCount;
            log += $"{operationCounter}. Всього створено транспортних засобів: {totalTransport}\r\n";
            operationCounter++;

            log += "\r\n8. ПОЛІМОРФІЗМ ЧЕРЕЗ БАЗОВИЙ КЛАС\r\n";

            Transport[] parking = new Transport[] { car1, truck1, tesla };

            foreach (var vehicle in parking)
            {
                log += $"{operationCounter}. {vehicle.GetType().Name}: ";
                vehicle.Stop();
                operationCounter++;
            }

            log += "\r\n9. ОБЧИСЛЮВАНІ ВЛАСТИВОСТІ\r\n";

            bool canDrive = truck1.MozheYihaty;
            log += $"{operationCounter}. Вантажівка може їхати: {canDrive}\r\n";
            operationCounter++;

            double range = tesla.ZapasHodu;
            log += $"{operationCounter}. Запас ходу електромобіля: {range:F2} км\r\n";
            operationCounter++;

            log += "\r\n10. REF та OUT ПАРАМЕТРИ\r\n";

            int probig = 50000;
            truck1.TechnichneObslugovuvannya(ref probig, out string status);
            log += $"{operationCounter}. Після ТО: пробіг = {probig} км, статус = {status}\r\n";
            operationCounter++;

            txtLog.Text = log;

            string summary = "ПІДСУМОК \r\n\r\n";
            summary += $"Створено об'єктів: {Transport.TotalTransportCount}\r\n";
            summary += $"Виконано операцій: {operationCounter - 1}\r\n\r\n";
            summary += "Продемонстровані концепції:\r\n";
            summary += "Інкапсуляція\r\n";
            summary += "Успадкування\r\n";
            summary += "Поліморфізм\r\n";
            summary += "Абстракція\r\n";
            summary += "Конструктори\r\n";
            summary += "Властивості\r\n";
            summary += "Перевантаження методів\r\n";
            summary += "Віртуальні методи\r\n";
            summary += "Статичні члени\r\n";
            summary += "ref/out параметри\r\n";
            summary += "Enum типи\r\n";

            txtSummary.Text = summary;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtLog.Text = "";
            txtSummary.Text = "";
            log = "";
            operationCounter = 1;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lblSummary_Click(object sender, EventArgs e)
        {

        }
    }





    public class Transport // клас який буде батьком для інших
    {
        private static int transportCount = 0;

        private string marka;
        private string model;
        private int rik;
        private double shvydkist;
        private StanTransportu stan;

        public static int TotalTransportCount
        {
            get { return transportCount; }
        }

        public string Marka
        {
            get { return marka; }
            set { marka = value; }
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public int Rik
        {
            get { return rik; }
            set
            {
                if (value > 1900 && value <= DateTime.Now.Year)
                    rik = value;
            }
        }

        public double Shvydkist
        {
            get { return shvydkist; }
            set
            {
                if (value >= 0 && value <= 300)
                    shvydkist = value;
            }
        }

        public StanTransportu Stan
        {
            get { return stan; }
            set { stan = value; }
        }

      
        public Transport(string marka, string model, int rik)
        {
            this.marka = marka;
            this.model = model;
            this.rik = rik;
            this.shvydkist = 0;
            this.stan = StanTransportu.Zupynenyi;

            transportCount++;  

            FormTransport.log += $"\r\n{FormTransport.operationCounter}.Створено транспорт: {marka} {model} ({rik})";
            FormTransport.operationCounter++;
        }

        // віртуальний метод
        public virtual void Start()
        {
            stan = StanTransportu.Rukh;
            FormTransport.log += $"\r\n{FormTransport.operationCounter}. {marka} {model}: Двигун запущено";
            FormTransport.operationCounter++;
        }

        
        public virtual void Stop()
        {
            shvydkist = 0;
            stan = StanTransportu.Zupynenyi;
            FormTransport.log += $"{FormTransport.operationCounter}. {marka} {model}: Зупинено\r\n";
            FormTransport.operationCounter++;
        }

         
        public virtual double Rukh(double chas)
        {
            return shvydkist * chas;
        }
        // перезавантаженняя
        public virtual double Rukh(double chas, double novaShvydkist)
        {
            this.shvydkist = novaShvydkist;
            return novaShvydkist * chas;
        }

     
        public string GetInfo()
        {
            return $"   Марка: {marka}\n   Модель: {model}\n   Рік: {rik}\n   Швидкість: {shvydkist} км/год\n   Стан: {stan}";
        }

      
        public static double ObchyslytyVidstan(double shvydkist, double chas)
        {
            return shvydkist * chas;
        }
    }

    
    public class Avtomobil : Transport
    {
        private TypePalyva typPalyva;
        private double objem;

        public TypePalyva TypPalyva
        {
            get { return typPalyva; }
            set { typPalyva = value; }
        }

        public double Objem
        {
            get { return objem; }
            set { objem = value; }
        }

        
        public Avtomobil(string marka, string model, int rik, TypePalyva typPalyva)
            : base(marka, model, rik)  // виклик конструктора батька
        {
            this.typPalyva = typPalyva;
            this.objem = 2.0;

            FormTransport.log += $"   -> Тип пального: {typPalyva}\n";
        }

        public override void Start()
        {
            base.Start();  
            FormTransport.log += $"   -> Використовується {typPalyva}\n";
        }

      
        public void Zapravyty(double litry)
        {
            FormTransport.log += $"{FormTransport.operationCounter}. Заправлено {litry} л {typPalyva}\n";
            FormTransport.operationCounter++;
        }
    }

     
    public class Vantazhivka : Avtomobil
    {
        private double vantazh;
        private double maxVantazh;

        public double Vantazh
        {
            get { return vantazh; }
            set
            {
                if (value <= maxVantazh)
                    vantazh = value;
            }
        }

        public double MaxVantazh
        {
            get { return maxVantazh; }
        }

     
        public bool MozheYihaty
        {
            get { return vantazh <= maxVantazh && Stan != StanTransportu.Remont; }
        }

        
        public Vantazhivka(string marka, string model, int rik, TypePalyva typPalyva, double maxVantazh)
            : base(marka, model, rik, typPalyva)
        {
            this.maxVantazh = maxVantazh;
            this.vantazh = 0;

            FormTransport.log += $"   -> Макс. вантажність: {maxVantazh} кг\n";
        }

      
        public override double Rukh(double chas)
        {
            double koefVantazhu = 1 - (vantazh / maxVantazh * 0.3); 
            return base.Rukh(chas) * koefVantazhu;
        }

      
        public void TechnichneObslugovuvannya(ref int probig, out string status)
        {
            probig += 10000;  

            if (probig > 100000)
                status = "Потрібен капітальний ремонт";
            else if (probig > 50000)
                status = "Хороший стан";
            else
                status = "Відмінний стан";

            Stan = StanTransportu.Remont;
        }
    }
     
    public class Elektromobil : Transport
    {
        private double yemnistBatareyi; 
        private double rivenBatareyi;   

        public double YemnistBatareyi
        {
            get { return yemnistBatareyi; }
        }

        public double RivenBatareyi
        {
            get { return rivenBatareyi; }
            set
            {
                if (value >= 0 && value <= 100)
                    rivenBatareyi = value;
            }
        }

         
        public double ZapasHodu
        {
            get { return yemnistBatareyi * rivenBatareyi / 100 * 5; }  
        }

        public Elektromobil(string marka, string model, int rik, double yemnistBatareyi)
            : base(marka, model, rik)
        {
            this.yemnistBatareyi = yemnistBatareyi;
            this.rivenBatareyi = 100;

            FormTransport.log += $"   -> Ємність батареї: {yemnistBatareyi} кВт·год\n";
        }

        
        public override void Start()  // оверрайднутий метод, демонстрація поліморфізму
        {
            if (rivenBatareyi > 10)
            {
                Stan = StanTransportu.Rukh;
                FormTransport.log += $"\r\n{FormTransport.operationCounter}. {Marka} {Model}: Електродвигун активовано (заряд: {rivenBatareyi:F1}%)\n";
                FormTransport.operationCounter++;
            }
            else
            {
                FormTransport.log += $"{FormTransport.operationCounter}. {Marka} {Model}: Недостатньо заряду!\n";
                FormTransport.operationCounter++;
            }
        }

         
        public void StartBase() // виклик методу батька
        {
            FormTransport.log += $"\n{FormTransport.operationCounter}. Виклик базової версії Start():\n";
            FormTransport.operationCounter++;
            base.Start();  
        }

        
        public void Zaryzhaty(double chas)
        {
            double dodano = chas * 10; 
            rivenBatareyi = Math.Min(100, rivenBatareyi + dodano);

            FormTransport.log += $"\n{FormTransport.operationCounter}. Зарядка {chas} год: рівень = {rivenBatareyi:F1}%\n";
            FormTransport.operationCounter++;
        }
    }
}

