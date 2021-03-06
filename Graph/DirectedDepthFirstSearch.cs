﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Graph
{
    public class DirectedDepthFirstSearch
    {
        private Boolean[] marked;

        public DirectedDepthFirstSearch(Digraph g, int s)
        {
            this.marked = new bool[g.V];
            Dfs(g, s);
        }

        public DirectedDepthFirstSearch(Digraph g, List<int> sources)
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

            foreach(int v in g.GetAdjacencyList(s))
            {
                if (!marked[v])
                {
                    Dfs(g, v);
                }
            }
        }

        public static void Main(string[] args)
        {
            string fileName = args[0];
            string[] lines = File.ReadAllLines(fileName);

            int v = int.Parse(lines[0].Trim());
            int e = int.Parse(lines[1].Trim());

            List<int[]> edges = new List<int[]>();

            for (int i = 2; i < lines.Length; i++)
            {
                string[] points = lines[i].Trim().Split(' ');
                edges.Add(new int[] { int.Parse(points[0].Trim()), int.Parse(points[1].Trim()) });
            }

            //List<int[]> edges = new List<int[]>();
            //int vCount;
            //int eCount;
            //FileStream fs = File.OpenRead(fileName);
            //using (BinaryReader bs = new BinaryReader(fs))
            //{

            //    vCount = bs.ReadInt32();
            //    eCount = bs.ReadInt32();

            //    edges = new List<int[]>();

            //    for (int i = 0; i < eCount; i++)
            //    {
            //        int v = bs.ReadInt32();
            //        int w = bs.ReadInt32();
            //        //string[] points = lines[i].Trim().Replace("  ", " ").Split(' ');
            //        //edges.Add(new int[] { int.Parse(points[0].Trim()), int.Parse(points[1].Trim()) });
            //        edges.Add(new int[] { v, w });
            //    }
            //}
            //fs.Close();
            Digraph dg = new Digraph(v, edges);

            List<int> sources = new List<int>();

            for(int i = 1; i < args.Length; i++)
            {
                sources.Add(int.Parse(args[i]));
            }

            DirectedDepthFirstSearch ddfs = new DirectedDepthFirstSearch(dg, sources);
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
