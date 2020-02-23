using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    public class DepthFirstSearch
    {
        private Boolean[] marked;
        public int Count
        {
            get;
            private set;
        }

        public DepthFirstSearch(Graph g, int s)
        {
            this.marked = new bool[g.V];
            Dfs(g, s);
        }

        public bool Marked(int v)
        {
            return this.marked[v];
        }

        private void Dfs(Graph g, int s)
        {
            this.marked[s] = true;
            Count++;
            foreach(int v in g.GetAdjacencyList(s))
            {
                if (!marked[v])
                {
                    Dfs(g, v);
                }
            }
        }
    }
}
