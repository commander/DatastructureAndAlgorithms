using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Graph
{
    public class NonRecursiveDirectedDepthFirstSearch
    {
        private Boolean[] marked;

        public NonRecursiveDirectedDepthFirstSearch(Digraph g, int s)
        {
            this.marked = new bool[g.V];
            Dfs(g, s);
        }

        public NonRecursiveDirectedDepthFirstSearch(Digraph g, List<int> sources)
        {
            this.marked = new bool[g.V];
            foreach(int s in sources)
            {
                if (!marked[s])
                {
                    Dfs(g, s);
                }
            }
            
        }

        public bool Marked(int v)
        {
            return this.marked[v];
        }

        private void Dfs(Digraph g, int s)
        {
            this.marked[s] = true;
            var adjEnumerators = new IEnumerator<int>[g.V];

            for(int v = 0; v < g.V; v++)
            {
                adjEnumerators[v] = g.GetAdjacencyList(v).GetEnumerator();
            }

            Stack<int> stack = new Stack<int>();

            marked[s] = true;
            stack.Push(s);

            while(stack.Count != 0)
            {
                int current = stack.Peek();

                if(adjEnumerators[current].MoveNext())
                {
                    int w = adjEnumerators[current].Current;

                    if (!marked[w])
                    {
                        marked[w] = true;
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

            List<int> sources = new List<int>();

            for(int i = 1; i < args.Length; i++)
            {
                sources.Add(int.Parse(args[i]));
            }

            NonRecursiveDirectedDepthFirstSearch ddfs = new NonRecursiveDirectedDepthFirstSearch(dg, sources);
            for(int ve = 0; ve < dg.V; ve++)
            {
                if (ddfs.Marked(ve))
                {
                    Console.Write(ve + " ");
                }
            }
            Console.WriteLine();
        }
    }
}
