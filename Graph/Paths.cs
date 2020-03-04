using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    public abstract class Paths
    {
        protected int[] edgeTo;
        protected Boolean[] marked;

        // source
        protected readonly int s;

        protected int Count
        {
            get;
            set;
        }
        public Paths(Graph g, int s)
        {
            this.s = s;
        }

        public virtual bool HasPathTo(int v)
        {
            return marked[v];
        }

        public virtual IEnumerable<int> PathTo(int v)
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

        public virtual bool Marked(int v)
        {
            return this.marked[v];
        }
    }
}
