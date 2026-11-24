using PersonLib;

internal class Program
{
    private static void Main(string[] args)
    {
        //Демонстрация правильности работы
        Person PersonOne = new Person();
        Person PersonTwo = new Person("Илья","Муромец",52,Sex.Male);
        Person PersonThree = new Person("Хилари", "Клинтон", 66, Sex.Female);
        Person PersonFour = new Person("Змей", "Тугарин", 28, Sex.Male);
        Person PersonFive = new Person("Добрыня", "Никитич", 48, Sex.Male);
        Person PersonSix = new Person("Джейн", "Доу", 30, Sex.Female);

        //Создание списков персон   
        PersonList FirstList = new PersonList();
        FirstList.Add(PersonOne);
        FirstList.Add(PersonTwo);
        FirstList.Add(PersonThree);
        PersonList SecondList = new PersonList();
        SecondList.Add(PersonFour);
        SecondList.Add(PersonFive);
        SecondList.Add(PersonSix);

        //Вывод содержимого списков на экран
        Console.WriteLine("Нажмите любую клавишу для отображения содержимого списков");
        Console.ReadKey();
        Console.WriteLine();
        Console.Clear();

        Console.WriteLine("В первом списке " + FirstList.Count + " человека: ");
        Console.WriteLine("Персоны, входящие в первый список");
        Console.WriteLine(FirstList[0].GetInfo());
        Console.WriteLine(FirstList[1].GetInfo());
        Console.WriteLine(FirstList[2].GetInfo());
        Console.WriteLine("Во втором списке " + SecondList.Count + " человека: ");
        Console.WriteLine("Персоны, входящие во второй список");
        Console.WriteLine(SecondList[0].GetInfo());
        Console.WriteLine(SecondList[1].GetInfo());
        Console.WriteLine(SecondList[2].GetInfo());

        //Добавление нового человека в первый список
        Console.WriteLine("Нажмите любую клавишу для добавления человека в 1 список");
        Console.ReadKey();
        Console.WriteLine();
        Console.Clear();

        Person PersonSeven = new Person("Тест", "Тестова", 67, Sex.Female);
        FirstList.Add(PersonSeven);

        Console.WriteLine("В первый список добавлен следующий человек:");
        Console.WriteLine(FirstList[3].GetInfo());

        //Копирование второго человека из 1 списка в конец 2 списка
        Console.WriteLine("Нажмите любую клавишу для копирования человека из 1 списка");
        Console.ReadKey();
        Console.WriteLine();
        Console.Clear();

        SecondList.Add(FirstList[1]);   

        Console.WriteLine("Проверка копирования человека");
        Console.WriteLine("В первом списке " + FirstList.Count + " человека: ");
        Console.WriteLine("Второй человек в 1 списке:");
        Console.WriteLine(FirstList[1].GetInfo());
        Console.WriteLine("Во втором списке " + SecondList.Count + " человека: ");
        Console.WriteLine("Четвертый человек во 2 списке:");
        Console.WriteLine(SecondList[3].GetInfo());

        //Удаление второго человека из 1 списка
        Console.WriteLine("Нажмите любую клавишу для удаления человека из 1 списка");
        Console.ReadKey();
        Console.WriteLine();
        Console.Clear();

        FirstList.RemoveAt(1);

        Console.WriteLine("Проверка удаления человека");
        Console.WriteLine("В первом списке " + FirstList.Count + " человека: ");
        Console.WriteLine(FirstList[1].GetInfo());
        Console.WriteLine("Во втором списке " + SecondList.Count + " человека: ");
        Console.WriteLine(SecondList[3].GetInfo());

        //Очистка второго списка
        Console.WriteLine("Нажмите любую клавишу для очистки 2 списка");
        Console.ReadKey();
        Console.WriteLine();
        Console.Clear();

        SecondList.Clear();
        Console.WriteLine("Проверка очистки списка");
        Console.WriteLine("Во втором списке " + SecondList.Count + " человек: ");

    }
}
    