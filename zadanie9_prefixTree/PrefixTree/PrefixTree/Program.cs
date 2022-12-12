using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrefixTree
{
    class Program
    {
        public class Trie
        {
            private TrieNode root;
            private int limit;

            public Trie()
            {
                limit = 256;
                root = new TrieNode('@', limit, -1, false);
            }

            public void Insert(string str, int _index)
            {
                if (!string.IsNullOrEmpty(str)) TraverseToInsert(str, _index, root);
            }

            private void TraverseToInsert(string str, int _index, TrieNode node)
            {
                int n = str.Length, m = n - 1;

                for (int i = 0; i < n; ++i)
                {
                    char _ch = str[i];
                    int j = (int)_ch;

                    if (node[j] == null) node[j] = new TrieNode(_ch, limit, _index, i == m);
     
                    node = node[j];
                }
            }

            public List<int> BackwardListingOfEntries()
            {
                List<int> indices = new List<int>();

                DescListNode(root, indices);

                return indices;
            }

            private void DescListNode(TrieNode node, List<int> indices)
            {
                if (node != null)
                {
                    if (node.Index != -1) indices.Add(node.Index);

                    for (int i = limit - 1; i >= 0; --i) DescListNode(node[i], indices);
                }
            }

            public List<int> SamePrefixWords(string prefix)
            {
                List<int> indices = new List<int>();

                if (!string.IsNullOrEmpty(prefix))
                {
                    TrieNode startNode;

                    startNode = TraverseStr(prefix, root);
                    if (startNode != null) CollectAll(startNode, indices);
                }
                return indices;
            }

            private TrieNode TraverseStr(string prefix, TrieNode startNode)
            {
                TrieNode node = startNode;

                for (int i = 0; i < prefix.Length; ++i)
                {
                    char _ch = prefix[i];
                    int j = (int)_ch;

                    if (node[j] != null) node = node[j];

                    else
                    {
                        node = null;
                        break;
                    }
                }
                return node;
            }

            private void CollectAll(TrieNode node, List<int> indices)
            {
                if (node != null)
                {
                    if (node.Index != -1) indices.Add(node.Index);
                  
                    for (int i = 0; i < limit; ++i) CollectAll(node[i], indices);
                }
            }
        }
        static void Main(string[] args)
        {
            Trie trie = new Trie();
            string[] words =
            {
                "are", "the", "they", "most", "fun", "and", "these", "are", "a", "fun"
            };

            for (int i = 0; i < words.Length; ++i) trie.Insert(words[i], i);

            List<int> indices = trie.BackwardListingOfEntries();
            //indices = trie.BackwardListingOfEntries();

            foreach (int i in indices) Console.WriteLine(words[i]);
            Console.WriteLine();

            indices = trie.SamePrefixWords("t");

            foreach (int i in indices) Console.WriteLine(words[i]);
        }
    }
}
