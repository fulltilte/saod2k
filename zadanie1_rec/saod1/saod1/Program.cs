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

        f(x, y, n, m, array);

        void f(int x, int y, int n, int m, char[] array)
        {
            if (x >= 0 && y >= 0 && x < n && y < m && array[x * m + y] == ' ' )
            {
                array[x * m + y] = '-';
                f(x + 1, y, n, m, array);
                f(x - 1, y, n, m, array);
                f(x, y + 1, n, m, array);
                f(x, y - 1, n, m, array);
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
