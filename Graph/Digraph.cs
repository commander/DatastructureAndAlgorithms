using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Graph
{
    public class Digraph
    {
        public int V
        {
            get;
            private set;
        }

        public int E
        {
            get;
            private set;
        }

        private HashSet<int>[] adjacencyLists;

        public Digraph(int v)
        {
            this.V = v;
            this.E = 0;
            this.adjacencyLists = new HashSet<int>[V];
            for(int i = 0; i < this.V; i++)
            {
                this.adjacencyLists[i] = new HashSet<int>();
            }
        }

        public Digraph(int v, List<int[]> edges) : this(v)
        {
            this.E = edges.Count;

            foreach (int[] edge in edges)
            {
                AddEdge(edge[0], edge[1]);
            }
        }

        public IEnumerable<int> GetAdjacencyList(int v)
        {
            return this.adjacencyLists[v];
        }

        public void AddEdge(int from, int to)
        {
            if(this.adjacencyLists[from] == null)
            {
                this.adjacencyLists[from] = new HashSet<int>();
            }

            this.adjacencyLists[from].Add(to);
        }

        public Digraph Reverse()
        {
            Digraph r = new Digraph(this.V);
            for(int v = 0; v < this.V; v++)
            {
                foreach(int w in this.GetAdjacencyList(v))
                {
                    r.AddEdge(w, v);
                }
            }

            return r;
        }
    }
}
