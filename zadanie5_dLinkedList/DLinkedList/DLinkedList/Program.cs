using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using DLinkedList;

public class DoublyNode<T>
{
    public T value { get; set; }
    public DoublyNode(T v)
    {
        value = v;
    }

    public DoublyNode<T>? Previous { get; set; }
    public DoublyNode<T>? Next { get; set; }
}

public class myDLinkedList<T> : IEnumerable<T>
{
    public DoublyNode<T>? head;
    public DoublyNode<T>? tail;
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
        int indexN = index - 1;

        if (count > index)
        {
            DoublyNode<T>? curEl = head;
            DoublyNode<T>? curT = tail;

            /*if (index == 0)
            {
                newEl.Next = curEl;
                head = newEl;
                curEl.Previous = newEl;
                count++;
            }*/

            if /*(index > 0 && index < count)*/(index < count)
            {
                if (index < count / 2)
                {
                    for (int i = 0; i < indexN; i++)
                        if (curEl != null)
                            curEl = curEl.Next;

                    newEl.Next = curEl.Next;
                    newEl.Previous = curEl;
                    curEl.Next = newEl;
                    newEl.Next.Previous = newEl;
                }

                else
                {
                    for (int i = 0; i < count - indexN - 1; i++)
                        if (curT != null)
                            curT = curT.Next;

                    newEl.Next = curT.Next;
                    newEl.Previous = curT;
                    curT.Next = newEl;
                    newEl.Next.Previous = newEl;
                }

                count++;
            }

            //else Add(item);
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable)this).GetEnumerator();
    }

    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    {
        DoublyNode<T>? curEl = head;

        while (curEl != null)
        {
            yield return curEl.value;
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
        myLinkedList<int> lst = new myLinkedList<int>();

        int N = 200;
        var rnd = new Random(1);

        for (int i = 0; i != N; i++) lst.PushBack(i);

        System.Diagnostics.Stopwatch watch;
        long elapsedMs;
        watch = System.Diagnostics.Stopwatch.StartNew();

        for (int i = 0; i != N; i++) lst.Insert(rnd.Next(0, lst.Count - 2), 5);
        watch.Stop();
        elapsedMs = watch.ElapsedMilliseconds;
        Console.WriteLine(lst.Count);
        System.Console.WriteLine("List Oper <Insert> time (msec): " + Convert.ToDouble(elapsedMs) / 1000); 



        var dlst = new myDLinkedList<int>();

        for (int i = 0; i != N; i++) dlst.Add(i);

        watch = System.Diagnostics.Stopwatch.StartNew();

        for (int i = 0; i != N; i++) dlst.Insert(rnd.Next(0, dlst.Count - 2), 5);
        watch.Stop();
        elapsedMs = watch.ElapsedMilliseconds;
        Console.WriteLine(dlst.Count);
        System.Console.WriteLine("DList Oper <Insert> time (msec): " + Convert.ToDouble(elapsedMs) / 1000);
    }
}