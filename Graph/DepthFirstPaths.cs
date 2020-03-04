using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    public class DepthFirstPaths : Paths
    {
        //private int[] edgeTo;
        //private Boolean[] marked;

        //// source
        //private readonly int s; 

        //public int Count
        //{
        //    get;
        //    private set;
        //}

        public DepthFirstPaths(Graph g, int s) : base(g, s)
        {
            this.marked = new bool[g.V];
            this.edgeTo = new int[g.V];
            Dfs(g, s);
        }

        //public override bool HasPathTo(int v)
        //{
        //    return marked[v];
        //}

        //public override IEnumerable<int> PathTo(int v)
        //{
        //    if(!HasPathTo(v))
        //    {
        //        return null;
        //    }

        //    Stack<int> path = new Stack<int>();
        //    for(int x = v; x != this.s; x = edgeTo[x])
        //    {
        //        path.Push(x);
        //    }

        //    path.Push(s);
        //    return path;
        //}

        //public bool Marked(int v)
        //{
        //    return this.marked[v];
        //}

        private void Dfs(Graph g, int s)
        {
            this.marked[s] = true;
            this.Count++;
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
