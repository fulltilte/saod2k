using System;
using System.Collections;
using System.Collections.Generic;

public class Node<T>
{
    private T val;
    private Node<T> next;

    public Node(T value)
    {
        val = value;
        next = null;
    }

    public T Value { get { return val; } set { val = value; } }
    public Node<T> Next { get { return next; } set { next = value; } }
}

public class MyList<T> : IEnumerable
{
    private int count;
    public int counter1;
    public int counter2;
    private Node<T> head;

    public int Count { get { return count; } }

    public void PushBack(T value)
    {
        if (head == null)
        {
            head = new Node<T>(value);
        }
        else
        {
            var current = head;
            while (current.Next != null)
                current = current.Next;
            current.Next = new Node<T>(value);
        }
        count++;
    }

    public T GetValue(int index)
    {

        var cur = head;
        for (int i = 0; i < index; i++)
        {
            cur = cur.Next;

        }
        return cur.Value;
    }

    public T this[int index]
    {
        set
        {
            var cur = head;
            for (int i = 0; i < index; i++)
                cur = cur.Next;
            cur.Value = value;
        }

        get
        {
            var node = head;
            for (int i = 0; i < index; i++)
            {
                node = node.Next;
                ++counter2;
            }
            return node.Value;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        var current = head;
        while (current != null)
        {
            yield return current.Value;
            ++counter1;
            current = current.Next;
        }
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}


class Program
{
    static void Main(string[] args)
    {
        MyList<int> list = new MyList<int>();
        for (int i = 0; i < 100; i++)
        {
            list.PushBack(i);
        }
        for (int i = 0; i < list.Count; i++)
        {
            Console.WriteLine(list[i]);
        }
        Console.WriteLine(list.counter2);
        foreach (var obj in list)
        {
            Console.WriteLine(obj);
        }
        Console.WriteLine(list.counter1);
    }
}