using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrefixTree
{
    public class TrieNode
    {
        private char ch;
        private int limit, index;
        private TrieNode[] childs;

        public TrieNode(char _ch, int _limit, int _index, bool endOfString)
        {
            ch = _ch;
            limit = _limit;

            childs = new TrieNode[limit];

            for (int i = 0; i < limit; ++i) childs[i] = null;

            index = endOfString ? _index : -1;
        }

        public char Ch { get { return ch; } }

        public int Limit { get { return limit; } }

        public int Index { get { return index; } }

        public TrieNode this[int i]
        {
            get
            {
                if (0 <= i && i < limit) return childs[i];
                else return null;
            }

            set
            {
                if (0 <= i && i < limit) childs[i] = value;
            }
        }
    }
}
