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
    }
}
    