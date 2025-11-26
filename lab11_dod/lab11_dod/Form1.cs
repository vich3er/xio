using System;
using System.Drawing;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace lab11_dod
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class BankAccount
        {
            public decimal Balance { get; private set; }
            public string OwnerName { get; set; }

            //оголошення делегата
            public delegate void BankTransactionHandler(string message, decimal currentBalance);

            // змінна делегата
            private BankTransactionHandler handlers;

            public BankAccount(string name, decimal initialBalance)
            {
                OwnerName = name;
                Balance = initialBalance;
            }

            //  мтод для реєстрації обробників 
            public void RegisterHandler(BankTransactionHandler handler)
            {
                handlers += handler;
            }

            // метод проведення транзакції 
            public void MakeTransaction(decimal amount)
            {
                if (handlers != null)
                {
                    if (amount > 0)
                    {
                        Balance += amount;
                        handlers($"Поповнення: +{amount}$", Balance);
                    }
                    else
                    {
                        // спроба зняття (amount від'ємне)
                        if (Balance + amount >= 0)
                        {
                            Balance += amount;
                            handlers($"Зняття: {amount}$", Balance);
                        }
                        else
                        {
                            handlers($"Помилка! Недостатньо коштів для зняття {amount}$", Balance);
                        }
                    }
                }
            }
        }


        // пише лог операцій у Label1
        public void OnTransactionLog(string msg, decimal balance)
        {
            label1.Text += $"{msg} | Баланс: {balance}$\n";
        }

        // аналізує статус і виводить його у Label2 
        public void OnStatusCheck(string msg, decimal balance)
        {
            if (balance >= 1000)
            {
                label2.ForeColor = Color.Green;
                label2.Text = "Статус: VIP Клієнт (Баланс > 1000$)";
            }
            else if (balance < 100)
            {
                label2.ForeColor = Color.Red;
                label2.Text = "Статус: Низький баланс! Поповніть рахунок.";
            }
            else
            {
                label2.ForeColor = Color.Black;
                label2.Text = "Статус: Звичайний клієнт";
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            label1.Text = "Історія операцій:\n\n";
            label2.Text = "Статус: Невідомий";

            // створюємо рахунок з початковим балансом 100
            BankAccount myAccount = new BankAccount("Іван Іванов", 100);

            // створюємо екземпляри делегатів
            BankAccount.BankTransactionHandler logHandler = new BankAccount.BankTransactionHandler(OnTransactionLog);
            BankAccount.BankTransactionHandler statusHandler = new BankAccount.BankTransactionHandler(OnStatusCheck);

            // реєструємо обидва методи
            myAccount.RegisterHandler(logHandler);
            myAccount.RegisterHandler(statusHandler);

          
            myAccount.MakeTransaction(500);   
            myAccount.MakeTransaction(-200);   
            myAccount.MakeTransaction(800);    
            myAccount.MakeTransaction(-2000); 
            myAccount.MakeTransaction(-1150);
        }
    }
}