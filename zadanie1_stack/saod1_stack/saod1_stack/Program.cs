using System;
using System.Timers;
using System.Threading;
//using System.Diagnostics.Stopwatch watch;

Saod s = new Saod();
s.AddToArray();


public class myStack<T>
{
    private T[] _array;
    private int _size;
    private const int _defaultCapacity = 4;
    static T[] _emptyArray = new T[0];


    public myStack()
    {
        _array = _emptyArray;
        _size = 0;
    }

    public myStack(int capacity)
    {
        _array = new T[capacity];
        _size = 0;
    }

    public int Count
    {
        get { return _size; }
    }

    public T Pop()
    {
        T item = _array[--_size];
        _array[_size] = default(T);
        return item;
    }

    public void Push(T item)
    {
        if (_size == _array.Length)
        {
            T[] newArray = new T[Convert.ToInt32((_array.Length == 0) ? _defaultCapacity : 1.5 * _array.Length)];
            Array.Copy(_array, 0, newArray, 0, _size);
            _array = newArray;
        }
        _array[_size++] = item;
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

        /*Console.WriteLine("\t" + "Матрица" + "\n");

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write(array[i * m + j]);
            }
            Console.WriteLine();
        }*/

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

        /*for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write(array[i * m + j]);
            }
            Console.WriteLine();
        }*/

        Console.WriteLine("Плюс - " + count_plus);
        Console.WriteLine("Минус - " + count_minus);
        Console.WriteLine("Пустые - " + ((n * m) - (count_plus + count_minus)));

        System.Diagnostics.Stopwatch watch;

        long elapsedMs;

        int N = 100000;

        var stack = new System.Collections.Generic.Stack<int>();
        watch = System.Diagnostics.Stopwatch.StartNew();

        for (int i = 0; i != N; i++)
        {
            stack.Push(i);
        }
        for (int i = 0; i != N; i++)
        {
            stack.Pop();
        }

        watch.Stop();
        elapsedMs = watch.ElapsedMilliseconds;
        System.Console.WriteLine(elapsedMs);
    }

    
}