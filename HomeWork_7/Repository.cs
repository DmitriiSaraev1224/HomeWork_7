using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HomeWork_7
{
    struct Repository
    {

        public Worker[] workerArray;            //массив работников

        private string path;        //путь к файлу

        public int index;           //индекс в массиве

        string[] titles;

        public Repository(string Path)
        {
            this.path = Path;           //путь к файлу

            this.index = 0;     //индекс массива

            this.workerArray = new Worker[2];       //инициализация массива

            this.titles = new string[7];        //инициализация массива заголовка

            ReadAllWorkers();       // подгрузка списка работников

        }
        
        private void Resize(bool Flag)                      //метод для расширения массива работников
        {
            if (Flag)
            {
                Array.Resize(ref workerArray, workerArray.Length * 2);
            }
        }

        public void Add(Worker workerInfo)                  //метод для добавления работников из файла
        {
            this.Resize(index >= this.workerArray.Length);

            this.workerArray[index] = workerInfo;

            this.index++;

            workerInfo.id = this.index;
        }
        
        public void AddWorker()                     //метод добавления работников в текстовый файл
        {
            string key = " ";
            do
            {
                Console.Clear();

                DateTime inputTime = DateTime.Now;                                              //дата и время ввода

                DateTime inputDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());

                Console.WriteLine("Введите полное имя работника: ");

                string fullNameWorker = Console.ReadLine();

                Console.WriteLine("Введите возраст работника: ");

                int ageWorker = Convert.ToInt32(Console.ReadLine());                    //пользователь вводит данные работника

                Console.WriteLine("Введите рост работника: ");

                int heightWorker = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Введите дату рождения работника (дд.мм.гггг): ");

                DateTime birthdayWorker = Convert.ToDateTime(Console.ReadLine());

                Console.WriteLine("Введите место рождения работника: ");

                string placeOfBirthWorker = Console.ReadLine();

                Worker workerInfo = new Worker(inputTime, inputDate, fullNameWorker, ageWorker, heightWorker, birthdayWorker, placeOfBirthWorker);
                //инициализация работника

                using (StreamWriter sw = new StreamWriter("Handbook.txt", true))                //поток записи работника в блокнот
                {
                    sw.WriteLine(workerInfo.Print());       //запись работника в файл
                }

                Console.WriteLine($"\nПродолжить? Д/Н");

                key = Console.ReadLine().ToLower();


            } while (key == "д");

        }
        
        public Worker[] ReadAllWorkers()                    //чтение работников из файла
        {
            using (StreamReader sr = new StreamReader(this.path))          //начало потока чтения 
            {

                while (!sr.EndOfStream)
                {
                    string[] args = sr.ReadLine().Split('#');           //разделение в записи файла на пробелы

                    Add(new Worker(Convert.ToInt32(args[0]), Convert.ToDateTime(args[1]), Convert.ToDateTime(args[2]),
                    args[3], Convert.ToInt32(args[4]), Convert.ToInt32(args[5]), Convert.ToDateTime(args[6]), args[7]));    //добавление работника в массив

                }

            }

            return this.workerArray;

        }

        public void PrintDbToConsole()          //вывод списка работников на экран
        {
            Titles();

            for (int i = 0; i < index; i++)
            {

                Console.WriteLine($"\n" + (this.workerArray[i].Print().Replace("#", " ")));

            }



        }

        public Worker GetWorkerById(int id)             //метод вывода работника по ID
        {

            if (id > 0 && id < index + 1)               //проверка ввода ID
            {
                Titles();
                Console.WriteLine($"\n" + (workerArray[id - 1].Print().Replace("#", " ")));         // если ID попадает в диапазон списка
                                                                                                    // выводит работника на экран
            }
            else if (id != workerArray.Length)
            {

                Console.WriteLine("Неверный ID попробуйте еще раз:");

            }

            Console.ReadLine();

            return this.workerArray[index - 1];
        }

        public void DeleteWorker(int id)                //метод удаления работника из списка
        {
            int delId = id - 1;

            Worker[] delWorker = new Worker[workerArray.Length - 1];

            delWorker = workerArray;

            File.WriteAllText(this.path, string.Empty);         // замена текста в списке на пустой

            using (StreamWriter sw = new StreamWriter("Handbook.txt", true))
            {
                for (int i = 0; i < index; i++)                 //цикл проходит по списку работников
                {
                    if (i < delId)
                    {
                        sw.WriteLine(delWorker[i].Print());             //запись в файл, список без выбранного работника 

                    }

                    if (i == delId)
                    {
                        continue;

                    }
                    if (i > delId)
                    {
                        sw.WriteLine(delWorker[i].Print());
                    }

                }

            }
            Console.WriteLine($"Удаление работника: {delWorker[delId].fullNameWorker} c ID: {id} прошло успешно!");

            Console.ReadLine();

        }

        public Worker[] GetWorkersBetweenTwoDates(DateTime dateFrom, DateTime dateTo)               //Метод для отображения работников в введенный период
        {
            Titles();

            for (int i = 0; i < index; i++)             //цикл проходит по списку
            {
                if (workerArray[i].inputDate >= dateFrom && workerArray[i].inputDate <= dateTo)             //если файл попадает в диапазон,                                                                                      
                {                                                                                           //выводит работника на экран
                    Console.WriteLine($"\n" + (workerArray[i].Print().Replace("#", " ")));

                }

            }

            Console.ReadLine();

            return this.workerArray;
        }

        public void Titles()                //метод отображения заголовка
        {
            this.titles[0] = "ID: ";
            this.titles[1] = "Время записи: ";
            this.titles[2] = "ФИО работника: ";
            this.titles[3] = "Возраст: ";
            this.titles[4] = "Рост: ";
            this.titles[5] = "Дата рождения: ";
            this.titles[6] = "Место рождения: ";


            Console.WriteLine($"{this.titles[0]} {this.titles[1],10} {this.titles[2],17} {this.titles[3],16} {this.titles[4],5}" +
                $"{this.titles[5],8} {this.titles[6],8}");
        }
    }

}















