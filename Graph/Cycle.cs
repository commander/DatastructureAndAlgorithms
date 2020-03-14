using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    public class Cycle
    {
        private bool[] marked
        {
            get;
            set;
        }

        public bool HasCycle
        {
            get;
            private set;
        }

        public Cycle(Graph g)
        {
            this.marked = new bool[g.V];
            for(int s = 0; s < g.V; s++)
            {
                if (!marked[s])
                {
                    this.Dfs(g, s, s);
                }
            }
        }

        private void Dfs(Graph g, int v, int u)
        {
            this.marked[v] = true;
            foreach(int w in g.GetAdjacencyList(v))
            {
                if (!marked[w])
                {
                    this.Dfs(g, w, v);
                }
                else if(w != u)
                {
                    this.HasCycle = true;
                }
            }
        }
    }
}
