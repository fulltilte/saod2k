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

    public void PushBack(T value)
    {
        Node<T> newEl = new(value)
        {
            Next = sentinel
        };

        if (root == sentinel)
        {
            root = newEl;
            sentinel = newEl;
        }

        else
        {
            Node<T> curEl = root;

            //  Ищем последний элемент
            while (curEl != null && curEl.Next != sentinel)
                curEl = curEl.Next;

            if (curEl != null)
                curEl.Next = newEl;
        }
        count++;
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
        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void print_lst(myLinkedList<char> l)
    {
        foreach (var item in l)
        {
            Console.Write(item + " ");
        }
    }
}


class Program
{
    static void Main(string[] args)
    {
        myLinkedList<char> l = new myLinkedList<char>();

        var lst = new myLinkedList<char>(); // ваш список
        Console.WriteLine(lst.Count + " ");
        
        for (int i = 0; i < 5; i++)
            lst.PushBack((char)(i + 97));
        
        l.print_lst(lst);
    }
}