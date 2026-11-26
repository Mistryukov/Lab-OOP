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
        /// <summary>
        /// Русский формат для имен-фамилий
        /// </summary>
        private string russianPattern = @"^[А-Яа-яЁё]+(?:[ -][А-Яа-яЁё]+)*$";
        /// <summary>
        /// Максимальный возраст
        /// </summary>
        const int MaxAge = 120;
        /// <summary>
        /// Минимальный   возраст
        /// </summary>
        const int MinAge = 0;

        //TODO: XML +
        /// <summary>
        /// Приватное поле, обозначающее имя персоны
        /// </summary>
        private string _name;

        /// <summary>
        /// Приватное поле, обозначающее фамилию персоны
        /// </summary>
        private string _surname;

        /// <summary>
        /// Приватное поле, обозначающее возраст персоны
        /// </summary>
        private int _age;
        //TODO: remove + removed unused "Sex" property

        /// <summary>
        /// Свойство объекта класса Person "Имя"
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                {
                    _name = StringFormat.NameFormat(value);
                    
                }
            }
        }

        /// <summary>
        /// Свойство объекта класса Person "Фамилия"
        /// </summary>
        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                if (Regex.IsMatch(_name, russianPattern))
                {
                    _surname = StringFormat.RussianFormat(value);
                }
                else
                {
                    _surname = StringFormat.EnglishFormat(value);
                }
                
            }
        }

        /// <summary>
        /// Свойство объекта класса Person "Возраст"
        /// </summary>
        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                //TODO: domain limits +
                if (value >= MaxAge || value <= MinAge)
                {
                    throw new ArgumentException("Возраст вне допустимого диапазона (0-120)");
                }
                _age = value;
            }
        }

        /// <summary>
        /// Свойство объекта класса Person "Пол"
        /// </summary>
        public Sex Sex { get; set; }

        /// <summary>
        /// Конструктор объекта класса Person
        /// </summary>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <param name="age"></param>
        /// <param name="sex"></param>
        public Person(string name, string surname, int age, Sex sex)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Sex = sex;
        }

        //TODO: RSDN+
        /// <summary>
        /// Конструктор по умолчанию объекта класса Person
        /// </summary>
        public Person(): this("Иван", "Петров", 25, Sex.Male)
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
            int age = random.Next(MinAge, MaxAge);
            Sex sex = (Sex)random.Next(0, 2);

            return new Person(name, surname, age, sex);
        }
    }
}
