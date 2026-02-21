using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Выберите задачу:");
            Console.WriteLine("1. Задача 1");
            Console.WriteLine("2. Задача 2");
            Console.WriteLine("3. Задача 3");
            Console.WriteLine("4. Задача 4");
            Console.WriteLine("5. Задача 5");
            Console.WriteLine("6. Задача 6");
            Console.WriteLine("7. Задача 7");
            Console.WriteLine("8. Задача 8");
            Console.WriteLine("0. Выход");

            Console.Write("Введите номер: ");
            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Некорректный ввод, попробуйте снова.");
                continue;
            }

            if (choice == 0)
                break;

            switch (choice)
            {
                case 1:
                    Task1();
                    break;
                case 2:
                    Task2();
                    break;
                case 3:
                    Task3();
                    break;
                case 4:
                    Task4();
                    break;
                case 5:
                    Task5();
                    break;
                case 6:
                    Task6();
                    break;
                case 7:
                    Task7();
                    break;
                case 8:
                    Task8();
                    break;
                default:
                    Console.WriteLine("Некорректный выбор, попробуйте снова.");
                    break;
            }

            Console.WriteLine();
        }
    }

    static void Task1()
    {
    }

    static void Task2()
    {
    }

    static void Task3()
    {
    }

    static void Task4()
    {
    }

    static void Task5()
    {
    }

    static void Task6()
    {
    }

    static void Task7()
    {
    }

    static void Task8()
    {
    }
}