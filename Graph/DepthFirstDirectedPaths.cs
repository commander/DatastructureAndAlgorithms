using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    public class DepthFirstDirectedPaths : DirectedPaths
    {
        public DepthFirstDirectedPaths(Digraph g, int s) : base(g, s)
        {
            this.marked = new bool[g.V];
            this.edgeTo = new int[g.V];
            Dfs(g, s);
        }

        private void Dfs(Digraph g, int s)
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

        public static void Main(string[] args)
        {
            string fileName = args[0];

            var vAndE = FileReader.Read(fileName);

            Digraph dg = new Digraph(vAndE.Item1, vAndE.Item2);

            int s = int.Parse(args[1]);

            DepthFirstDirectedPaths ddfp = new DepthFirstDirectedPaths(dg, s);

            for(int v = 0; v < dg.V; v++)
            {
                if (ddfp.HasPathTo(v))
                {
                    Console.Write($"{s} to {v}: ");

                    foreach(var x in ddfp.PathTo(v))
                    {
                        if(x == s)
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
