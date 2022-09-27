using System;

Saod s = new Saod();
s.AddToArray();

public class myStack<T>
{
    private T[] items;
    private int count;
    const int n = 10;  

    public myStack()
    {
        items = new T[n];
    }

    public myStack(int length)
    {
        items = new T[length];
    }

    public bool IsEmpty
    {
        get { return count == 0; }
    }

    public int Count
    {
        get { return count; }
    }

    public void Push(T item)
    {
        if (count == items.Length)
            Resize(items.Length + 10);

        items[count++] = item;
    }

    public T Pop()
    {
        if (IsEmpty)
            throw new InvalidOperationException("Стек пуст");

        T item = items[--count];
        items[count] = default(T);

        if (count > 0 && count < items.Length - 10)
            Resize(items.Length - 10);

        return item;
    }

    private void Resize(int max)
    {
        T[] tempItems = new T[max];
        for (int i = 0; i < count; i++)
            tempItems[i] = items[i];
        items = tempItems;
    }
}

public class Saod
{
    public void AddToArray()
    {
        Random rnd = new Random();

        Console.Write("Введите число строк: ");
        int n = Convert.ToInt32(Console.ReadLine());

        Console.Write("Введите число столбцов: ");
        int m = Convert.ToInt32(Console.ReadLine());

        Console.Write("Введите вероятность: ");
        int probability = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine();

        char[] array = new char[n * m];

        int count_plus = 0;
        int count_minus = 0;

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                int temp_probability = rnd.Next(1, 11);
                if (probability >= temp_probability)
                {
                    array[i * m + j] = '+';
                    count_plus++;
                }
                else array[i * m + j] = ' ';
            }
        }

        Console.WriteLine("\t" + "Матрица" + "\n");

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write(array[i * m + j]);
            }
            Console.WriteLine();
        }

        Console.WriteLine();

        Console.Write("Введите х: ");
        int x = Convert.ToInt32(Console.ReadLine());

        Console.Write("Введите у: ");
        int y = Convert.ToInt32(Console.ReadLine());

        myStack<int> s = new myStack<int>();

        s.Push(x);
        s.Push(y);

        //s.Push(x, y);

        while (s.Count > 0)
        {
            y = s.Pop();
            x = s.Pop();

            //(x, y) = s.Pop(x, y);

            if (x >= 0 && y >= 0 && x < n && y < m && array[x * m + y] == ' ')
            {
                count_minus++;

                array[x * m + y] = '-';

                s.Push(x + 1);
                s.Push(y);

                s.Push(x - 1);
                s.Push(y);

                s.Push(x);
                s.Push(y + 1);

                s.Push(x);
                s.Push(y - 1);

            }
        }

        Console.WriteLine("\t" + "Матрица" + "\n");

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write(array[i * m + j]);
            }
            Console.WriteLine();
        }

        Console.WriteLine("Плюс - " + count_plus);
        Console.WriteLine("Минус - " + count_minus);
        Console.WriteLine("Пустые - " + ((n * m) - (count_plus + count_minus)));
    }
}