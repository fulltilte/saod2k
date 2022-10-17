using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime;
using System.Runtime.Versioning;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Collections.ObjectModel;
using System.Security.Permissions;

Main s = new Main();
s.Start();

internal class myList<T> : IEnumerable
{
    public T[] _items;
    private int _lastIndex = -1;
    private int _size;
    private const int _defaultCapacity = 4;
    static T[] _emptyArray = new T[0];


    public myList()
    {
        _items = _emptyArray;
    }

    public myList(int capacity)
    {
        if (capacity == 0)
            _items = _emptyArray;
        else
            _items = new T[capacity];
    }

    public myList(T[] list)
    {
        _items = list;
    }

    public int Count
    {
        get { return _size; }
    }

    public void Add(T item)
    {
        if (_size == _items.Length)
        {
            T[] newArray = new T[Convert.ToInt32((_items.Length == 0) ? _defaultCapacity : 1.5 * _items.Length)];
            Array.Copy(_items, 0, newArray, 0, _size);
            _items = newArray;
        }
        _items[_size++] = item;
    }

    public void Insert(int index, T item)
    {
        if (_size == _items.Length)
        {
            T[] newArray = new T[Convert.ToInt32((_items.Length == 0) ? _defaultCapacity : 1.5 * _items.Length)];
            Array.Copy(_items, 0, newArray, 0, _size);
            _items = newArray;
        }

        if (index < _size)
            Array.Copy(_items, index, _items, index + 1, _size - index);

        _items[index] = item;
        _size++;
    }

    public int FindIndex(Predicate<T> predicate)
    {
        Contract.Ensures(Contract.Result<int>() >= -1);
        Contract.Ensures(Contract.Result<int>() < Count);
        return FindIndex(0, _size, predicate);
    }

    public int FindIndex(int startIndex, Predicate<T> predicate)
    {
        Contract.Ensures(Contract.Result<int>() >= -1);
        Contract.Ensures(Contract.Result<int>() < startIndex + Count);
        return FindIndex(startIndex, _size - startIndex, predicate);
    }

    public int FindIndex(int startIndex, int count, Predicate<T> predicate)
    {
        Contract.Ensures(Contract.Result<int>() >= -1);
        Contract.Ensures(Contract.Result<int>() < startIndex + count);
        Contract.EndContractBlock();

        int endIndex = startIndex + count;
        for (int i = startIndex; i < endIndex; i++)
        {
            if (predicate(_items[i])) return i;
        }
        return -1;
    }

    public T Find(Predicate<T> predicate)
    {
        for (int i = 0; i < _size; i++)
        {
            if (predicate(_items[i])) return _items[i];
        }

        return default(T);
    }

    public void ForEach(Action<T> action)
    {
        foreach (var item in _items)
            action(item);
    }

    public IEnumerator GetEnumerator()
    {
        return _items.GetEnumerator();
    }

}

public class Main
{
    public void Start()
    {
        myList<int> list = new myList<int>();

        for (int i = 1; i < 10; i++)
            list.Add(i);
        
        foreach (int i in list)
            Console.Write(i + " ");

        Console.WriteLine();

        Console.WriteLine(list.FindIndex(i => 0 == i % 2) + " ");


        list.Insert(2, -1);
        foreach (int i in list)
            Console.Write(i + " ");

        Console.ReadLine();
    }
}