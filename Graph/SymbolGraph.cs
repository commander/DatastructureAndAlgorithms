using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    public class SymbolGraph
    {
        private Dictionary<string, int> st;
        private string[] keys;
        public Graph Graph
        {
            get;
            private set;
        }

        public SymbolGraph(string[] lines, string sp)
        {
            this.st = new Dictionary<string, int>();
            foreach(string line in lines)
            {
                string[] words = line.Split(' ');
                for(int i = 0; i < words.Length; i++)
                {
                    if(!st.ContainsKey(words[i]))
                    {
                        st.Add(words[i], st.Count);
                    }
                }
            }

            this.keys = new string[st.Count];
            foreach (var v in st)
            {
                this.keys[v.Value] = v.Key;
            }

            this.Graph = new Graph(st.Count);

            foreach (string line in lines)
            {
                string[] words = line.Split(' ');
                int v = st[words[0]];

                for(int i = 1; i < words.Length; i++)
                {
                    this.Graph.AddEdge(v, st[words[i]]);
                }
            }
        }

        public bool Contains(string s)
        {
            return st.ContainsKey(s);
        }

        public int IndexOf(string s)
        {
            return st[s];
        }

        public string NameOf(int v)
        {
            return keys[v];
        }
    }
}
