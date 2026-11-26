using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Text.RegularExpressions;

namespace PersonLib
{
    //TODO: To separate file +
    /// <summary>
    /// Хранит и предоставляет доступ к набору личной информации о человеке
    /// </summary>
    public class Person
    {
        //TODO: XML
        private string _name;
        private string _surname;
        private int _age;
        //TODO: remove
        private Sex _sex;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = StringFormat.NameFormat(value);
            }
        }

        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                _surname = StringFormat.NameFormat(value);
            }
        }

        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                //TODO: domain limits
                if (value >= 0)
                {
                    _age = value;
                }
            }
        }

        public Sex Sex { get; set; }

        public Person(string name, string surname, int age, Sex sex)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Sex = sex;
        }

        //TODO: RSDN
        public Person(): this("Иван","Петров",25,Sex.Male)
        { }

        /// <summary>
        /// Предоставляет все данные о персоне
        /// </summary>
        /// <returns>Строка с информацией из  полей конкретной персоны</returns>
        public string GetInfo()
        {
            return $" {Name}; {Surname}; {Age}; {Sex}";
        }

        /// <summary>
        /// Создает условно случайную персону из набора имен и фамилий
        /// </summary>
        /// <returns>Заполненный объект класса Person</returns>
        public static Person GetRandomPerson()
        {
            Random random = new Random();
            string[] names = { 
                "Боб", 
                "Джек", 
                "Марти", 
                "Розалия", 
                "Лусия" 
            };
            string[] surnames = { 
                "Браун", 
                "Гонзалес", 
                "Саламанка", 
                "Ричардс", 
                "Трамп" 
            };

            string name = names[random.Next(names.Length)];
            string surname = surnames[random.Next(surnames.Length)];
            int age = random.Next(0, 99);
            Sex sex = (Sex)random.Next(0,2);

            return new Person(name, surname, age, sex);
        }
    }
}
