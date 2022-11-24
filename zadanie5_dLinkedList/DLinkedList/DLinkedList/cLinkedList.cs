using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLinkedList
{
    
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

            public void Insert(int index, T value)
            {
                Node<T> curEl = root;
                Node<T> newEl = new(value);

                if (count >= index)
                {
                    if (index == 0) PushFront(value);

                    else if (index > 0 && index < count)
                    {
                        for (int i = 0; i < index - 1; i++)
                            if (curEl.Next.Next != sentinel)
                                curEl = curEl.Next;

                        newEl.Next = curEl.Next;
                        curEl.Next = newEl;
                        count++;
                    }

                    else PushBack(value);
                }
            }

            public void PopBack()
            {
                Node<T> curEl = root;

                if (count > 0)
                {
                    while ((curEl.Next).Next != sentinel)
                        curEl = curEl.Next;

                    curEl.Next = sentinel;
                    count--;
                }
            }

            public void PopFront()
            {
                if (count > 0)
                {
                    root = root.Next;
                    count--;
                }
            }

            public void RemoveAt(int index)
            {
                Node<T> curEl = root;

                if (count >= index)
                {
                    if (index == 0) PopFront();

                    else if (index > 0 && index < count)
                    {
                        for (int i = 0; i < index - 1; i++)
                            if (curEl.Next.Next != sentinel)
                                curEl = curEl.Next;

                        curEl.Next = curEl.Next.Next;
                        count--;
                    }

                    else PopBack();
                }
            }

            public bool Empty()
            {
                if (count != 0) return false;
                return true;
            }

            public void Clear()
            {
                root = sentinel;
                count = 0;
            }

            public T First() { return root.Value; }

            public T Last()
            {
                Node<T> curEl = root;

                while (curEl.Next != sentinel)
                    curEl = curEl.Next;

                return curEl.Value;
            }

            public T GetValue(int index)
            {

                var cur = root;

                for (int i = 0; i < index; i++)
                    cur = cur.Next;

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
                        node = node.Next;

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
    
}
