using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

public class HelloWorld
{
    public class Node
    {
        private int val;
        private Node left;
        private Node right;

        public int height;

        public Node(int value)
        {
            val = value;
        }

        public int Key { get { return val; } set { val = value; } }
        public int Height { get { return height; } set { height = value; } }
        public Node Left { get { return left; } set { left = value; } }
        public Node Right { get { return right; } set { right = value; } }

    }
    public class BTree
    {
        public Node root;
        public BTree() { }

        private int height(Node N)
        {
            return N == null ? 0 : N.Height;
        }
        public int height()
        {
            return root == null ? 0 : 1 +
            Math.Max(height(root.Left), height(root.Right));
        }
        public int getBalance(Node N)
        {
            if (N == null)
                return 0;
            return height(N.Left) - height(N.Right);
        }

        public void Insert(int x)
        {
            root = insert(root, x);
        }
        private Node insert(Node n, int x)
        {
            if (n == null)
                return new Node(x);

            if (x < n.Key)
                n.Left = insert(n.Left, x);
            else
                n.Right = insert(n.Right, x);

            n.Height = 1 + Math.Max(height(n.Left), height(n.Right));

            int balance = getBalance(n);

            // Left Left Case
            if (balance > 1 && x < n.Left.Key)
                return rightRotate(n);

            // Right Right Case
            if (balance < -1 && x > n.Right.Key)
                return leftRotate(n);

            // Left Right Case
            if (balance > 1 && x > n.Left.Key)
            {
                n.Left = leftRotate(n.Left);
                return rightRotate(n);
            }

            // Right Left Case
            if (balance < -1 && x < n.Right.Key)
            {
                n.Right = rightRotate(n.Right);
                return leftRotate(n);
            }

            return n;
        }

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

        public Node rotate_right(Node rt)
        {
            Node pivot = rt.Left;
            rt.Left = pivot.Right;
            pivot.Right = rt;
            return pivot;
        }

        private Node rightRotate(Node y)
        {
            var x = y.Left;
            var T2 = x.Right;

            // Perform rotation
            x.Right = y;
            y.Left = T2;

            // Update heights
            y.Height = Math.Max(height(y.Left), height(y.Right)) + 1;
            x.Height = Math.Max(height(x.Left), height(x.Right)) + 1;

            // Return new root
            return x;
        }

        public Node rotate_left(Node rt)
        {
            Node pivot = rt.Right;
            rt.Right = pivot.Left;
            pivot.Left = rt;
            return pivot;
        }

        private Node leftRotate(Node x)
        {
            var y = x.Right;
            var T2 = y.Left;

            // Perform rotation
            y.Left = x;
            x.Right = T2;

            //  Update heights
            x.Height = Math.Max(height(x.Left), height(x.Right)) + 1;
            y.Height = Math.Max(height(y.Left), height(y.Right)) + 1;

            // Return new root
            return y;
        }

        public Node BigRotateRight(Node a)//большой правый поворот вокруг узла parent
        {
            var piv = a.Left;//делаем копию левого потомка
            a.Left = rotate_left(piv);//сначала делается левый поворот вокруг левого потомка
            return rotate_right(a);//потом правый поворот вокруг нужного узла
        }

        public Node BigRotateLeft(Node a)//большой левый поворот вокруг узла parent
        {
            var piv = a.Right;//делаем копию првого потомка
            a.Right = rotate_right(piv); //сначала делается правый поворот вокруг правого правого потомка
            return rotate_left(a);//потом левый поворот вокруг нужного узла
        }

    }
    public static void Main(string[] args)
    {
        // 5 2 7 1 3 6 8
        // 1 2 3 4 5 6 7
        int N = 10_000_000;
        var rnd = new System.Random(1);
        var init = Enumerable.Range(0, N).OrderBy(x => rnd.Next()).ToArray();

        var tree = new BTree();
        foreach (var obj in init)
            tree.Insert(obj);
        //Console.WriteLine(tree);
        Console.WriteLine(tree.height());

        /*var tree = new BTree();
		tree.Insert(5);
		tree.Insert(3);
		tree.Insert(7);
		tree.Insert(2);
		tree.Insert(4);
 
		//tree.Print();
		Console.WriteLine(tree);
		tree.root = tree.rotate_right(tree.root);
		Console.WriteLine(tree);
		tree.root = tree.rotate_left(tree.root);
		Console.WriteLine(tree);*/

        /*var tree = new BTree();
		tree.Insert(1);
		tree.Insert(0);
		tree.Insert(6);
		tree.Insert(4);
		tree.Insert(2);
		tree.Insert(5);
		tree.Insert(7);
 
		//tree.Print();
		Console.WriteLine(tree);
		Console.WriteLine(tree.root.Height);
		tree.root = tree.BigRotateLeft(tree.root);
		Console.WriteLine(tree);
		Console.WriteLine(tree.root.Height);*/
    }
}