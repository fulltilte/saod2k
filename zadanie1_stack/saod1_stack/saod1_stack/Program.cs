using System;

Saod s = new Saod();
s.AddToArray();

public class Saod
{
    public void AddToArray()
    {
        Random rnd = new Random();

        Console.Write("Введите число строк: ");
        int n = Convert.ToInt32(Console.ReadLine());

        Console.Write("Введите число столбцов: ");
        int m = Convert.ToInt32(Console.ReadLine());

        //Console.Write("Введите символ: ");
        //char c = Convert.ToChar(Console.ReadLine());

        Console.Write("Введите вероятность: ");
        int probability = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine();

        char[] array = new char[n * m];

        

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                int temp_probability = rnd.Next(1, 11);
                if (probability >= temp_probability)
                {
                    array[i * m + j] = '+';
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

        Stack<int> s = new Stack<int>();

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
    }
}