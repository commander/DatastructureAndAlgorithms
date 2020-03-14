using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    public class ConnectedComponent
    {
        private bool[] marked;
        private int[] id;
        public int Count
        {
            get;
            private set;
        }

        public ConnectedComponent(Graph g)
        {
            this.marked = new bool[g.V];
            this.id = new int[g.V];

            for(int s = 0; s < g.V; s++)
            {
                if(!this.marked[s])
                {
                    this.Dfs(g, s);
                    this.Count++;
                }
            }
        }

        public bool IsConnected(int v, int w)
        {
            return this.id[v] == this.id[w];
        }


        public int Id(int v)
        {
            return this.id[v];
        }

        private void Dfs(Graph g, int source)
        {
            marked[source] = true;
            id[source] = this.Count;

            foreach(int w in g.GetAdjacencyList(source))
            {
                if(!marked[w])
                {
                    Dfs(g, w);
                }
            }
        }
    }
}
