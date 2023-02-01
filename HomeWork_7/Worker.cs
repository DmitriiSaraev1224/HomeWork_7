using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_7
{
    class Worker
    {
        private DateTime InputTime;                         //поля класса работник
        
        private DateTime InputDate;
        
        private int ID;
       
        private string FullNameWorker;
        
        private int AgeWorker;
        
        private int HeightWorker;
        
        private DateTime BirthdayWorker;
        
        private string PlaceOfBirthWorker;

        
        public Worker(int id, DateTime inputTime, DateTime inputDate,  string fullNameWorker, int ageWorker, int heightWorker, DateTime birthdayWorker, string placeOfBirthWorker)
        {
            this.ID = id;
            
            this.InputTime = inputTime;
                                                                       //Создание работника
            this.InputDate = inputDate;
            
            this.FullNameWorker = fullNameWorker;
            
            this.AgeWorker = ageWorker;                             
            
            this.HeightWorker = heightWorker;
            
            this.BirthdayWorker = birthdayWorker;
            
            this.PlaceOfBirthWorker = placeOfBirthWorker;
        }

        public Worker(DateTime inputTime, DateTime inputDate, string fullNameWorker, int ageWorker, int heightWorker, DateTime birthdayWorker, string placeOfBirthWorker)
        {
            this.InputTime = inputTime;
            
            this.InputDate = inputDate;
            
            this.FullNameWorker = fullNameWorker;
                                                                    //перегрузка без ID
            this.AgeWorker = ageWorker;
            
            this.HeightWorker = heightWorker;
            
            this.BirthdayWorker = birthdayWorker;
            
            this.PlaceOfBirthWorker = placeOfBirthWorker;
        }

        public int id { get { return this.ID; } set { this.ID = value; } }      //ID работника
        
        public DateTime inputTime { get { return this.InputTime; } set { this.InputTime = value; } }    //Время записи
        
        public DateTime inputDate { get { return this.InputDate; } set { this.InputDate = value; } }    //Дата записи
        
        public string fullNameWorker { get { return this.FullNameWorker; } set { this.FullNameWorker = value; } }   //ФИО работника
        
        public int ageWorker { get { return this.AgeWorker; } set { this.AgeWorker = value; } }         //Возраст работника
        
        public int heightWorker { get { return this.HeightWorker;} set { this.HeightWorker = value; } }         //Рост работника
        
        public DateTime birthdayWorker { get { return this.BirthdayWorker; } set { this.BirthdayWorker = value; } } //День рождения
        
        public string placeOfBirthWorker { get { return this.PlaceOfBirthWorker; } set { this.PlaceOfBirthWorker = value; } }   //Место рождения


        
        
        public string Print()               //метод для записи нового работника в файл
        {
            return $"{this.ID}#{this.inputTime.ToShortTimeString(),8}#{this.inputDate.ToShortDateString(),5}#{this.fullNameWorker,5}" +
                $"#{this.ageWorker,5}#{this.heightWorker,8}" +
                $"#{this.birthdayWorker.ToShortDateString(),12}#{this.placeOfBirthWorker,10}";
        }
    }
}
