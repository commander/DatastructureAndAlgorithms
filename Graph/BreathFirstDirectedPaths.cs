using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    class BreathFirstDirectedPaths : DirectedPaths
    {
        private int[] distTo;

        public BreathFirstDirectedPaths(Digraph g, int s) : base (g, s)
        {
            this.marked = new bool[g.V];
            this.edgeTo = new int[g.V];
            this.distTo = new int[g.V];

            for(int i = 0; i < g.V; i++)
            {
                this.distTo[i] = int.MaxValue;
            }

            //this.s = s;
            Bfs(g, s);
        }

        public override bool HasPathTo(int v)
        {
            return marked[v];
        }

        public int DistanceTo(int v)
        {
            return this.distTo[v];
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

        private void Bfs(Digraph g, int s)
        {
            Queue<int> queue = new Queue<int>();
            this.marked[s] = true;
            this.distTo[s] = 0;
            queue.Enqueue(s);
            while (queue.Count != 0)
            {
                int v = queue.Dequeue();
                foreach (int i in g.GetAdjacencyList(v))
                {
                    if (!marked[i])
                    {
                        this.edgeTo[i] = v;
                        this.marked[i] = true;
                        this.distTo[i] = this.distTo[v] + 1;
                        queue.Enqueue(i);
                    }
                }
            }
        }

        public static void Main(string[] args)
        {
            string fileName = args[0];

            var vAndE = FileReader.Read(fileName);

            Digraph dg = new Digraph(vAndE.Item1, vAndE.Item2);

            int s = int.Parse(args[1]);

            BreathFirstDirectedPaths bfdp = new BreathFirstDirectedPaths(dg, s);

            for (int v = 0; v < dg.V; v++)
            {
                if (bfdp.HasPathTo(v))
                {
                    Console.Write($"{s} to {v} ({bfdp.DistanceTo(v)}): ");

                    foreach (var x in bfdp.PathTo(v))
                    {
                        if (x == s)
                        {
                            Console.Write($"-> {s}");
                        }
                        else
                        {
                            Console.Write($"-> {x}");
                        }
                    }
                }
                else
                {
                    Console.Write($"{s} to {v}: not connected.");
                }
                Console.WriteLine();
            }
        }
    }
}
