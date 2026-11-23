using PersonLib;

internal class Program
{
    private static void Main(string[] args)
    {
        //Проверка конструкторов
        Person pers1 = new Person();
        Console.WriteLine(pers1.GetInfo());
        Person pers2 = new Person("Илья","Муромец",52,Sex.Male);
        Console.WriteLine(pers2.GetInfo());

        Person pers11 = new Person("Илья", "Муромец", 52, Sex.Male);

        PersonList people = new PersonList();
        people.Add(pers1);
        people.Add(pers2);

        //Person pers3 = people[1];
        //Console.WriteLine(pers3.GetInfo());
        //Person pers4 = people[2];
        //Console.WriteLine(pers4.GetInfo());
        //Person pers5 = people[3];
        //Console.WriteLine(pers5.GetInfo());
        Console.WriteLine(people.Count);
        Console.WriteLine(people.IndexOf(pers11));
    }
}
    