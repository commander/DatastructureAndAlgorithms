using System;
using System.Collections.Generic;

namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int[]> edges = new List<int[]>();

            edges.Add(new int[] { 0, 5});
            edges.Add(new int[] { 2, 4});
            edges.Add(new int[] { 2, 3 });
            edges.Add(new int[] { 1, 2 });
            edges.Add(new int[] { 0, 1 });
            edges.Add(new int[] { 3, 4 });
            edges.Add(new int[] { 3, 5 });
            edges.Add(new int[] { 0, 2 });
            edges.Add(new int[] { 6, 7 });
            edges.Add(new int[] { 1, 7 });

            int v = 8;
            Graph g = new Graph(v, edges);

            for (int i = 0; i < v; i++)
            {
                Console.WriteLine("Node {0} is connected to: ", i);

                foreach (int ve in g.GetAdjacencyList(i))
                {
                    Console.WriteLine("  {0}", ve);
                }
            }
            Console.WriteLine();

            Console.WriteLine("Starting Depth first search.");

            DepthFirstSearch dfs = new DepthFirstSearch(g, 1);
            Console.WriteLine("Dfs Count: {0}", dfs.Count);

            Console.WriteLine("Starting Depth first search for path from 0 to 4.");

            DepthFirstPaths dfp = new DepthFirstPaths(g, 0);
            IEnumerable<int> pathTo5 = dfp.PathTo(4);

            foreach(int i in pathTo5)
            {
                Console.WriteLine("To: {0}", i);
            }
        }
    }
}
