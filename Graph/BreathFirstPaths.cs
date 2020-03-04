using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    class BreathFirstPaths : Paths
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

        public BreathFirstPaths(Graph g, int s) : base (g, s)
        {
            this.marked = new bool[g.V];
            this.edgeTo = new int[g.V];
            //this.s = s;
            Bfs(g, s);
        }

        public override bool HasPathTo(int v)
        {
            return marked[v];
        }

        public override IEnumerable<int> PathTo(int v)
        {
            if (!HasPathTo(v))
            {
                return null;
            }

            Stack<int> path = new Stack<int>();
            for (int x = v; x != this.s; x = edgeTo[x])
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

        private void Bfs(Graph g, int s)
        {
            Queue<int> queue = new Queue<int>();
            this.marked[s] = true;
            queue.Enqueue(s);
            while (queue.Count != 0)
            {
                int v = queue.Dequeue();
                foreach (int i in g.GetAdjacencyList(v))
                {
                    if (!marked[i])
                    {
                        edgeTo[i] = v;
                        marked[i] = true;
                        queue.Enqueue(i);
                    }
                }
            }
        }
    }
}
