using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    public class DepthFirstPaths
    {
        private int[] edgeTo;
        private Boolean[] marked;

        // source
        private readonly int s; 

        public int Count
        {
            get;
            private set;
        }

        public DepthFirstPaths(Graph g, int s)
        {
            this.marked = new bool[g.V];
            this.edgeTo = new int[g.V];
            this.s = s;
            Dfs(g, s);
        }

        public bool HashPathTo(int v)
        {
            return marked[v];
        }

        public IEnumerable<int> PathTo(int v)
        {
            if(!HashPathTo(v))
            {
                return null;
            }

            Stack<int> path = new Stack<int>();
            for(int x = v; x != this.s; x = edgeTo[x])
            {
                path.Push(x);
            }

            path.Push(s);
            return path;
        }

        public bool Marked(int v)
        {
            return this.marked[v];
        }

        private void Dfs(Graph g, int s)
        {
            this.marked[s] = true;
            Count++;
            foreach (int v in g.GetAdjacencyList(s))
            {
                if (!marked[v])
                {
                    edgeTo[v] = s;
                    Dfs(g, v);
                }
            }
        }
    }

}
