using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_7
{
    public class StartProgram
    {
        public static void Start()
        {

            bool isTrue = true;

            CreateFile();                                                       //вызов метода создания файла

            while (isTrue)
            {
                Repository rep = new Repository(@"Handbook.txt");           //инициализация структуры
                
                Console.Clear();


                Console.Write($"Выберите пункт меню: \n1- Просмотр всех записей.\n2- Просмотр одной записи по номеру работника." +
                "\n3- Добавить запись о работнике.\n4- Удалить запись о работнике.\n5- Загрузка записей в диапазоне дат.\n0- выход из программы\n\nВведите номера пункта меню: ");

                int userChoice = Convert.ToInt32(Console.ReadLine()); //пользователь выбирает список в меню

                switch (userChoice)
                {

                    case 1:

                        rep.PrintDbToConsole();         //вызов метода для просмотра всех записей
                        
                        Console.ReadKey();
                        break;

                    case 2:
                        Console.Write("Введите ID работника: ");
                        
                        rep.GetWorkerById(Convert.ToInt32(Console.ReadLine()));             //вызов метода для просмотра записи по ID
                        
                        break;

                    case 3:
                        
                        rep.AddWorker();                        // вызов метода для добавление работника в текстовый файл
                        
                        break;

                    case 4:
                        
                        Console.Write("Введите ID работника для удаления: ");
                        
                        rep.DeleteWorker(Convert.ToInt32(Console.ReadLine()));          //вызов метода удаления работника
                        
                        break;

                    case 5:

                        
                        Console.WriteLine("Введите Диапазон Дат для поиска: ");
                        
                        Console.WriteLine("Введите первую дату (ДД.ММ.ГГГГ): ");            // ввод двух дат из диапазона
                        
                        DateTime dateFrom = Convert.ToDateTime(Console.ReadLine());
                        
                        Console.WriteLine("Введите вторую дату (ДД.ММ.ГГГГ): ");
                        
                        DateTime dateTo = Convert.ToDateTime(Console.ReadLine());

                        rep.GetWorkersBetweenTwoDates(dateFrom, dateTo);        //вызов метода вывода работников в диапазоне дат
                        
                        break;

                    case 0:
                        
                        Exit();             //выход из программы
                        
                        break;

                    default:
                        
                        Console.WriteLine("Введено неверное число, попробуйте ещё раз.");
                        
                        Console.ReadKey();

                        Console.Clear();
                        break;
                }

            }
            Console.ReadKey();

            static void CreateFile()
            {
                string curFile = @"Handbook.txt";
                if (File.Exists(curFile) == false)                              //Метод для создания файла
                {
                    var myFile = File.Create("Handbook.txt");
                    
                    myFile.Close();
                }

            }
            static void Exit()                  //Метод выхода из программы
            {
                int exit = 0;
                
                Environment.Exit(exit);
            }

        }


    }
}
