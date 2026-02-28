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
        string input = Console.ReadLine();
        string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        double[] coefficients = new double[parts.Length];

        for (int i = 0; i < parts.Length; i++)
        {
            coefficients[i] = double.Parse(parts[i]);
        }

        double[] roots = Solve(coefficients);
        Print(roots);
    }

    static double[] Solve(params double[] coefficients)
    {
        // Количество коэффициентов определяет тип уравнения
        if (coefficients.Length == 3)
        {
            // Квадратное: a, b, c
            double a = coefficients[0];
            double b = coefficients[1];
            double c = coefficients[2];

            if (a == 0)
            {
                if (b == 0)
                {
                    // c=0 -> уравнение 0=0, бесконечно много решений, по условию вывести ничего
                    return new double[0];
                }
                else
                {
                    // bx + c=0
                    double root = -c / b;
                    return new double[] { root };
                }
            }

            // Решение квадратного уравнения
            double D = b * b - 4 * a * c;
            if (D < 0)
            {
                return new double[0]; // нет решений
            }
            else if (D == 0)
            {
                double root = -b / (2 * a);
                return new double[] { root };
            }
            else
            {
                double sqrtD = Math.Sqrt(D);
                double x1 = (-b - sqrtD) / (2 * a);
                double x2 = (-b + sqrtD) / (2 * a);
                if (x1 < x2)
                    return new double[] { x1, x2 };
                else
                    return new double[] { x2, x1 };
            }
        }
        else if (coefficients.Length == 2)
        {
            // Линейное: b, c
            double b = coefficients[0];
            double c = coefficients[1];

            if (b == 0)
            {
                // Уравнение c=0
                if (c == 0)
                {
                    // Любое число — корень (бесконечное много решений)
                    return new double[0]; // по условию, возвращаем пустой массив
                }
                else
                {
                    // Нет решений
                    return new double[0];
                }
            }
            else
            {
                double root = -c / b;
                return new double[] { root };
            }
        }
        else if (coefficients.Length == 1)
        {
            // Константа c
            double c = coefficients[0];
            if (c == 0)
            {
                // либо бесконечно много решений, либо 0=0
                return new double[0];
            }
            else
            {
                // Нет решений
                return new double[0];
            }
        }
        else
        {
            return new double[0];
        }
    }

    static void Print(params double[] roots)
    {
        if (roots.Length == 0)
        {
            Console.WriteLine();
            return;
        }

        Array.Sort(roots);

        for (int i = 0; i < roots.Length; i++)
        {
            Console.Write(roots[i]);
            if (i < roots.Length - 1)
                Console.Write(" ");
        }
        Console.WriteLine();
        // Пример ввода:
        // 1 -3 2
        // Выходит:
        // 1 2
        //
        // Другие примеры:
        //
        // 0 2
        // Вывод: 0
        //
        // 5
        // Вывод: ничего (пустая строка)
        //
        // 0 0 0
        // Вывод: ничего (бесконечно много решений, часть условий обработает это)
    }

    static void Task4()
    {
        //Карты вводим в строку через пробел(1 3 5 7 9)
        Queue<int> firstPlayer = new Queue<int>();
        Queue<int> secondPlayer = new Queue<int>();

        // Читаем карты каждого игрока
        foreach (var card in Console.ReadLine().Split())
            firstPlayer.Enqueue(int.Parse(card));
        foreach (var card in Console.ReadLine().Split())
            secondPlayer.Enqueue(int.Parse(card));

        int moves = 0;
        const int maxMoves = 100;

        while (firstPlayer.Count > 0 && secondPlayer.Count > 0 && moves < maxMoves)
        {
            moves++;
            int card1 = firstPlayer.Dequeue();
            int card2 = secondPlayer.Dequeue();

            if (card1 > card2)
            {
                // Первый игрок выигрывает раунд
                firstPlayer.Enqueue(card1);
                firstPlayer.Enqueue(card2);
            }
            else
            {
                // Второй игрок выигрывает раунд
                secondPlayer.Enqueue(card2);
                secondPlayer.Enqueue(card1);
            }
        }

        // Определяем победителя
        if (firstPlayer.Count == 0)
            Console.WriteLine("second");
        else
            Console.WriteLine("first");

        Console.WriteLine(moves);
    }
    static void Task5()
    {
        RunRectangleTask(); // 5 3
    }

    static void RunRectangleTask()
    {
        string input = Console.ReadLine();
        string[] parts = input.Split();

        int width = int.Parse(parts[0]);
        int height = int.Parse(parts[1]);

        Rectangle rect = new Rectangle(width, height);

        Console.WriteLine(rect.GetArea());
        Console.WriteLine(rect.GetPerimeter());
        Console.WriteLine(rect.ToString());
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

    class Rectangle
    {
        public int Width { get; private set; }
        public int Height { get; private set; }

        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public int GetArea()
        {
            return Width * Height;
        }

        public int GetPerimeter()
        {
            return 2 * (Width + Height);
        }

        public override string ToString()
        {
            return $"Rectangle {Width}x{Height}";
        }
    }
}