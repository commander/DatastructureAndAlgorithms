using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    class DirectedCycle
    {
        private bool[] marked
        {
            get;
            set;
        }

        private int[] edgeTo
        {
            get;
            set;
        }

        // vertices on cycle - if exists.
        private Stack<int> cycle;

        // vertices on recursive call stacks
        private bool[] onStack;

        public DirectedCycle(Digraph g)
        {
            this.onStack = new bool[g.V];
            this.edgeTo = new int[g.V];
            this.marked = new bool[g.V];

            for(int v = 0; v < g.V; v++)
            {
                if (!this.marked[v])
                {
                    this.Dfs(g, v);
                }
            }
        }

        public bool HasCycle
        {
            get
            {
                return this.cycle != null;
            }
        }

        public IEnumerable<int> Cycle
        {
            get
            {
                return this.cycle;
            }
        }

        private void Dfs(Digraph g, int v)
        {
            this.onStack[v] = true;
            this.marked[v] = true;
            
            foreach(int w in g.GetAdjacencyList(v))
            {
                if (this.HasCycle)
                {
                    return;
                }
                else if (!this.marked[w])
                {
                    this.edgeTo[w] = v;
                    this.Dfs(g, w);
                }
                else if (onStack[w])
                {
                    this.cycle = new Stack<int>();
                    for(int x = v; x != w; x = edgeTo[x])
                    {
                        this.cycle.Push(x);
                    }
                    this.cycle.Push(w);
                    this.cycle.Push(v);
                }
                onStack[v] = false;
            }
        }
    }
}
