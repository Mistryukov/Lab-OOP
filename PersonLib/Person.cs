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
            return "Person:\n" +
                $" {Name}\n" +
                $" {Surname}\n" +
                $" {Age}\n" +
                $" {Sex}\n"; ;
        }

    }

    public class PersonList<Person>
    {
        private Person[] _items;
        private int _index;
        private int _count;

        public void Add(Person item)
        {
            //_items.Add(item);
        }






            // Adds the given object to the end of this list. The size of the list is
            // increased by one. If required, the capacity of the list is doubled
            // before adding the new element.
            //
       //[MethodImpl(MethodImplOptions.AggressiveInlining)]
       //public void Add(T item)
       //{
       //    _version++;
       //    T[] array = _items;
       //    int size = _size;
       //    if ((uint)size < (uint)array.Length)
       //    {
       //        _size = size + 1;
       //        array[size] = item;
       //    }
       //    else
       //    {
       //        AddWithResize(item);
       //    }
       //}

    }
}
