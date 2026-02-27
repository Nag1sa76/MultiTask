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
        // Реализация программы поиска ближайшего меньшего справа элемента
        Console.WriteLine("Введите количество городов:");
        int N = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите цены:");
        int[] prices = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        int[] result = new int[N];

        for (int i = 0; i < N; i++)
        {
            result[i] = -1; // по умолчанию
            for (int j = i + 1; j < N; j++)
            {
                if (prices[j] < prices[i])
                {
                    result[i] = j;
                    break; // нашли первый подходящий город справа
                }
            }
        }

        // вывод результата
        Console.WriteLine(string.Join(" ", result));
    }

    static void Task2()
    {
        Queue<int> queue = new Queue<int>();
        string input;

        while (true)
        {
            input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
                continue;

            string[] parts = input.Split();
            string command = parts[0];

            switch (command)
            {
                case "push":
                    if (parts.Length == 2 && int.TryParse(parts[1], out int n))
                    {
                        queue.Enqueue(n);
                        Console.WriteLine("ok");
                    }
                    break;

                case "pop":
                    if (queue.Count > 0)
                    {
                        int val = queue.Dequeue();
                        Console.WriteLine(val);
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                    break;

                case "front":
                    if (queue.Count > 0)
                    {
                        Console.WriteLine(queue.Peek());
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                    break;

                case "size":
                    Console.WriteLine(queue.Count);
                    break;

                case "clear":
                    queue.Clear();
                    Console.WriteLine("ok");
                    break;

                case "exit":
                    Console.WriteLine("bye");
                    return;

                default:
                    // Неизвестная команда, можно игнорировать или выводить ошибку
                    break;
            }
        }
        //ok            // после push 5
        //ok            // после push 10
        //5             // front — первый элемент 5
        //2             // size — осталось два элемента [5,10]
        //5             // pop — извлекаем 5
        //10            // pop — извлекаем 10
        //error         // pop — очередь пуста, ошибка
        //ok            // push 20
        //20            // front — первый элемент 20
        //1             // size — один элемент
        //ok            // clear — очищаем очередь
        //0             // size — очередь пустая
        //bye           // команда exit — завершаем программу
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