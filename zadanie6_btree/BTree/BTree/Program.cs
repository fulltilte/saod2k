using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace saod_5
{
    class Program
    {
        public class Node
        {
            private int val;
            private Node left;
            private Node right;

            public Node(int value) { val = value; }

            public int Key { get { return val; } set { val = value; } }
            public Node Left { get { return left; } set { left = value; } }
            public Node Right { get { return right; } set { right = value; } }
        }

        public class BTree
        {
            public Node root;
            public BTree() { }
            public int count = 0;

            public void Insert(int x)
            {
                if (root == null)
                {
                    root = new Node(x);
                    count++;
                }

                else
                {
                    insert(root, x);
                    count++;
                }
            }

            public int Count
            {
                get { return count; }
            }

            private void insert(Node n, int x)
            {
                if (x < n.Key)
                {
                    if (n.Left != null)
                    {
                        insert(n.Left, x);
                    }

                    else
                    {
                        n.Left = new Node(x);
                    }
                }

                else
                {
                    if (n.Right != null)
                    {
                        insert(n.Right, x);
                    }

                    else
                    {
                        n.Right = new Node(x);
                    }
                }
            }

            public bool Contains(int item)
            {

                if (root.Key == item) return true;
                if (root.Key > item)
                    return Contains(item, root.Left);

                return Contains(item, root.Right);
            }

            public bool Contains(int item, Node n)
            {
                if (n == null) return false;

                if (n.Key == item) return true;
                if (n.Key > item)
                    return Contains(item, n.Left);

                return Contains(item, n.Right);
            }

            public Node rotate_right(Node rt)
            {
                Node pivot = rt.Left;
                rt.Left = pivot.Right;
                pivot.Right = rt;
                return pivot;
            }

            public Node rotate_left(Node rt)
            {
                Node pivot = rt.Right;
                rt.Right = pivot.Left;
                pivot.Left = rt;
                return pivot;
            }

            //public void Print()
            //{
            //    if (root != null)
            //        print(root, 0);
            //}

            //private void print(Node n, int shift)
            //{
            //    if (n.Right != null)
            //        print(n.Right, shift + 1);
            //    for (int i = 0; i < shift * 2; i++)
            //        Console.Write(" ");
            //    Console.WriteLine(n.Key);
            //    if (n.Left != null)
            //        print(n.Left, shift + 1);
            //}

            private KeyValuePair<int, string> ToStringHelper(Node n)
            {
                if (n == null)
                    return new KeyValuePair<int, string>(1, "\n");

                var left = ToStringHelper(n.Left);
                var right = ToStringHelper(n.Right);

                var objString = n.Key.ToString();
                var stringBuilder = new StringBuilder();

                stringBuilder.Append(' ', left.Key - 1);
                stringBuilder.Append(objString);
                stringBuilder.Append(' ', right.Key - 1);
                stringBuilder.Append('\n');

                var i = 0;

                while (i * left.Key < left.Value.Length && i * right.Key < right.Value.Length)
                {
                    stringBuilder.Append(left.Value, i * left.Key, left.Key - 1);
                    stringBuilder.Append(' ', objString.Length);
                    stringBuilder.Append(right.Value, i * right.Key, right.Key);
                    ++i;
                }

                while (i * left.Key < left.Value.Length)
                {
                    stringBuilder.Append(left.Value, i * left.Key, left.Key - 1);
                    stringBuilder.Append(' ', objString.Length + right.Key - 1);
                    stringBuilder.Append('\n');

                    ++i;
                }

                while (i * right.Key < right.Value.Length)
                {
                    stringBuilder.Append(' ', left.Key + objString.Length - 1);
                    stringBuilder.Append(right.Value, i * right.Key, right.Key);
                    ++i;
                }
                return new KeyValuePair<int, string>(left.Key + objString.Length + right.Key - 1, stringBuilder.ToString());
            }

            override public string ToString()
            {
                var res = ToStringHelper(root).Value;
                return res;
            }
        }

        static void Main(string[] args)
        {
            var rnd = new System.Random(1);
            var init = Enumerable.Range(0, 20).OrderBy(x => rnd.Next()).ToArray();

            var tree = new BTree();
            /*foreach (var obj in init)
                tree.Insert(obj);*/

            tree.Insert(5);
            tree.Insert(3);
            tree.Insert(7);
            tree.Insert(2);
            tree.Insert(4);
            

            //tree.Print();

            Console.WriteLine(tree);

            Console.WriteLine(tree.Contains(15));

            tree.root = tree.rotate_right(tree.root);
            Console.WriteLine(tree);

            tree.root = tree.rotate_left(tree.root);
            Console.WriteLine(tree);
        }
    }
}