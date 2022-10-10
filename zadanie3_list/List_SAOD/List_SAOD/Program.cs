using System;
using System.IO;
using System.Runtime;
using System.Runtime.Versioning;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Collections.ObjectModel;
using System.Security.Permissions;

saod s = new saod();
s.Start();

public class myList<T>
{
    private const int _defaultCapacity = 4;
    private T[] _items;
    private int _size;
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
        {
            Array.Copy(_items, index, _items, index + 1, _size - index);
        }

        _items[index] = item;
        _size++;
    }

    public int FindIndex(Predicate<T> match)
    {
        Contract.Ensures(Contract.Result<int>() >= -1);
        Contract.Ensures(Contract.Result<int>() < Count);
        return FindIndex(0, _size, match);
    }

    public int FindIndex(int startIndex, Predicate<T> match)
    {
        Contract.Ensures(Contract.Result<int>() >= -1);
        Contract.Ensures(Contract.Result<int>() < startIndex + Count);
        return FindIndex(startIndex, _size - startIndex, match);
    }

    public int FindIndex(int startIndex, int count, Predicate<T> match)
    {
        Contract.Ensures(Contract.Result<int>() >= -1);
        Contract.Ensures(Contract.Result<int>() < startIndex + count);
        Contract.EndContractBlock();

        int endIndex = startIndex + count;
        for (int i = startIndex; i < endIndex; i++)
        {
            if (match(_items[i])) return i;
        }
        return -1;
    }

    public T Find(Predicate<T> match)
    {
        for (int i = 0; i < _size; i++)
        {
            if (match(_items[i])) return _items[i];
        }

        return default(T);
    }

    public void ForEach(Action<T> action)
    {
        for (int i = 0; i < _size; i++)
        {
            action(_items[i]);
        }
    }

    /*
    public Enumerator GetEnumerator()
    {
        return new Enumerator(this);
    }

    
    public struct Enumerator
    {
        private List<T> list;
        private int index;
        private T current;

        internal Enumerator(List<T> list)
        {
            this.list = list;
            index = 0;
            current = default(T);
        }

        public T Current
        {
            get
            {
                return current;
            }
        }
    }
    */
}

public class saod
{
    public void Start()
    {
        myList<int> list = new myList<int>();

        List<int> l = new List<int>();

        for (int i = 0; i <= 10; i++)
        {
            list.Add((i));
        }

        Console.WriteLine(list.Count);

        list.Insert(0, 5);

        Console.WriteLine(list.Count);

        Console.WriteLine(list.FindIndex(item => item == 2));

        Console.WriteLine(list.Find(item => item == 2));

        //Console.WriteLine(list.ForEach());
    }
}