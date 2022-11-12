using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

public class DoublyNode<T>
{
    public DoublyNode(T value)
    {
        Value = value;
    }

    public T Value { get; set; }
    public DoublyNode<T> Next { get; set; }
    public DoublyNode<T> Previous { get; set; }
}

public class myDLinkedList<T> : IEnumerable<T>
{
    private DoublyNode<T> head;
    private DoublyNode<T> tail;
    private int count;

    public int Count { get { return count; } }

    public myDLinkedList() { count = 0; }

    public void Add(T item)
    {
        DoublyNode<T> newEl = new DoublyNode<T>(item);

        if (head == null)
            head = newEl;

        else
        {
            if (tail != null)
            {
                tail.Next = newEl;
                newEl.Previous = tail;
            }   
        }

        tail = newEl;
        count++;
    }

    public void Insert(int index, T item)
    {
        DoublyNode<T> newEl = new (item);

        if (count >= index)
        {
            DoublyNode<T> curEl = head;
            DoublyNode<T> curT = tail;

            if (index == 0)
            {
                newEl.Next = curEl;
                head = newEl;
                curEl.Previous = newEl;
                count++;
            }

            else if (index > 0 && index < count)
            {
                for (int i = 0; i < index - 1; i++)
                    if (curEl.Next.Next != null)
                        curEl = curEl.Next;

                newEl.Next = curEl.Next;
                newEl.Previous = curEl;
                curEl.Next = newEl;
                newEl.Next.Previous = newEl;
                count++;
            }

            else Add(item);
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable)this).GetEnumerator();
    }

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
        DoublyNode<T> curEl = head;

        while (curEl != null)
        {
            yield return curEl.Value;
            curEl = curEl.Next;
        }
    }
}

class Program
{
    public static void print_lst(myDLinkedList<char> l)
    {
        foreach (var item in l)
            Console.Write(item + " ");

        Console.WriteLine();
    }

    static void Main(string[] args)
    {
        var lst = new myDLinkedList<char>();

        lst.Add('a');
        lst.Add('b');
        lst.Add('c');
        lst.Add('d');
        lst.Add('e');
        lst.Add('f');
        lst.Add('g');
        lst.Add('i');

        System.Diagnostics.Stopwatch watch;
        long elapsedMs;

        watch = System.Diagnostics.Stopwatch.StartNew();
        int N = 1000000;
        var stack = new System.Collections.Generic.Stack<int>();

        for (int i = 0; i != N; i++) stack.Push(i);

        for (int i = 0; i != N; i++) stack.Pop();

        lst.Insert(6, 'x');

        watch.Stop();
        elapsedMs = watch.ElapsedMilliseconds;

        System.Console.WriteLine("Oper <Insert> time (msec): " + Convert.ToDouble(elapsedMs) / 1000);

        print_lst(lst);
    }
}