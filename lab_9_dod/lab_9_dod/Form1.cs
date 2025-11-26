using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Windows.Forms;

namespace lab_9_dod
{
    public partial class Form1 : Form
    { 
        public Form1()
        {
            InitializeComponent();
        }

        // клас, що описує одну собаку
        public class Dog
        {
            public string Name { get; set; }   
            public string Breed { get; set; }  
            public int Age { get; set; }        

            // метод для гарного виводу інформації про собаку в рядок
            public override string ToString()
            {
                return "Собака: " + Name + ", Порода: " + Breed + ", Вік: " + Age + " роки(ів)";
            }
        }

        // клас який містить масив собак і використовує індексатор
        public class DogKennel
        {
            private Dog[] dogs;         // масив для зберігання об'єктів собак
            private string[] validBreeds; // масив дозволених порід

            public int Length;          // розмір розплідника 
            public int ErrorCode;       // код помилки 
            // конструктор: ініціалізує масиви
            public DogKennel(int size)
            {
                dogs = new Dog[size];   
                Length = size;
                ErrorCode = 0;

                // визначаємо список порід, які наш розплідник приймає
                validBreeds = new string[] { "Вівчарка", "Бульдог", "Тер'єр", "Хаскі", "Лабрадор" };
            }

            // перевіряє, чи індекс входить у межі масиву
            private bool IsIndexValid(int index)
            {
                return index >= 0 && index < Length;
            }

            // перевіряє, чи порода є у списку дозволених
            private bool IsBreedValid(string breedToCheck)
            {
                foreach (string valid in validBreeds)
                {
                    if (valid == breedToCheck) return true;
                }
                return false;
            }

           // індексатор
            public Dog this[int index]
            {
                get
                {
                    if (IsIndexValid(index))
                    {
                        ErrorCode = 0;       
                        return dogs[index];  
                    }
                    else
                    {
                        ErrorCode = 1;      
                        return null;
                    }
                }

               // запис собаки в масив за індексом
                set
                {
                    // перевірка індексу
                    if (!IsIndexValid(index))
                    {
                        ErrorCode = 1;  
                        return;         
                    }

                    // перевірка породи
                    if (!IsBreedValid(value.Breed))
                    {
                        ErrorCode = 2; 
                        return;         
                    }

                    // якщо все добре записуємо собаку
                    dogs[index] = value;
                    ErrorCode = 0;     
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // створюємо розплідник на 5 місць
            DogKennel MyKennel = new DogKennel(5);

            Dog dog1 = new Dog { Name = "Рекс", Breed = "Вівчарка", Age = 3 };   // правильна
            Dog dog2 = new Dog { Name = "Бобик", Breed = "Бульдог", Age = 2 };   // правильна
            Dog dog3 = new Dog { Name = "Мурчик", Breed = "Кіт", Age = 5 };      // НЕПРАВИЛЬНА  
            Dog dog4 = new Dog { Name = "Балто", Breed = "Хаскі", Age = 4 };     // правильна
            Dog dog5 = new Dog { Name = "Жучка", Breed = "Дворняга", Age = 1 };  // НЕПРАВИЛЬНА  

            string logMessage = "Журнал операцій:\n";


            MyKennel[0] = dog1;
            if (MyKennel.ErrorCode == 0)
                logMessage += "1. Додано: " + dog1.Name + " (ОК)\n";
            else
                logMessage += "1. Помилка додавання " + dog1.Name + ". Код: " + MyKennel.ErrorCode + "\n";

            MyKennel[1] = dog2;
            if (MyKennel.ErrorCode == 0)
                logMessage += "2. Додано: " + dog2.Name + " (ОК)\n";
            else
                logMessage += "2. Помилка додавання " + dog2.Name + ". Код: " + MyKennel.ErrorCode + "\n";

            MyKennel[2] = dog3;
            if (MyKennel.ErrorCode == 0)
                logMessage += "3. Додано: " + dog3.Name + " (ОК)\n";
            else
                logMessage += "3. Помилка додавання " + dog3.Name + " (" + dog3.Breed + "). Код: " + MyKennel.ErrorCode + " (Заборонена порода)\n";

            MyKennel[3] = dog4;
            if (MyKennel.ErrorCode == 0)
                logMessage += "4. Додано: " + dog4.Name + " (ОК)\n";
            else
                logMessage += "4. Помилка додавання " + dog4.Name + ". Код: " + MyKennel.ErrorCode + "\n";

            MyKennel[10] = dog4;
            if (MyKennel.ErrorCode != 0)
                logMessage += "5. Спроба запису в комірку 10. Код помилки: " + MyKennel.ErrorCode + " (Невірний індекс)\n";

            // виводимо журнал операцій у лівиф лейбл
            label1.Text = logMessage;

            string resultMessage = "Зараз у розпліднику:\n";

            for (int i = 0; i < MyKennel.Length; i++)
            {
                // використовуємо індексатор для читання 
                Dog currentDog = MyKennel[i];

                if (currentDog != null)
                {
                    resultMessage += "[" + i + "] " + currentDog.ToString() + "\n";
                }
                else
                {
                    resultMessage += "[" + i + "] Порожньо \n";
                }
            }

            // виводимо список собак у праву мітку
            label2.Text = resultMessage;
        }
    }
}