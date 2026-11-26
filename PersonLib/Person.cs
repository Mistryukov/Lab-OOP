using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Text.RegularExpressions;

namespace PersonLib
{
    //TODO: To separate file
    /// <summary>
    /// Пол человека. Их два. Итого один целый.
    /// </summary>
    public enum Sex
    {
        Male,
        Female
    }

    //TODO: To separate file
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


    /// <summary>
    /// //TODO: RSDN
    /// Хранит множество объектов класса Person. Позволяет проводить операции над отдельными объектами и группами объектов класса Person
    /// </summary>
    public class PersonList
    {
        //TODO: XML
        private Person[] _items;
        private int _count;

        public int Count
        {
            get
            {
                return _count;
            }
        }

        public PersonList()
        {
            //TODO: refactor
            _items = new Person[3];
            _count = 0;
        }

        /// <summary>
        /// Добавляет существующую персону в список
        /// </summary>
        /// <param name="item"></param>
        public void Add(Person item)
        {
            if (_count == _items.Length)
            {
                Expand();
            }
            _items[_count] = item;
            _count++;
        }

        private void Expand()
        {
            //TODO: RSDN
            Person[] newItems = new Person[_items.Length+1];
            for (int i = 0; i < _items.Length; i++)
            {
                newItems[i] = _items[i];
            }
            _items = newItems;
        }

        public Person this[int index]
        {
            get
            {
                //TODO: RSDN
                //TODO: duplication
                if (index<0 || index>=_count)
                {
                    throw new IndexOutOfRangeException();
                }
                //TODO: {}
                else return _items[index];
            }
            set
            {
                //TODO: duplication
                if (index < 0 || index >= _count)
                {
                    throw new IndexOutOfRangeException();
                }
                //TODO: {}
                else _items[index] = value;
            }
        }

        /// <summary>
        /// Удаляет из списка персону, соответствующую заданному индексу
        /// </summary>
        /// <param name="index"></param>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public void RemoveAt(int index)
        {
            //TODO: refactor
            //TODO: duplication
            if ( index<0 || index>=_count)
            {
                throw new IndexOutOfRangeException();
            }
            for (int i = index; i < _count - 1 ; i++)
            {
                _items[i] = _items[i + 1];
            }
            _count--;
            //TODO: not safe
            _items[_count] = null;
        }

        /// <summary>
        /// Возвращает индекс персоны из списка по заданному названию персоны
        /// </summary>
        /// <param name="item"></param>
        /// <returns>Индекс персоны или "-1" при отсутствии персоны в списке</returns>
        public int IndexOf(Person item)
        {
            for (int i = 0; i < _count; i++)
            {
                if (_items[i] == item)
                {
                    return i;
                }
            }
            return -1;
        }
        /// <summary>
        /// Очищает список, удаляя всех персон
        /// </summary>
        public void ClearList()
        {
            for (int i = 0; i < _count; i++)
            {
                _items[i] = null;
            }
            _count = 0;
        }

        /// <summary>
        /// Удаляет из списка персону по заданному названию
        /// </summary>
        /// <param name="item"></param>
        public void Remove(Person item)
        {
            int index = IndexOf(item);

            if (index != -1)
            {
                RemoveAt(index);
            }
        }           
    }

    /// <summary>
    /// Предоставляет набор методов взаимодействия со строками и приведением их к определенному формату
    /// </summary>
    public static class StringFormat
    {
        /// <summary>
        /// Обрабатывает входную строку, приводя ее к заданному формату (формат фиксирован)
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Строка, приведенная под формат</returns>
        /// <exception cref="ArgumentException"></exception>
        public static string NameFormat(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Имя не может быть пустым");
            }

            value = Regex.Replace(value.Trim(), @"\s+", " ");
            //TODO: different languages
            string pattern = @"^[А-Яа-яЁёA-Za-z]+(?:[ -][А-Яа-яЁёA-Za-z]+)*$";

            if (!Regex.IsMatch(value, pattern))
            {
                throw new ArgumentException(
                    "Введенные данные не соответствуют формату"
                    );
            }

            string[] words = value.ToLower().Split(' ', '-');

            for (int i = 0; (i < words.Length);  i++)
            {
                char[] letters = words[i].ToCharArray();
                letters[0] = Char.ToUpper(letters[0]);
                words[i] = string.Join("", letters);
            }
            return string.Join("-", words);                
        }
    }
}
