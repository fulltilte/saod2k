using System;
using System.Runtime;
using System.Runtime.Versioning;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Collections.ObjectModel;
using System.Security.Permissions;


Ex ex = new Ex();
ex.Main();

public class Node<T>
{
    public Node(T data)
    {
        Data = data;
        Next = null;
    }

    public Node()
    {
        Next = null;
    }

    public T Data { get; set; }
    public Node<T> Next { get; set; }

    public override string ToString()
    {
        return Data.ToString();
    }
}

public class LinkedList<T> : IEnumerable<T>
{
    private Node<T> root; //первый элемент
    private Node<T> sentinel; //последний элемент
    int count;

    public LinkedList()
    {
        root = new Node<T>();
        sentinel = root;
    }

    public bool Empty(LinkedList<T> lst)
    {
        if (lst.Count == 0) return true;
        else return false;
    }

    public void PushBack(T data)
    {
        Node<T> node = new Node<T>(data);
        if (count == 0)
        {
            root = node;
            node.Next = sentinel;
        }

        count++;
    }

    public void PustFront(T data)
    {
        Node<T> node = new Node<T>(data);

    }

    public int Count { get { return count; } }

    public IEnumerator<T> GetEnumerator()
    {
        var current = root;
        while (current != null)
        {
            yield return current.Data;
            current = current.Next;
        }
    }

    IEnumerator<T> IEnumerable<T>.GetEnumerator() { return GetEnumerator(); }
}





public class Ex
{

    public void print_lst(LinkedList<char> l)
    {
        foreach (var item in l)
        {
            Console.Write(item);
        }
    }
    public void Main()
    {
        var lst = new LinkedList<char>(); // ваш список
                                          //lst.PushBack('s');
        //Console.WriteLine(lst.Count + " " + lst.Empty(lst));

        for (int i = 0; i < 5; i++)
            lst.PushBack((char)(i + 97));



        print_lst(lst);
    }
}
