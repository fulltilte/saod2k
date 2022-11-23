using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string path = "C:\\Users\\d4zzy\\saod2k\\zadanie7_countInputWords\\inputWords\\inputWords\\big.txt";
        StreamReader reader = new StreamReader(path);
        string text = reader.ReadToEnd();
        text += " ";

        string str = "";
        int count_unique = 0;
        int count_find = 0;

        Dictionary<string, int> dictionary = new Dictionary<string, int>();

        List<string> lst = new List<string>();

        Console.Write("Enter the count of words to be found:  ");
        int user_input_count = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < user_input_count; i++)
        {
            Console.Write((i + 1) + ".   ");
            lst.Add(Console.ReadLine());
        }

        Dictionary<string, int> dictionaryOutput = new Dictionary<string, int>();

        Console.Write("\nEnter the word to be found:  ");
        string user_input_word = Console.ReadLine();

        foreach (var symbol in text)
        {
            if ((symbol >= 'a' && symbol <= 'z') || (symbol >= 'A' && symbol <= 'Z') || symbol == '\'')
                str += symbol;
            else if (str.Length > 0)
            {
                if (dictionary.ContainsKey(str))
                    ++dictionary[str];

                else
                    dictionary.Add(str, 1);

                str = "";
            }
        }

        Console.WriteLine();
        Console.WriteLine("-----------------------------------------------------------------\n");

        foreach (var item in dictionary)
        {
            if (item.Value == 1)
                count_unique++;

            if (item.Key == user_input_word)
                count_find += item.Value;

            foreach (var item2 in lst)
                if (item.Key == item2)
                        dictionaryOutput.Add(item.Key, item.Value);
        }

        foreach (var item in dictionaryOutput)
            Console.WriteLine(item.Key + "  ---  " + item.Value);

        Console.WriteLine("\nCount of unique words:   " + count_unique);
        Console.WriteLine("\nCount of word("+ user_input_word + ") found:    " + count_find);
    }
}
