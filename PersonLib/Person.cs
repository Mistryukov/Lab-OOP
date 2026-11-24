using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Text.RegularExpressions;

namespace PersonLib
{
    public enum Sex
    {
        Male,
        Female
    }
    public class Person
    {
        private string _name;
        private string _surname;
        private int _age;
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

        public Person(): this("Иван","Петров",25,Sex.Male)
        { }

        public string GetInfo()
        {
            return $" {Name}; {Surname}; {Age}; {Sex}";
        }       

        public static Person GetRandomPerson()
        {
            Random random = new Random();
            string[] names = { "Боб", "Джек", "Марти", "Розалия", "Лусия" };
            string[] surnames = { "Браун", "Гонзалес", "Саламанка", "Ричардс", "Трамп" };

            string name = names[random.Next(names.Length)];
            string surname = surnames[random.Next(surnames.Length)];

            int age = random.Next(0, 99);

            Sex sex = (Sex)random.Next(0,2);

            return new Person(name, surname, age, sex);
        }
    }

    public class PersonList
    {
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
            _items = new Person[3];
            _count = 0;
        }

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
                if (index<0 || index>=_count)
                {
                    throw new IndexOutOfRangeException();
                }
                else return _items[index];
            }
            set
            {
                if (index < 0 || index >= _count)
                {
                    throw new IndexOutOfRangeException();
                }
                else _items[index] = value;
            }
        }

        public void RemoveAt(int index)
        {
            if ( index<0 || index>=_count)
            {
                throw new IndexOutOfRangeException();
            }
            for (int i = index; i < _count - 1 ; i++)
            {
                _items[i] = _items[i + 1];
            }
            _count--;
            _items[_count] = null;
        }

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

        public void Clear()
        {
            for (int i = 0; i < _count; i++)
            {
                _items[i] = null;
            }
            _count = 0;
        }

        public void Remove(Person item)
        {
            int index = IndexOf(item);
            if (index != -1)
            {
                RemoveAt(index);
            }
        }           
    }

    public static class StringFormat
    {
        public static string NameFormat(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Имя не может быть пустым");
            }

            value = Regex.Replace(value.Trim(), @"\s+", " ");

            string pattern = @"^[А-Яа-яЁёA-Za-z]+(?:[ -][А-Яа-яЁёA-Za-z]+)*$";
            if (!Regex.IsMatch(value, pattern))
            {
                throw new ArgumentException("Допускаются только русские и английские буквы, пробелы и дефисы");
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
