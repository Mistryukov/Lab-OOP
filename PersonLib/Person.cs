using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;

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

        public string Name { get; set; } //Убрать гет сет
        //Заготовка для проверок
        //{
        //    get
        //    {
        //        return _name;
        //    }
        //    set
        //    {
        //        _name = value;
        //    }
        //}

        public string Surname { get; set; } //Убрать гет сет
        //Заготовка для проверок
        //{
        //    get
        //    {
        //        return _surname;
        //    }
        //    set
        //    {
        //        _surname = value;
        //    }
        //}

        public int Age { get; set; } //Убрать гет сет
        //Заготовка для проверок
        //{
        //    get
        //    {
        //        return _age;
        //    }
        //    set
        //    {
        //        _age = value;
        //    }
        //}

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

        //public static Person ReadFromConsole()
        //{
        //    Console.WriteLine("Введите имя (только ru/eng символы): ");
        //    string name = Console.ReadLine();
        //
        //    Console.WriteLine("Введите фамилию (только ru/eng символы): ");
        //    string surname = Console.ReadLine();
        //
        //    Console.WriteLine("Введите возраст: ");
        //
        //
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
}
