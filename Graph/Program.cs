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
            //edges.Add(new int[] { 6, 7 });
            //edges.Add(new int[] { 1, 7 });
            edges.Add(new int[] { 7, 8 });
            edges.Add(new int[] { 9, 10 });
            edges.Add(new int[] { 9, 11 });
            edges.Add(new int[] { 9, 12 });
            edges.Add(new int[] { 11, 12 });
            edges.Add(new int[] { 0, 2 });

            int v = 13;
            Graph g = new Graph(v, edges);

            //for (int i = 0; i < v; i++)
            //{
            //    Console.WriteLine("Node {0} is connected to: ", i);

            //    foreach (int ve in g.GetAdjacencyList(i))
            //    {
            //        Console.WriteLine("  {0}", ve);
            //    }
            //}
            //Console.WriteLine();

            Console.WriteLine("Starting Depth first search.");
            int source = 6;
            DepthFirstSearch dfs = new DepthFirstSearch(g, source);
            Console.WriteLine("Dfs Count: {0}", dfs.Count);

            //Console.WriteLine("Starting Depth first search for path from {0} to 4.", source);

            Paths dfp = new DepthFirstPaths(g, source);
            PrintPaths(dfp, g, source);
            //IEnumerable<int> pathTo5 = dfp.PathTo(4);

            //if (pathTo5 != null)
            //{
            //    foreach (int i in pathTo5)
            //    {
            //        Console.WriteLine("To: {0}", i);
            //    }
            //}

            //for(int i = 0; i < dfp.Count; i++)
            //{
            //    Console.WriteLine("Does {2} connect to {1}: {0}", dfp.HashPathTo(i), i, source);
            //}
            Console.WriteLine("===========================================================");
            Console.WriteLine("================ Breath First Search for Paths ============");
            Console.WriteLine("===========================================================");

            BreathFirstPaths bfp = new BreathFirstPaths(g, source);
            PrintPaths(bfp, g, source);

            PrintConnectedComponents(g);
            //IEnumerable<int> breathPathTo5 = bfp.PathTo(4);

            //if (breathPathTo5 != null)
            //{
            //    foreach (int i in breathPathTo5)
            //    {
            //        Console.WriteLine("To: {0}", i);
            //    }
            //}

            // Does G has cycles
            Cycle c = new Cycle(g);
            Console.WriteLine("Has Cycle {0}", c.HasCycle);

            // Is the graph BiPartie
            TwoColor tw = new TwoColor(g);
            Console.WriteLine("Graph is {0}", tw.IsBiPartie ? "BiPartie" : "not BiPartie");
        }

        static void PrintPaths(Paths search, Graph g, int source)
        {
            for (int v = 0; v < g.V; v++)
            {
                Console.WriteLine(source + " to " + v + ": ");
                if (search.HasPathTo(v))
                {
                    foreach (int x in search.PathTo(v))
                    {
                        if (x == source)
                        {
                            Console.Write(x);
                        }
                        else
                        {
                            Console.Write("-" + x);
                        }
                    }
                }
                Console.WriteLine();
            }
        }

        static void PrintConnectedComponents(Graph g)
        {
            ConnectedComponent cc = new ConnectedComponent(g);
            int m = cc.Count;

            Console.WriteLine("{0} Components.", m);

            Queue<int>[] components = new Queue<int>[m];

            for(int i = 0; i < m; i++)
            {
                components[i] = new Queue<int>();
            }

            for(int v = 0; v < g.V; v++)
            {
                components[cc.Id(v)].Enqueue(v);
            }

            for(int i = 0; i < m; i++)
            {
                foreach(int v in components[i])
                {
                    Console.Write(v + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
