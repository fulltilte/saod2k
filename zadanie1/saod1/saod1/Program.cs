using System;

Saod s = new Saod();
s.AddToArray();

public class Saod
{
    public void AddToArray()
    {
        Random rnd = new Random(1);
        
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

        for (int i = 0; i < n * m; i++)
        {
            int temp_probability = rnd.Next(1, 11);

            if (probability >= temp_probability)
            {
                array[i] = '+';
                //Console.Write(array[i]);
            }
            else
            {
                array[i] = ' ';
                //Console.Write(" ");
            }
        }

        Console.WriteLine("\t" + "Матрица" + "\n");
        //Console.WriteLine("012");
        Console.Write("\t" + array[0]);
        for (int i = 1; i <= (m * n) - 1; i++)
        {
            if(i % m == 0)
                Console.Write("\n" + "\t");

            Console.Write(array[i]);
        }

        Console.WriteLine();

        Console.Write("Введите х: ");
        int x = Convert.ToInt32(Console.ReadLine());

        Console.Write("Введите у: ");
        int y = Convert.ToInt32(Console.ReadLine());

        f(x, y, array);

        void f(int x, int y, char[] array)
        {
            if ((array[((m * (y - 1)) + x) - 1] == ' ') && (x >= 0) && (y >= 0) && (x < n) && (y < m))
            {
                array[((m * (y - 1)) + x) - 1] = '-';
                f(x + 1, y, array);
                f(x - 1, y, array);
                f(x, y + 1, array);
                f(x, y - 1, array);
            }
        }

        Console.WriteLine("\t" + "Матрица" + "\n");

        Console.Write("\t" + array[0]);
        for (int i = 1; i <= (m * n) - 1; i++)
        {
            if (i % m == 0)
                Console.Write("\n" + "\t");

            Console.Write(array[i]);
        }
    }
}
