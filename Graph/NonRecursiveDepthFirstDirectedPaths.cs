using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    public class NonRecursiveDepthFirstDirectedPaths : DirectedPaths
    {
        public NonRecursiveDepthFirstDirectedPaths(Digraph g, int s) : base(g, s)
        {
            this.marked = new bool[g.V];
            this.edgeTo = new int[g.V];
            Dfs(g, s);
        }

        private void Dfs(Digraph g, int s)
        {
            this.marked[s] = true;
            var adjEnumerators = new IEnumerator<int>[g.V];

            for (int v = 0; v < g.V; v++)
            {
                adjEnumerators[v] = g.GetAdjacencyList(v).GetEnumerator();
            }

            Stack<int> stack = new Stack<int>();

            stack.Push(s);

            while (stack.Count != 0)
            {
                int current = stack.Peek();

                if (adjEnumerators[current].MoveNext())
                {
                    int w = adjEnumerators[current].Current;

                    if (!this.marked[w])
                    {
                        this.marked[w] = true;
                        this.edgeTo[w] = current;
                        stack.Push(w);
                    }
                }
                else
                {
                    stack.Pop();
                }
            }
        }

        public static void Main(string[] args)
        {
            string fileName = args[0];

            var vAndE = FileReader.Read(fileName);

            Digraph dg = new Digraph(vAndE.Item1, vAndE.Item2);

            int s = int.Parse(args[1]);

            var ddfp = new NonRecursiveDepthFirstDirectedPaths(dg, s);

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
