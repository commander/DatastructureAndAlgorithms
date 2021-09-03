using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    public class BreathFirstSearch  
    {
        private Boolean[] marked;
        public int Count
        {
            get;
            private set;
        }

        public BreathFirstSearch(Graph g, int s)
        {
            this.marked = new bool[g.V];
            Bfs(g, s);
        }

        public bool Marked(int v)
        {
            return this.marked[v];
        }

        private void Bfs(Graph g, int s)
        {
            Queue<int> queue = new Queue<int>();
            Console.Write($"|{s}|->");
            this.marked[s] = true;
            queue.Enqueue(s);
            Count++;
            while(queue.Count != 0)
            {
                int v = queue.Dequeue();
                foreach (int i in g.GetAdjacencyList(v))
                {
                    if (!marked[i])
                    {
                        Console.Write($"|{i}|->");
                        marked[i] = true;
                        Count++;
                        queue.Enqueue(i);
                    }
                }
            }
            Console.WriteLine($"|Null|");
        }
    }
}
