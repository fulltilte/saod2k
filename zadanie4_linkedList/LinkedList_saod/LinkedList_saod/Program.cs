using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

public class myLinkedList<T> : IEnumerable
{
    private int count;
    private Node<T> root;
    private Node<T> sentinel;

    public int Count { get { return count; } }

    public myLinkedList()
    {
        Node<T> newEl = new(default(T));
        root = newEl;
        sentinel = newEl;
    }

    public void PushBack(T value)
    {
        Node<T> newEl = new(value);
        if (root == sentinel)
        {
            newEl.Next = sentinel;
            root = newEl;
            sentinel = newEl.Next;
        }

        else
        {
            Node<T> curEl = root;

            //  Ищем последний элемент
            while (curEl.Next != sentinel)
                curEl = curEl.Next;
            newEl.Next = sentinel;
            curEl.Next = newEl;
        }
        count++;
    }

    public void PushFront(T value)
    {
        Node<T> newEl = new(value);
        if (root == sentinel)
        {
            newEl.Next = sentinel;
            root = newEl;
            sentinel = newEl.Next;
        }

        else
        {
            newEl.Next = root;
            root = newEl;
            
        }
        count++;
    }

    public void PopFront()
    {
        if (count > 0)
        {
            root = root.Next;
        }
    }

    public T GetValue(int index)
    {

        var cur = root;
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
            var cur = root;
            for (int i = 0; i < index; i++)
                cur = cur.Next;
            cur.Value = value;
        }

        get
        {
            var node = root;
            for (int i = 0; i < index; i++)
            {
                node = node.Next;
            }
            return node.Value;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        var current = root;
        while (current != sentinel)
        {
            yield return current.Value;
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
    public static void print_lst(myLinkedList<char> l)
    {
        foreach (var item in l)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
    static void Main(string[] args)
    {
        //myLinkedList<char> l = new myLinkedList<char>();

        var lst = new myLinkedList<char>(); // ваш список
        Console.WriteLine(lst.Count + " ");
        
        for (int i = 0; i < 5; i++)
            lst.PushBack((char)(i + 97));

        print_lst(lst);

        lst.PushFront('z');

        print_lst(lst);

        lst.PopFront();
        print_lst(lst);

    }
}