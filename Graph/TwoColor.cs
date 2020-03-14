using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    public class TwoColor
    {
        private bool[] marked;
        private bool[] color;
        
        public bool IsBiPartie
        {
            get;
            private set;
        } = true;

        public TwoColor(Graph g)
        {
            this.marked = new bool[g.V];
            this.color = new bool[g.V];

            for(int s = 0; s < g.V; s++)
            {
                if (!this.marked[s])
                {
                    this.Dfs(g, s);
                }
            }
        }

        private void Dfs(Graph g, int v)
        {
            this.marked[v] = true;
            foreach(int w in g.GetAdjacencyList(v))
            {
                if (!this.marked[w])
                {
                    color[w] = !color[v];
                    this.Dfs(g, w);
                }
                else if(color[w] == color[v])
                {
                    this.IsBiPartie = false;
                }
            }
        }
    }
}
