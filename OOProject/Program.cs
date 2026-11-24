using PersonLib;

internal class Program
{
    private static void Main(string[] args)
    {
        //Демонстрация правильности работы
        Person PersonOne = new Person();
        Person PersonTwo = new Person("Илья", "Муромец", 52, Sex.Male);
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
        Console.WriteLine(
            "Нажмите любую клавишу " +
            "для отображения содержимого списков"
            );
        Console.ReadKey();
        Console.WriteLine();
        Console.Clear();
        
        Console.WriteLine(
            "В первом списке " + FirstList.Count + " человека: "
            );
        ListInfo(FirstList);
        Console.WriteLine(
            "Во втором списке " + SecondList.Count + " человека: "
            );
        ListInfo(SecondList);
        
        //Добавление нового человека в первый список
        Console.WriteLine(
            "Нажмите любую клавишу для добавления человека в 1 список"
            );
        Console.ReadKey();
        Console.WriteLine();
        Console.Clear();
        
        Person PersonSeven = new Person("Тест", "Тестова", 67, Sex.Female);
        FirstList.Add(PersonSeven);
        
        Console.WriteLine("В первый список добавлен следующий человек:");
        Console.WriteLine(FirstList[3].GetInfo());
        Console.WriteLine("Состав первого списка:");
        ListInfo(FirstList);
        
        //Копирование второго человека из 1 списка в конец 2 списка
        Console.WriteLine(
            "Нажмите любую клавишу для копирования человека из 1 списка"
            );
        Console.ReadKey();
        Console.WriteLine();
        Console.Clear();
        
        SecondList.Add(FirstList[1]);
        
        Console.WriteLine("Проверка копирования человека");
        Console.WriteLine("Первый список: ");
        ListInfo(FirstList);
        Console.WriteLine("Второй список: ");
        ListInfo(SecondList);
        
        //Удаление второго человека из 1 списка
        Console.WriteLine(
            "Нажмите любую клавишу для удаления человека из 1 списка"
            );
        Console.ReadKey();
        Console.WriteLine();
        Console.Clear();
        
        FirstList.RemoveAt(1);
        
        Console.WriteLine("Проверка удаления человека");
        Console.WriteLine("Первый список: ");
        ListInfo(FirstList);
        Console.WriteLine("Второй список: ");
        ListInfo(SecondList);
        
        //Очистка второго списка
        Console.WriteLine("Нажмите любую клавишу для очистки 2 списка");
        Console.ReadKey();
        Console.WriteLine();
        Console.Clear();
        
        SecondList.Clear();
        Console.WriteLine("Проверка очистки списка");
        Console.WriteLine(
            "Во втором списке " + SecondList.Count + " человек: "
            );
        ListInfo(SecondList);
        
        Person NewPerson = CreatePerson();
        Console.WriteLine(NewPerson.GetInfo());
        
        ListInfo(FirstList);

        Person RandomPerson = Person.GetRandomPerson();
        Console.WriteLine(RandomPerson.GetInfo());
    }


    static Person CreatePerson()
    {
        Console.WriteLine("Введите имя (только ru/eng символы): ");
        string name = Console.ReadLine();
    
        Console.WriteLine("Введите фамилию (только ru/eng символы): ");
        string surname = Console.ReadLine();
    
        Console.WriteLine("Введите возраст (число полных лет): ");
        int age;

        while (!int.TryParse(Console.ReadLine(), out age) || age < 0)
        {
            Console.WriteLine(
                "Неверный формат ввода, введите число больше или равное нулю"
                );
        }

        Console.WriteLine(
            "Введите цифру, означающую пол или название пола на английском"
            );
        Console.WriteLine("0/Male - Мужской");
        Console.WriteLine("1/Female - женский");
        Sex sex;
        while (!Enum.TryParse(Console.ReadLine(), out sex) 
            || !Enum.IsDefined(typeof(Sex), sex))
        {
            Console.WriteLine("Неверное значение, попробуйте снова");
        }

        return new Person(name, surname, age, sex);
    }
    public static void ListInfo(PersonList list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            Console.WriteLine(list[i].GetInfo());
        }
    }
}
    