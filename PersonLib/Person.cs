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
}
